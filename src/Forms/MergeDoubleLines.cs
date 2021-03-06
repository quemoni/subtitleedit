﻿using Nikse.SubtitleEdit.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nikse.SubtitleEdit.Forms
{
    public partial class MergeDoubleLines : Form
    {
        Subtitle _subtitle;
        private Subtitle _mergedSubtitle;
        bool loading = true;
        Timer previewTimer = new Timer();

        public int NumberOfMerges { get; private set; }

        public MergeDoubleLines()
        {
            InitializeComponent();
            previewTimer.Tick += previewTimer_Tick;
            previewTimer.Interval = 250;
            FixLargeFonts();
        }

        private void FixLargeFonts()
        {
            Graphics graphics = this.CreateGraphics();
            SizeF textSize = graphics.MeasureString(buttonOK.Text, this.Font);
            if (textSize.Height > buttonOK.Height - 4)
            {
                int newButtonHeight = (int)(textSize.Height + 7 + 0.5);
                Utilities.SetButtonHeight(this, newButtonHeight, 1);
            }
        }

        public Subtitle MergedSubtitle
        {
            get { return _mergedSubtitle; }
        }

        public void Initialize(Subtitle subtitle)
        {
            if (subtitle.Paragraphs.Count > 0)
                subtitle.Renumber(subtitle.Paragraphs[0].Number);

            Text = Configuration.Settings.Language.MergeDoubleLines.Title;
            if (!string.IsNullOrEmpty(Configuration.Settings.Language.MergeDoubleLines.MaxMillisecondsBetweenLines)) //TODO: Remove in SE 3.3.4
            {
                labelMaxMillisecondsBetweenLines.Text = Configuration.Settings.Language.MergeDoubleLines.MaxMillisecondsBetweenLines;
                checkBoxIncludeIncrementing.Text = Configuration.Settings.Language.MergeDoubleLines.IncludeIncrementing;
                numericUpDownMaxMillisecondsBetweenLines.Left = labelMaxMillisecondsBetweenLines.Left + labelMaxMillisecondsBetweenLines.Width + 3;
                checkBoxIncludeIncrementing.Left = numericUpDownMaxMillisecondsBetweenLines.Left + numericUpDownMaxMillisecondsBetweenLines.Width + 10;
            }

            listViewFixes.Columns[0].Text = Configuration.Settings.Language.General.Apply;
            listViewFixes.Columns[1].Text = Configuration.Settings.Language.General.LineNumber;
            listViewFixes.Columns[2].Text = Configuration.Settings.Language.MergedShortLines.MergedText;

            buttonOK.Text = Configuration.Settings.Language.General.OK;
            buttonCancel.Text = Configuration.Settings.Language.General.Cancel;
            SubtitleListview1.InitializeLanguage(Configuration.Settings.Language.General, Configuration.Settings);
            Utilities.InitializeSubtitleFont(SubtitleListview1);
            SubtitleListview1.AutoSizeAllColumns(this);
            NumberOfMerges = 0;
            _subtitle = subtitle;
            MergeDoubleLines_ResizeEnd(null, null);
        }

        private void AddToListView(Paragraph p, string lineNumbers, string newText)
        {
            var item = new ListViewItem(string.Empty) { Tag = p, Checked = true };

            var subItem = new ListViewItem.ListViewSubItem(item, lineNumbers.TrimEnd(','));
            item.SubItems.Add(subItem);
            subItem = new ListViewItem.ListViewSubItem(item, newText.Replace(Environment.NewLine, Configuration.Settings.General.ListViewLineSeparatorString));
            item.SubItems.Add(subItem);

            listViewFixes.Items.Add(item);
        }

        private void GeneratePreview()
        {
            if (_subtitle == null)
                return;

            var mergedIndexes = new List<int>();

            NumberOfMerges = 0;
            SubtitleListview1.Items.Clear();
            SubtitleListview1.BeginUpdate();
            int count;
            _mergedSubtitle = MergeLineswithSameTextInSubtitle(_subtitle, mergedIndexes, out count, true, checkBoxIncludeIncrementing.Checked, true, (int)numericUpDownMaxMillisecondsBetweenLines.Value);
            NumberOfMerges = count;

            SubtitleListview1.Fill(_subtitle);

            foreach(var index in mergedIndexes)
            {
                SubtitleListview1.SetBackgroundColor(index, Color.Green);
            }


            SubtitleListview1.EndUpdate();
            groupBoxLinesFound.Text = string.Format(Configuration.Settings.Language.MergedShortLines.NumberOfMergesX, NumberOfMerges);
        }

        private bool IsFixAllowed(Paragraph p)
        {
            foreach (ListViewItem item in listViewFixes.Items)
            {
                string numbers = item.SubItems[1].Text;
                foreach (string number in numbers.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    if (number == p.Number.ToString())
                        return item.Checked;
                }
            }
            return true;
        }

        public Subtitle MergeLineswithSameTextInSubtitle(Subtitle subtitle, List<int> mergedIndexes, out int numberOfMerges, bool clearFixes, bool fixIncrementing, bool lineAfterNext, int maxMsBetween)
        {
            List<int> removed = new List<int>();
            if (!loading)
                listViewFixes.ItemChecked -= listViewFixes_ItemChecked;
            if (clearFixes)
                listViewFixes.Items.Clear();
            numberOfMerges = 0;
            var mergedSubtitle = new Subtitle();
            bool lastMerged = false;
            Paragraph p = null;
            var lineNumbers = new StringBuilder();
            for (int i = 1; i < subtitle.Paragraphs.Count; i++)
            {
                if (!lastMerged)
                {
                    p = new Paragraph(subtitle.GetParagraphOrDefault(i - 1));
                    mergedSubtitle.Paragraphs.Add(p);
                }
                Paragraph next = subtitle.GetParagraphOrDefault(i);
                Paragraph afterNext = subtitle.GetParagraphOrDefault(i + 1);
                if (p != null && next != null)
                {
                    if ((QualifiesForMerge(p, next, maxMsBetween) || (fixIncrementing && QualifiesForMergeIncrement(p, next, maxMsBetween))) && IsFixAllowed(p))
                    {
                        p.Text = next.Text;
                        p.EndTime = next.EndTime;
                        if (lastMerged)
                        {
                            lineNumbers.Append(next.Number.ToString() + ",");
                        }
                        else
                        {
                            lineNumbers.Append(p.Number.ToString() + ",");
                            lineNumbers.Append(next.Number.ToString() + ",");
                        }

                        lastMerged = true;
                        removed.Add(i);
                        numberOfMerges++;
                        if (!mergedIndexes.Contains(i))
                            mergedIndexes.Add(i);
                        if (!mergedIndexes.Contains(i - 1))
                            mergedIndexes.Add(i - 1);
                    }
                    else if (lineAfterNext && QualifiesForMerge(p, afterNext, maxMsBetween) && p.Duration.TotalMilliseconds > afterNext.Duration.TotalMilliseconds && IsFixAllowed(p))
                    {
                        removed.Add(i + 2);
                        numberOfMerges++;
                        if (lastMerged)
                        {
                            lineNumbers.Append(afterNext.Number.ToString() + ",");
                        }
                        else
                        {
                            lineNumbers.Append(p.Number.ToString() + ",");
                            lineNumbers.Append(afterNext.Number.ToString() + ",");
                        }
                        lastMerged = true;
                        if (!mergedIndexes.Contains(i))
                            mergedIndexes.Add(i);
                        if (!mergedIndexes.Contains(i - 1))
                            mergedIndexes.Add(i - 1);
                    }
                    else
                    {
                        lastMerged = false;
                    }
                }
                else
                {
                    lastMerged = false;
                }

                if (!removed.Contains(i) && lineNumbers.Length > 0 && clearFixes)
                {
                    AddToListView(p, lineNumbers.ToString(), p.Text);
                    lineNumbers = new StringBuilder();
                }
            }
            if (lineNumbers.Length > 0 && clearFixes)
            {
                AddToListView(p, lineNumbers.ToString(), p.Text);
            }
            if (!lastMerged)
                mergedSubtitle.Paragraphs.Add(new Paragraph(subtitle.GetParagraphOrDefault(subtitle.Paragraphs.Count - 1)));

            if (!loading)
                listViewFixes.ItemChecked += listViewFixes_ItemChecked;

            mergedSubtitle.Renumber(1);
            return mergedSubtitle;
        }

        private bool QualifiesForMerge(Paragraph p, Paragraph next, int maxMsBetween)
        {
            if (p == null || next == null)
                return false;

            if (next.StartTime.TotalMilliseconds - p.EndTime.TotalMilliseconds > maxMsBetween)
                return false;

            if (p.Text != null && next.Text != null)
            {
                string s = Utilities.RemoveHtmlTags(p.Text.Trim());
                string s2 = Utilities.RemoveHtmlTags(next.Text.Trim());
                return s == s2;
            }
            return false;
        }

        private bool QualifiesForMergeIncrement(Paragraph p, Paragraph next, int maxMsBetween)
        {
            if (p == null || next == null)
                return false;

            if (next.StartTime.TotalMilliseconds - p.EndTime.TotalMilliseconds > maxMsBetween)
                return false;

            if (p.Text != null && next.Text != null)
            {
                string s = Utilities.RemoveHtmlTags(p.Text.Trim());
                string s2 = Utilities.RemoveHtmlTags(next.Text.Trim());
                if (!string.IsNullOrEmpty(s) && s2.Length > 0 && s2.StartsWith(s))
                    return true;
            }
            return false;
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void listViewFixes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFixes.SelectedIndices.Count > 0)
            {
                int index = listViewFixes.SelectedIndices[0];
                ListViewItem item = listViewFixes.Items[index];
                string[] numbers = item.SubItems[1].Text.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string number in numbers)
                {
                    foreach (Paragraph p in _subtitle.Paragraphs)
                    {
                        if (p.Number.ToString() == number)
                        {
                            index = _subtitle.GetIndex(p);
                            SubtitleListview1.EnsureVisible(index);
                        }
                    }
                }
            }
        }

        private void listViewFixes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (loading)
                return;

            var mergedIndexes = new List<int>();

            NumberOfMerges = 0;
            SubtitleListview1.Items.Clear();
            SubtitleListview1.BeginUpdate();
            int count;
            _mergedSubtitle = MergeLineswithSameTextInSubtitle(_subtitle, mergedIndexes, out count, false, checkBoxIncludeIncrementing.Checked, true, (int)numericUpDownMaxMillisecondsBetweenLines.Value);
            NumberOfMerges = count;
            SubtitleListview1.Fill(_subtitle);
            foreach (var index in mergedIndexes)
            {
                SubtitleListview1.SetBackgroundColor(index, Color.Green);
            }
            SubtitleListview1.EndUpdate();
            groupBoxLinesFound.Text = string.Format(Configuration.Settings.Language.MergedShortLines.NumberOfMergesX, NumberOfMerges);
        }

        private void checkBoxOnlyContinuationLines_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GeneratePreview();
            Cursor = Cursors.Default;
        }

        private void MergeDoubleLines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }

        private void MergeDoubleLines_Shown(object sender, EventArgs e)
        {
            GeneratePreview();
            listViewFixes.Focus();
            if (listViewFixes.Items.Count > 0)
                listViewFixes.Items[0].Selected = true;
            loading = false;
            listViewFixes.ItemChecked += listViewFixes_ItemChecked;
        }

        private void checkBoxFixIncrementing_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GeneratePreview();
            Cursor = Cursors.Default;
        }

        private void numericUpDownMaxMillisecondsBetweenLines_ValueChanged(object sender, EventArgs e)
        {
            previewTimer.Stop();
            previewTimer.Start();
        }

        void previewTimer_Tick(object sender, EventArgs e)
        {
            previewTimer.Stop();
            Cursor = Cursors.WaitCursor;
            GeneratePreview();
            Cursor = Cursors.Default;
        }

        private void MergeDoubleLines_ResizeEnd(object sender, EventArgs e)
        {
            columnHeaderText.Width = -2;
        }

    }
}
