﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Nikse.SubtitleEdit.Logic.SubtitleFormats
{
    class Footage : SubtitleFormat
    {

        static readonly Regex RegexTimeCode = new Regex(@"^\s*\d+,\d\d$", RegexOptions.Compiled);

        enum ExpectingLine
        {
            Number,
            TimeStart,
            TimeEnd,
            Text
        }

        public override string Extension
        {
            get { return ".txt"; }
        }

        public override string Name
        {
            get { return "Footage"; }
        }

        public override bool IsTimeBased
        {
            get { return true; }
        }

        public override bool IsMine(List<string> lines, string fileName)
        {
            var subtitle = new Subtitle();
            LoadSubtitle(subtitle, lines, fileName);
            return subtitle.Paragraphs.Count > _errorCount;
        }

        public override string ToText(Subtitle subtitle, string title)
        {
//1.
//   66,13
//   70,00
//#Tā nu es sapazinos
//#И так я познакомился

//2.
//   71,14
//   78,10
//#ar dakteri Henriju Gūsu.
//#с доктором Генри Гусом.


            const string paragraphWriteFormat = "{4}.{3}{0}{3}{1}{3}{2}{3}";
            var sb = new StringBuilder();
            int count = 0;
            foreach (Paragraph p in subtitle.Paragraphs)
            {
                count++;
                bool italic = false;
                if (p.Text.StartsWith("<i>") && p.Text.EndsWith("</i>"))
                    italic = true;
                string text = Utilities.RemoveHtmlTags(p.Text);
                if (italic)
                    text = "#" + text;
                sb.AppendLine(string.Format(paragraphWriteFormat, EncodeTimeCode(p.StartTime), EncodeTimeCode(p.EndTime), text, Environment.NewLine, count));
            }
            return sb.ToString().Trim();
        }

        public override void LoadSubtitle(Subtitle subtitle, List<string> lines, string fileName)
        {
            Paragraph paragraph = null;
            ExpectingLine expecting = ExpectingLine.Number;
            _errorCount = 0;

            subtitle.Paragraphs.Clear();
            foreach (string line in lines)
            {
                if (line.EndsWith(".") && Utilities.IsInteger(line.TrimEnd('.')))
                {
                    if (paragraph != null && !string.IsNullOrEmpty(paragraph.Text))
                        subtitle.Paragraphs.Add(paragraph);
                    paragraph = new Paragraph();
                    expecting = ExpectingLine.TimeStart;
                }
                else if (paragraph != null && expecting == ExpectingLine.TimeStart && RegexTimeCode.IsMatch(line))
                {
                    string[] parts = line.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        try
                        {
                            var tc = DecodeTimeCode(parts);
                            paragraph.StartTime = tc;
                            expecting = ExpectingLine.TimeEnd;
                        }
                        catch
                        {
                            _errorCount++;
                            expecting = ExpectingLine.Number;
                        }
                    }
                }
                else if (paragraph != null && expecting == ExpectingLine.TimeEnd && RegexTimeCode.IsMatch(line))
                {
                    string[] parts = line.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        try
                        {
                            var tc = DecodeTimeCode(parts);
                            paragraph.EndTime = tc;
                            expecting = ExpectingLine.Text;
                        }
                        catch
                        {
                            _errorCount++;
                            expecting = ExpectingLine.Number;
                        }
                    }
                }
                else
                {
                    if (paragraph != null && expecting == ExpectingLine.Text)
                    {
                        if (line.Length > 0)
                        {
                            string s = line.Trim();
                            if (s.StartsWith("#"))
                                s = "<i>" + s.Remove(0, 1) + "</i>";
                            paragraph.Text = (paragraph.Text + Environment.NewLine + s).Trim();
                            paragraph.Text = paragraph.Text.Replace("</i>" + Environment.NewLine + "<i>", Environment.NewLine);
                            if (paragraph.Text.Length > 2000)
                            {
                                _errorCount += 100;
                                return;
                            }
                        }
                    }
                }
            }
            if (paragraph != null && !string.IsNullOrEmpty(paragraph.Text))
                subtitle.Paragraphs.Add(paragraph);

            subtitle.Renumber(1);
        }

        private string EncodeTimeCode(TimeCode time)
        {
            return string.Format("{0:00},{1:00}", (int)time.TotalSeconds, MillisecondsToFramesMaxFrameRate(time.Milliseconds)).PadLeft(8);
        }

        private TimeCode DecodeTimeCode(string[] parts)
        {
            string seconds = parts[0];
            string frames = parts[1];

            return new TimeCode(0, 0, int.Parse(seconds), FramesToMillisecondsMax999(int.Parse(frames)));
        }

    }
}