﻿namespace Nikse.SubtitleEdit.Forms
{
    sealed partial class SpellCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonAddToDictionary = new System.Windows.Forms.Button();
            this.buttonSkipOnce = new System.Windows.Forms.Button();
            this.comboBoxDictionaries = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.richTextBoxParagraph = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addXToNamesnoiseListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxSuggestions = new System.Windows.Forms.ListBox();
            this.labelFullText = new System.Windows.Forms.Label();
            this.textBoxWord = new System.Windows.Forms.TextBox();
            this.buttonAbort = new System.Windows.Forms.Button();
            this.buttonSkipAll = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonUseSuggestion = new System.Windows.Forms.Button();
            this.buttonChangeAll = new System.Windows.Forms.Button();
            this.buttonUseSuggestionAlways = new System.Windows.Forms.Button();
            this.buttonAddToNames = new System.Windows.Forms.Button();
            this.groupBoxWordNotFound = new System.Windows.Forms.GroupBox();
            this.groupBoxSuggestions = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoChangeNames = new System.Windows.Forms.CheckBox();
            this.buttonEditWholeText = new System.Windows.Forms.Button();
            this.groupBoxEditWholeText = new System.Windows.Forms.GroupBox();
            this.buttonSkipText = new System.Windows.Forms.Button();
            this.buttonChangeWholeText = new System.Windows.Forms.Button();
            this.textBoxWholeText = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBoxWordNotFound.SuspendLayout();
            this.groupBoxSuggestions.SuspendLayout();
            this.groupBoxEditWholeText.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddToDictionary
            // 
            this.buttonAddToDictionary.Location = new System.Drawing.Point(20, 131);
            this.buttonAddToDictionary.Name = "buttonAddToDictionary";
            this.buttonAddToDictionary.Size = new System.Drawing.Size(250, 21);
            this.buttonAddToDictionary.TabIndex = 7;
            this.buttonAddToDictionary.Text = "Add to user dictionary (not case sensitive)";
            this.buttonAddToDictionary.UseVisualStyleBackColor = true;
            this.buttonAddToDictionary.Click += new System.EventHandler(this.ButtonAddToDictionaryClick);
            // 
            // buttonSkipOnce
            // 
            this.buttonSkipOnce.Location = new System.Drawing.Point(20, 75);
            this.buttonSkipOnce.Name = "buttonSkipOnce";
            this.buttonSkipOnce.Size = new System.Drawing.Size(122, 21);
            this.buttonSkipOnce.TabIndex = 4;
            this.buttonSkipOnce.Text = "Skip &once";
            this.buttonSkipOnce.UseVisualStyleBackColor = true;
            this.buttonSkipOnce.Click += new System.EventHandler(this.ButtonSkipOnceClick);
            // 
            // comboBoxDictionaries
            // 
            this.comboBoxDictionaries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDictionaries.FormattingEnabled = true;
            this.comboBoxDictionaries.Location = new System.Drawing.Point(317, 33);
            this.comboBoxDictionaries.Name = "comboBoxDictionaries";
            this.comboBoxDictionaries.Size = new System.Drawing.Size(271, 21);
            this.comboBoxDictionaries.TabIndex = 8;
            this.comboBoxDictionaries.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDictionariesSelectedIndexChanged);
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(314, 14);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(54, 13);
            this.labelLanguage.TabIndex = 3;
            this.labelLanguage.Text = "Language";
            // 
            // richTextBoxParagraph
            // 
            this.richTextBoxParagraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxParagraph.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBoxParagraph.Location = new System.Drawing.Point(11, 33);
            this.richTextBoxParagraph.Name = "richTextBoxParagraph";
            this.richTextBoxParagraph.ReadOnly = true;
            this.richTextBoxParagraph.Size = new System.Drawing.Size(292, 54);
            this.richTextBoxParagraph.TabIndex = 4;
            this.richTextBoxParagraph.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addXToNamesnoiseListToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1Opening);
            // 
            // addXToNamesnoiseListToolStripMenuItem
            // 
            this.addXToNamesnoiseListToolStripMenuItem.Name = "addXToNamesnoiseListToolStripMenuItem";
            this.addXToNamesnoiseListToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.addXToNamesnoiseListToolStripMenuItem.Text = "Add x to names/noise list";
            this.addXToNamesnoiseListToolStripMenuItem.Click += new System.EventHandler(this.AddXToNamesnoiseListToolStripMenuItemClick);
            // 
            // listBoxSuggestions
            // 
            this.listBoxSuggestions.FormattingEnabled = true;
            this.listBoxSuggestions.Location = new System.Drawing.Point(8, 44);
            this.listBoxSuggestions.Name = "listBoxSuggestions";
            this.listBoxSuggestions.Size = new System.Drawing.Size(272, 82);
            this.listBoxSuggestions.TabIndex = 11;
            this.listBoxSuggestions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxSuggestionsMouseDoubleClick);
            // 
            // labelFullText
            // 
            this.labelFullText.AutoSize = true;
            this.labelFullText.Location = new System.Drawing.Point(8, 14);
            this.labelFullText.Name = "labelFullText";
            this.labelFullText.Size = new System.Drawing.Size(46, 13);
            this.labelFullText.TabIndex = 7;
            this.labelFullText.Text = "Full text";
            // 
            // textBoxWord
            // 
            this.textBoxWord.Location = new System.Drawing.Point(20, 20);
            this.textBoxWord.Name = "textBoxWord";
            this.textBoxWord.Size = new System.Drawing.Size(250, 21);
            this.textBoxWord.TabIndex = 1;
            // 
            // buttonAbort
            // 
            this.buttonAbort.Location = new System.Drawing.Point(510, 308);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(85, 21);
            this.buttonAbort.TabIndex = 12;
            this.buttonAbort.Text = "Abort";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new System.EventHandler(this.ButtonAbortClick);
            // 
            // buttonSkipAll
            // 
            this.buttonSkipAll.Location = new System.Drawing.Point(148, 75);
            this.buttonSkipAll.Name = "buttonSkipAll";
            this.buttonSkipAll.Size = new System.Drawing.Size(122, 21);
            this.buttonSkipAll.TabIndex = 5;
            this.buttonSkipAll.Text = "&Skip all";
            this.buttonSkipAll.UseVisualStyleBackColor = true;
            this.buttonSkipAll.Click += new System.EventHandler(this.ButtonSkipAllClick);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(20, 47);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(122, 21);
            this.buttonChange.TabIndex = 2;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.ButtonChangeClick);
            // 
            // buttonUseSuggestion
            // 
            this.buttonUseSuggestion.Location = new System.Drawing.Point(93, 17);
            this.buttonUseSuggestion.Name = "buttonUseSuggestion";
            this.buttonUseSuggestion.Size = new System.Drawing.Size(90, 21);
            this.buttonUseSuggestion.TabIndex = 9;
            this.buttonUseSuggestion.Text = "Use";
            this.buttonUseSuggestion.UseVisualStyleBackColor = true;
            this.buttonUseSuggestion.Click += new System.EventHandler(this.ButtonUseSuggestionClick);
            // 
            // buttonChangeAll
            // 
            this.buttonChangeAll.Location = new System.Drawing.Point(148, 47);
            this.buttonChangeAll.Name = "buttonChangeAll";
            this.buttonChangeAll.Size = new System.Drawing.Size(122, 21);
            this.buttonChangeAll.TabIndex = 3;
            this.buttonChangeAll.Text = "Change all";
            this.buttonChangeAll.UseVisualStyleBackColor = true;
            this.buttonChangeAll.Click += new System.EventHandler(this.ButtonChangeAllClick);
            // 
            // buttonUseSuggestionAlways
            // 
            this.buttonUseSuggestionAlways.Location = new System.Drawing.Point(189, 17);
            this.buttonUseSuggestionAlways.Name = "buttonUseSuggestionAlways";
            this.buttonUseSuggestionAlways.Size = new System.Drawing.Size(90, 21);
            this.buttonUseSuggestionAlways.TabIndex = 10;
            this.buttonUseSuggestionAlways.Text = "Use always";
            this.buttonUseSuggestionAlways.UseVisualStyleBackColor = true;
            this.buttonUseSuggestionAlways.Click += new System.EventHandler(this.ButtonUseSuggestionAlwaysClick);
            // 
            // buttonAddToNames
            // 
            this.buttonAddToNames.Location = new System.Drawing.Point(20, 103);
            this.buttonAddToNames.Name = "buttonAddToNames";
            this.buttonAddToNames.Size = new System.Drawing.Size(250, 21);
            this.buttonAddToNames.TabIndex = 6;
            this.buttonAddToNames.Text = "Add to names/noise list (case sensitive)";
            this.buttonAddToNames.UseVisualStyleBackColor = true;
            this.buttonAddToNames.Click += new System.EventHandler(this.ButtonAddToNamesClick);
            // 
            // groupBoxWordNotFound
            // 
            this.groupBoxWordNotFound.Controls.Add(this.buttonAddToNames);
            this.groupBoxWordNotFound.Controls.Add(this.buttonAddToDictionary);
            this.groupBoxWordNotFound.Controls.Add(this.buttonSkipOnce);
            this.groupBoxWordNotFound.Controls.Add(this.buttonChangeAll);
            this.groupBoxWordNotFound.Controls.Add(this.textBoxWord);
            this.groupBoxWordNotFound.Controls.Add(this.buttonSkipAll);
            this.groupBoxWordNotFound.Controls.Add(this.buttonChange);
            this.groupBoxWordNotFound.Location = new System.Drawing.Point(11, 120);
            this.groupBoxWordNotFound.Name = "groupBoxWordNotFound";
            this.groupBoxWordNotFound.Size = new System.Drawing.Size(292, 182);
            this.groupBoxWordNotFound.TabIndex = 13;
            this.groupBoxWordNotFound.TabStop = false;
            this.groupBoxWordNotFound.Text = "Word not found";
            // 
            // groupBoxSuggestions
            // 
            this.groupBoxSuggestions.Controls.Add(this.buttonUseSuggestion);
            this.groupBoxSuggestions.Controls.Add(this.buttonUseSuggestionAlways);
            this.groupBoxSuggestions.Controls.Add(this.checkBoxAutoChangeNames);
            this.groupBoxSuggestions.Controls.Add(this.listBoxSuggestions);
            this.groupBoxSuggestions.Location = new System.Drawing.Point(309, 120);
            this.groupBoxSuggestions.Name = "groupBoxSuggestions";
            this.groupBoxSuggestions.Size = new System.Drawing.Size(286, 182);
            this.groupBoxSuggestions.TabIndex = 14;
            this.groupBoxSuggestions.TabStop = false;
            this.groupBoxSuggestions.Text = "Suggestions";
            // 
            // checkBoxAutoChangeNames
            // 
            this.checkBoxAutoChangeNames.AutoSize = true;
            this.checkBoxAutoChangeNames.Location = new System.Drawing.Point(8, 157);
            this.checkBoxAutoChangeNames.Name = "checkBoxAutoChangeNames";
            this.checkBoxAutoChangeNames.Size = new System.Drawing.Size(216, 17);
            this.checkBoxAutoChangeNames.TabIndex = 12;
            this.checkBoxAutoChangeNames.Text = "Auto fix names where only casing differ";
            this.checkBoxAutoChangeNames.UseVisualStyleBackColor = true;
            this.checkBoxAutoChangeNames.CheckedChanged += new System.EventHandler(this.CheckBoxAutoChangeNamesCheckedChanged);
            // 
            // buttonEditWholeText
            // 
            this.buttonEditWholeText.Location = new System.Drawing.Point(175, 91);
            this.buttonEditWholeText.Name = "buttonEditWholeText";
            this.buttonEditWholeText.Size = new System.Drawing.Size(128, 21);
            this.buttonEditWholeText.TabIndex = 39;
            this.buttonEditWholeText.Text = "Edit whole text";
            this.buttonEditWholeText.UseVisualStyleBackColor = true;
            this.buttonEditWholeText.Click += new System.EventHandler(this.ButtonEditWholeTextClick);
            // 
            // groupBoxEditWholeText
            // 
            this.groupBoxEditWholeText.Controls.Add(this.buttonSkipText);
            this.groupBoxEditWholeText.Controls.Add(this.buttonChangeWholeText);
            this.groupBoxEditWholeText.Controls.Add(this.textBoxWholeText);
            this.groupBoxEditWholeText.Location = new System.Drawing.Point(11, 120);
            this.groupBoxEditWholeText.Name = "groupBoxEditWholeText";
            this.groupBoxEditWholeText.Size = new System.Drawing.Size(292, 176);
            this.groupBoxEditWholeText.TabIndex = 40;
            this.groupBoxEditWholeText.TabStop = false;
            this.groupBoxEditWholeText.Text = "Edit whole text";
            // 
            // buttonSkipText
            // 
            this.buttonSkipText.Location = new System.Drawing.Point(151, 88);
            this.buttonSkipText.Name = "buttonSkipText";
            this.buttonSkipText.Size = new System.Drawing.Size(135, 21);
            this.buttonSkipText.TabIndex = 35;
            this.buttonSkipText.Text = "Skip once";
            this.buttonSkipText.UseVisualStyleBackColor = true;
            this.buttonSkipText.Click += new System.EventHandler(this.ButtonSkipTextClick);
            // 
            // buttonChangeWholeText
            // 
            this.buttonChangeWholeText.Location = new System.Drawing.Point(6, 88);
            this.buttonChangeWholeText.Name = "buttonChangeWholeText";
            this.buttonChangeWholeText.Size = new System.Drawing.Size(135, 21);
            this.buttonChangeWholeText.TabIndex = 34;
            this.buttonChangeWholeText.Text = "Change";
            this.buttonChangeWholeText.UseVisualStyleBackColor = true;
            this.buttonChangeWholeText.Click += new System.EventHandler(this.ButtonChangeWholeTextClick);
            // 
            // textBoxWholeText
            // 
            this.textBoxWholeText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWholeText.Location = new System.Drawing.Point(6, 19);
            this.textBoxWholeText.Multiline = true;
            this.textBoxWholeText.Name = "textBoxWholeText";
            this.textBoxWholeText.Size = new System.Drawing.Size(280, 63);
            this.textBoxWholeText.TabIndex = 31;
            // 
            // SpellCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 341);
            this.Controls.Add(this.richTextBoxParagraph);
            this.Controls.Add(this.comboBoxDictionaries);
            this.Controls.Add(this.buttonEditWholeText);
            this.Controls.Add(this.groupBoxSuggestions);
            this.Controls.Add(this.buttonAbort);
            this.Controls.Add(this.labelFullText);
            this.Controls.Add(this.labelLanguage);
            this.Controls.Add(this.groupBoxWordNotFound);
            this.Controls.Add(this.groupBoxEditWholeText);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpellCheck";
            this.Text = "Spell check";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpellCheck_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSpellCheck_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBoxWordNotFound.ResumeLayout(false);
            this.groupBoxWordNotFound.PerformLayout();
            this.groupBoxSuggestions.ResumeLayout(false);
            this.groupBoxSuggestions.PerformLayout();
            this.groupBoxEditWholeText.ResumeLayout(false);
            this.groupBoxEditWholeText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddToDictionary;
        private System.Windows.Forms.Button buttonSkipOnce;
        private System.Windows.Forms.ComboBox comboBoxDictionaries;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.RichTextBox richTextBoxParagraph;
        private System.Windows.Forms.ListBox listBoxSuggestions;
        private System.Windows.Forms.Label labelFullText;
        private System.Windows.Forms.TextBox textBoxWord;
        private System.Windows.Forms.Button buttonAbort;
        private System.Windows.Forms.Button buttonSkipAll;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonUseSuggestion;
        private System.Windows.Forms.Button buttonChangeAll;
        private System.Windows.Forms.Button buttonUseSuggestionAlways;
        private System.Windows.Forms.Button buttonAddToNames;
        private System.Windows.Forms.GroupBox groupBoxWordNotFound;
        private System.Windows.Forms.GroupBox groupBoxSuggestions;
        private System.Windows.Forms.Button buttonEditWholeText;
        private System.Windows.Forms.GroupBox groupBoxEditWholeText;
        private System.Windows.Forms.Button buttonSkipText;
        private System.Windows.Forms.Button buttonChangeWholeText;
        private System.Windows.Forms.TextBox textBoxWholeText;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addXToNamesnoiseListToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxAutoChangeNames;
    }
}