﻿namespace LogViewer
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpenNewTab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsMultiStringSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuToolsConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolLabelSearch = new System.Windows.Forms.ToolStripLabel();
            this.textSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolLabelType = new System.Windows.Forms.ToolStripLabel();
            this.dropdownSearchType = new System.Windows.Forms.ToolStripComboBox();
            this.toolButtonCumulative = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFilterShowMatched = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFilterHideMatched = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuFilterClear = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSearchViewTerms = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuSearchColour = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSearchMatch = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSearchColourContext = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.contextLines = new System.Windows.Forms.ToolStripMenuItem();
            this.contextLinesGoToLine = new System.Windows.Forms.ToolStripMenuItem();
            this.contextLinesGoToFirstLine = new System.Windows.Forms.ToolStripMenuItem();
            this.contextLinesGoToLastLine = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTools,
            this.menuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(923, 24);
            this.menuStrip.TabIndex = 1;
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileOpen,
            this.menuFileOpenNewTab,
            this.menuFileSep1,
            this.menuFileClose,
            this.toolStripMenuItem3,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(39, 22);
            this.menuFile.Text = "&File";
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Enabled = false;
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.Size = new System.Drawing.Size(172, 22);
            this.menuFileOpen.Text = "&Open";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileOpenNewTab
            // 
            this.menuFileOpenNewTab.Name = "menuFileOpenNewTab";
            this.menuFileOpenNewTab.Size = new System.Drawing.Size(172, 22);
            this.menuFileOpenNewTab.Text = "Open (New Tab)";
            this.menuFileOpenNewTab.Click += new System.EventHandler(this.menuFileOpenNewTab_Click);
            // 
            // menuFileSep1
            // 
            this.menuFileSep1.Name = "menuFileSep1";
            this.menuFileSep1.Size = new System.Drawing.Size(169, 6);
            // 
            // menuFileClose
            // 
            this.menuFileClose.Name = "menuFileClose";
            this.menuFileClose.Size = new System.Drawing.Size(172, 22);
            this.menuFileClose.Text = "Close";
            this.menuFileClose.Click += new System.EventHandler(this.menuFileClose_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(169, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(172, 22);
            this.menuFileExit.Text = "&Exit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolsMultiStringSearch,
            this.toolStripMenuItem2,
            this.menuToolsConfiguration});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(52, 22);
            this.menuTools.Text = "Tools";
            // 
            // menuToolsMultiStringSearch
            // 
            this.menuToolsMultiStringSearch.Enabled = false;
            this.menuToolsMultiStringSearch.Name = "menuToolsMultiStringSearch";
            this.menuToolsMultiStringSearch.Size = new System.Drawing.Size(187, 22);
            this.menuToolsMultiStringSearch.Text = "Multi-String Search";
            this.menuToolsMultiStringSearch.Click += new System.EventHandler(this.menuToolsMultiStringSearch_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(184, 6);
            // 
            // menuToolsConfiguration
            // 
            this.menuToolsConfiguration.Name = "menuToolsConfiguration";
            this.menuToolsConfiguration.Size = new System.Drawing.Size(187, 22);
            this.menuToolsConfiguration.Text = "Configuration";
            this.menuToolsConfiguration.Click += new System.EventHandler(this.menuToolsConfiguration_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpHelp,
            this.menuHelpSep1,
            this.menuHelpAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(47, 22);
            this.menuHelp.Text = "&Help";
            // 
            // menuHelpHelp
            // 
            this.menuHelpHelp.Name = "menuHelpHelp";
            this.menuHelpHelp.Size = new System.Drawing.Size(111, 22);
            this.menuHelpHelp.Text = "&Help";
            this.menuHelpHelp.Click += new System.EventHandler(this.menuHelpHelp_Click);
            // 
            // menuHelpSep1
            // 
            this.menuHelpSep1.Name = "menuHelpSep1";
            this.menuHelpSep1.Size = new System.Drawing.Size(108, 6);
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(111, 22);
            this.menuHelpAbout.Text = "&About";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLabelSearch,
            this.textSearch,
            this.toolLabelType,
            this.dropdownSearchType,
            this.toolButtonCumulative,
            this.toolStripSeparator1,
            this.toolButtonSearch});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(923, 31);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.TabStop = true;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolLabelSearch
            // 
            this.toolLabelSearch.Name = "toolLabelSearch";
            this.toolLabelSearch.Size = new System.Drawing.Size(47, 28);
            this.toolLabelSearch.Text = "Search";
            // 
            // textSearch
            // 
            this.textSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(335, 31);
            // 
            // toolLabelType
            // 
            this.toolLabelType.Name = "toolLabelType";
            this.toolLabelType.Size = new System.Drawing.Size(36, 28);
            this.toolLabelType.Text = "Type";
            // 
            // dropdownSearchType
            // 
            this.dropdownSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownSearchType.Items.AddRange(new object[] {
            "String Case Insensitive",
            "String Case Sensitive",
            "Regex Case Insensitive",
            "Regex Case Sensitive"});
            this.dropdownSearchType.Name = "dropdownSearchType";
            this.dropdownSearchType.Size = new System.Drawing.Size(168, 31);
            // 
            // toolButtonCumulative
            // 
            this.toolButtonCumulative.Checked = true;
            this.toolButtonCumulative.CheckOnClick = true;
            this.toolButtonCumulative.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolButtonCumulative.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolButtonCumulative.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonCumulative.Image")));
            this.toolButtonCumulative.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonCumulative.Name = "toolButtonCumulative";
            this.toolButtonCumulative.Size = new System.Drawing.Size(75, 28);
            this.toolButtonCumulative.Text = "Cumulative";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolButtonSearch
            // 
            this.toolButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonSearch.Image")));
            this.toolButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonSearch.Name = "toolButtonSearch";
            this.toolButtonSearch.Size = new System.Drawing.Size(28, 28);
            this.toolButtonSearch.ToolTipText = "Search";
            this.toolButtonSearch.Click += new System.EventHandler(this.toolButtonSearch_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tabControl);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 55);
            this.panelMain.Margin = new System.Windows.Forms.Padding(2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(923, 487);
            this.panelMain.TabIndex = 5;
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(923, 487);
            this.tabControl.TabIndex = 1;
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuFilter,
            this.contextMenuSep1,
            this.contextMenuSearch,
            this.contextMenuSep2,
            this.contextMenuExport,
            this.contextMenuSep3,
            this.contextMenuCopy,
            this.toolStripMenuItem5,
            this.contextLines});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenu.Size = new System.Drawing.Size(123, 138);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // contextMenuFilter
            // 
            this.contextMenuFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuFilterShowMatched,
            this.contextMenuFilterHideMatched,
            this.toolStripMenuItem1,
            this.contextMenuFilterClear});
            this.contextMenuFilter.Name = "contextMenuFilter";
            this.contextMenuFilter.Size = new System.Drawing.Size(122, 22);
            this.contextMenuFilter.Text = "Filtering";
            // 
            // contextMenuFilterShowMatched
            // 
            this.contextMenuFilterShowMatched.Name = "contextMenuFilterShowMatched";
            this.contextMenuFilterShowMatched.Size = new System.Drawing.Size(161, 22);
            this.contextMenuFilterShowMatched.Text = "Show matched";
            this.contextMenuFilterShowMatched.Click += new System.EventHandler(this.contextMenuFilterShowMatched_Click);
            // 
            // contextMenuFilterHideMatched
            // 
            this.contextMenuFilterHideMatched.Name = "contextMenuFilterHideMatched";
            this.contextMenuFilterHideMatched.Size = new System.Drawing.Size(161, 22);
            this.contextMenuFilterHideMatched.Text = "Hide matched";
            this.contextMenuFilterHideMatched.Click += new System.EventHandler(this.contextMenuFilterHideMatched_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // contextMenuFilterClear
            // 
            this.contextMenuFilterClear.Name = "contextMenuFilterClear";
            this.contextMenuFilterClear.Size = new System.Drawing.Size(161, 22);
            this.contextMenuFilterClear.Text = "Clear";
            this.contextMenuFilterClear.Click += new System.EventHandler(this.contextMenuFilterClear_Click);
            // 
            // contextMenuSep1
            // 
            this.contextMenuSep1.Name = "contextMenuSep1";
            this.contextMenuSep1.Size = new System.Drawing.Size(119, 6);
            // 
            // contextMenuSearch
            // 
            this.contextMenuSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuSearchViewTerms,
            this.toolStripMenuItem4,
            this.contextMenuSearchColour});
            this.contextMenuSearch.Name = "contextMenuSearch";
            this.contextMenuSearch.Size = new System.Drawing.Size(122, 22);
            this.contextMenuSearch.Text = "Search";
            // 
            // contextMenuSearchViewTerms
            // 
            this.contextMenuSearchViewTerms.Name = "contextMenuSearchViewTerms";
            this.contextMenuSearchViewTerms.Size = new System.Drawing.Size(143, 22);
            this.contextMenuSearchViewTerms.Text = "View Terms";
            this.contextMenuSearchViewTerms.Click += new System.EventHandler(this.contextMenuSearchViewTerms_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(140, 6);
            // 
            // contextMenuSearchColour
            // 
            this.contextMenuSearchColour.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuSearchMatch,
            this.contextMenuSearchColourContext});
            this.contextMenuSearchColour.Name = "contextMenuSearchColour";
            this.contextMenuSearchColour.Size = new System.Drawing.Size(143, 22);
            this.contextMenuSearchColour.Text = "Colour";
            // 
            // contextMenuSearchMatch
            // 
            this.contextMenuSearchMatch.Name = "contextMenuSearchMatch";
            this.contextMenuSearchMatch.Size = new System.Drawing.Size(120, 22);
            this.contextMenuSearchMatch.Text = "Match";
            this.contextMenuSearchMatch.Click += new System.EventHandler(this.contextMenuSearchColourMatch_Click);
            // 
            // contextMenuSearchColourContext
            // 
            this.contextMenuSearchColourContext.Name = "contextMenuSearchColourContext";
            this.contextMenuSearchColourContext.Size = new System.Drawing.Size(120, 22);
            this.contextMenuSearchColourContext.Text = "Context";
            this.contextMenuSearchColourContext.Click += new System.EventHandler(this.contextMenuSearchColourContext_Click);
            // 
            // contextMenuSep2
            // 
            this.contextMenuSep2.Name = "contextMenuSep2";
            this.contextMenuSep2.Size = new System.Drawing.Size(119, 6);
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuExportAll,
            this.contextMenuExportSelected});
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(122, 22);
            this.contextMenuExport.Text = "Export";
            // 
            // contextMenuExportAll
            // 
            this.contextMenuExportAll.Name = "contextMenuExportAll";
            this.contextMenuExportAll.Size = new System.Drawing.Size(125, 22);
            this.contextMenuExportAll.Text = "All";
            this.contextMenuExportAll.Click += new System.EventHandler(this.contextMenuExportAll_Click);
            // 
            // contextMenuExportSelected
            // 
            this.contextMenuExportSelected.Name = "contextMenuExportSelected";
            this.contextMenuExportSelected.Size = new System.Drawing.Size(125, 22);
            this.contextMenuExportSelected.Text = "Selected";
            this.contextMenuExportSelected.Click += new System.EventHandler(this.contextMenuExportSelected_Click);
            // 
            // contextMenuSep3
            // 
            this.contextMenuSep3.Name = "contextMenuSep3";
            this.contextMenuSep3.Size = new System.Drawing.Size(119, 6);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.Size = new System.Drawing.Size(122, 22);
            this.contextMenuCopy.Text = "Copy";
            this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopy_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(119, 6);
            // 
            // contextLines
            // 
            this.contextLines.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextLinesGoToLine,
            this.contextLinesGoToFirstLine,
            this.contextLinesGoToLastLine});
            this.contextLines.Name = "contextLines";
            this.contextLines.Size = new System.Drawing.Size(122, 22);
            this.contextLines.Text = "Lines";
            // 
            // contextLinesGoToLine
            // 
            this.contextLinesGoToLine.Name = "contextLinesGoToLine";
            this.contextLinesGoToLine.Size = new System.Drawing.Size(167, 22);
            this.contextLinesGoToLine.Text = "Go To Line";
            this.contextLinesGoToLine.Click += new System.EventHandler(this.contextLinesGoToLine_Click);
            // 
            // contextLinesGoToFirstLine
            // 
            this.contextLinesGoToFirstLine.Name = "contextLinesGoToFirstLine";
            this.contextLinesGoToFirstLine.Size = new System.Drawing.Size(167, 22);
            this.contextLinesGoToFirstLine.Text = "Go To First Line";
            this.contextLinesGoToFirstLine.Click += new System.EventHandler(this.contextLinesGoToFirstLine_Click);
            // 
            // contextLinesGoToLastLine
            // 
            this.contextLinesGoToLastLine.Name = "contextLinesGoToLastLine";
            this.contextLinesGoToLastLine.Size = new System.Drawing.Size(167, 22);
            this.contextLinesGoToLastLine.Text = "Go To Last Line";
            this.contextLinesGoToLastLine.Click += new System.EventHandler(this.contextLinesGoToLastLine_Click);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 542);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolLabelSearch;
        private System.Windows.Forms.ToolStripTextBox textSearch;
        private System.Windows.Forms.ToolStripButton toolButtonSearch;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripSeparator menuFileSep1;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripSeparator menuHelpSep1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripComboBox dropdownSearchType;
        private System.Windows.Forms.ToolStripLabel toolLabelType;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFilter;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFilterClear;
        private System.Windows.Forms.ToolStripButton toolButtonCumulative;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFilterShowMatched;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFilterHideMatched;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator contextMenuSep1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSearch;
        private System.Windows.Forms.ToolStripSeparator contextMenuSep2;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExport;
        private System.Windows.Forms.ToolStripSeparator contextMenuSep3;
        private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSearchViewTerms;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExportAll;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExportSelected;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuToolsMultiStringSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuToolsConfiguration;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSearchColour;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSearchMatch;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSearchColourContext;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem contextLines;
        private System.Windows.Forms.ToolStripMenuItem contextLinesGoToLine;
        private System.Windows.Forms.ToolStripMenuItem contextLinesGoToFirstLine;
        private System.Windows.Forms.ToolStripMenuItem contextLinesGoToLastLine;
        private System.Windows.Forms.ToolStripMenuItem menuFileClose;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpenNewTab;
        private System.Windows.Forms.TabControl tabControl;
    }
}

