namespace LogViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new DarkUI.Controls.DarkMenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpenNewTab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpenUnityLogTab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdbLogcat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.darkDockPanelMain = new DarkUI.Docking.DarkDockPanel();
            this.contextMenu = new DarkUI.Controls.DarkContextMenu();
            this.contextMenuFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFilterShowMatched = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFilterClear = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMatchColor = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panelMain.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTools,
            this.menuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip.Size = new System.Drawing.Size(1124, 24);
            this.menuStrip.TabIndex = 1;
            // 
            // menuFile
            // 
            this.menuFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileOpenNewTab,
            this.menuFileOpenUnityLogTab,
            this.menuFileSep1,
            this.menuFileClose,
            this.toolStripMenuItem3,
            this.menuFileExit});
            this.menuFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(58, 22);
            this.menuFile.Text = "文件(&F)";
            // 
            // menuFileOpenNewTab
            // 
            this.menuFileOpenNewTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuFileOpenNewTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuFileOpenNewTab.Name = "menuFileOpenNewTab";
            this.menuFileOpenNewTab.Size = new System.Drawing.Size(198, 22);
            this.menuFileOpenNewTab.Text = "打开(&O)";
            this.menuFileOpenNewTab.Click += new System.EventHandler(this.menuFileOpenNewTab_Click);
            // 
            // menuFileOpenUnityLogTab
            // 
            this.menuFileOpenUnityLogTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuFileOpenUnityLogTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuFileOpenUnityLogTab.Name = "menuFileOpenUnityLogTab";
            this.menuFileOpenUnityLogTab.Size = new System.Drawing.Size(198, 22);
            this.menuFileOpenUnityLogTab.Text = "打开 Unity Editor &Log";
            this.menuFileOpenUnityLogTab.Click += new System.EventHandler(this.menuFileOpenUnityLogTab_Click);
            // 
            // menuFileSep1
            // 
            this.menuFileSep1.Name = "menuFileSep1";
            this.menuFileSep1.Size = new System.Drawing.Size(195, 6);
            // 
            // menuFileClose
            // 
            this.menuFileClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuFileClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuFileClose.Name = "menuFileClose";
            this.menuFileClose.Size = new System.Drawing.Size(198, 22);
            this.menuFileClose.Text = "关闭";
            this.menuFileClose.Click += new System.EventHandler(this.menuFileClose_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(195, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuFileExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(198, 22);
            this.menuFileExit.Text = "退出(&X)";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuTools
            // 
            this.menuTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdbLogcat});
            this.menuTools.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(60, 22);
            this.menuTools.Text = "远端(&R)";
            // 
            // menuAdbLogcat
            // 
            this.menuAdbLogcat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuAdbLogcat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuAdbLogcat.Name = "menuAdbLogcat";
            this.menuAdbLogcat.Size = new System.Drawing.Size(162, 22);
            this.menuAdbLogcat.Text = "ADB Unity 日志";
            this.menuAdbLogcat.Click += new System.EventHandler(this.menuAdbLogcat_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpHelp,
            this.menuHelpSep1,
            this.menuHelpAbout});
            this.menuHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(61, 22);
            this.menuHelp.Text = "帮助(&H)";
            // 
            // menuHelpHelp
            // 
            this.menuHelpHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuHelpHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuHelpHelp.Name = "menuHelpHelp";
            this.menuHelpHelp.Size = new System.Drawing.Size(140, 22);
            this.menuHelpHelp.Text = "查看帮助(&V)";
            this.menuHelpHelp.Click += new System.EventHandler(this.menuHelpHelp_Click);
            // 
            // menuHelpSep1
            // 
            this.menuHelpSep1.Name = "menuHelpSep1";
            this.menuHelpSep1.Size = new System.Drawing.Size(137, 6);
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuHelpAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(140, 22);
            this.menuHelpAbout.Text = "关于(&A)";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.darkDockPanelMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Margin = new System.Windows.Forms.Padding(2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1124, 683);
            this.panelMain.TabIndex = 5;
            // 
            // darkDockPanelMain
            // 
            this.darkDockPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkDockPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkDockPanelMain.Location = new System.Drawing.Point(0, 0);
            this.darkDockPanelMain.Name = "darkDockPanelMain";
            this.darkDockPanelMain.Size = new System.Drawing.Size(1124, 683);
            this.darkDockPanelMain.TabIndex = 0;
            // 
            // contextMenu
            // 
            this.contextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.contextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
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
            this.contextMenu.Size = new System.Drawing.Size(125, 142);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // contextMenuFilter
            // 
            this.contextMenuFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.contextMenuFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuFilterShowMatched,
            this.contextMenuFilterClear});
            this.contextMenuFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextMenuFilter.Name = "contextMenuFilter";
            this.contextMenuFilter.Size = new System.Drawing.Size(124, 22);
            this.contextMenuFilter.Text = "过滤显示";
            // 
            // contextMenuFilterShowMatched
            // 
            this.contextMenuFilterShowMatched.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextMenuFilterShowMatched.Name = "contextMenuFilterShowMatched";
            this.contextMenuFilterShowMatched.Size = new System.Drawing.Size(136, 22);
            this.contextMenuFilterShowMatched.Text = "只显示搜索";
            this.contextMenuFilterShowMatched.Click += new System.EventHandler(this.contextMenuFilterShowMatched_Click);
            // 
            // contextMenuFilterClear
            // 
            this.contextMenuFilterClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextMenuFilterClear.Name = "contextMenuFilterClear";
            this.contextMenuFilterClear.Size = new System.Drawing.Size(136, 22);
            this.contextMenuFilterClear.Text = "显示所有";
            this.contextMenuFilterClear.Click += new System.EventHandler(this.contextMenuFilterClear_Click);
            // 
            // contextMenuSep1
            // 
            this.contextMenuSep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.contextMenuSep1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextMenuSep1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.contextMenuSep1.Name = "contextMenuSep1";
            this.contextMenuSep1.Size = new System.Drawing.Size(121, 6);
            // 
            // contextMenuSearch
            // 
            this.contextMenuSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.contextMenuSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMatchColor});
            this.contextMenuSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextMenuSearch.Name = "contextMenuSearch";
            this.contextMenuSearch.Size = new System.Drawing.Size(124, 22);
            this.contextMenuSearch.Text = "搜索颜色";
            // 
            // ToolStripMenuItemMatchColor
            // 
            this.ToolStripMenuItemMatchColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStripMenuItemMatchColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripMenuItemMatchColor.Name = "ToolStripMenuItemMatchColor";
            this.ToolStripMenuItemMatchColor.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItemMatchColor.Text = "匹配颜色";
            this.ToolStripMenuItemMatchColor.Click += new System.EventHandler(this.ToolStripMenuItemMatchColor_Click);
            // 
            // contextMenuSep2
            // 
            this.contextMenuSep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.contextMenuSep2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextMenuSep2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.contextMenuSep2.Name = "contextMenuSep2";
            this.contextMenuSep2.Size = new System.Drawing.Size(121, 6);
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.contextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuExportAll,
            this.contextMenuExportSelected});
            this.contextMenuExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(124, 22);
            this.contextMenuExport.Text = "导出内容";
            // 
            // contextMenuExportAll
            // 
            this.contextMenuExportAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextMenuExportAll.Name = "contextMenuExportAll";
            this.contextMenuExportAll.Size = new System.Drawing.Size(112, 22);
            this.contextMenuExportAll.Text = "所有";
            this.contextMenuExportAll.Click += new System.EventHandler(this.contextMenuExportAll_Click);
            // 
            // contextMenuExportSelected
            // 
            this.contextMenuExportSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextMenuExportSelected.Name = "contextMenuExportSelected";
            this.contextMenuExportSelected.Size = new System.Drawing.Size(112, 22);
            this.contextMenuExportSelected.Text = "选择项";
            this.contextMenuExportSelected.Click += new System.EventHandler(this.contextMenuExportSelected_Click);
            // 
            // contextMenuSep3
            // 
            this.contextMenuSep3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.contextMenuSep3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextMenuSep3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.contextMenuSep3.Name = "contextMenuSep3";
            this.contextMenuSep3.Size = new System.Drawing.Size(121, 6);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.contextMenuCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.Size = new System.Drawing.Size(124, 22);
            this.contextMenuCopy.Text = "复制内容";
            this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopy_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripMenuItem5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripMenuItem5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(121, 6);
            // 
            // contextLines
            // 
            this.contextLines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.contextLines.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextLinesGoToLine,
            this.contextLinesGoToFirstLine,
            this.contextLinesGoToLastLine});
            this.contextLines.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextLines.Name = "contextLines";
            this.contextLines.Size = new System.Drawing.Size(124, 22);
            this.contextLines.Text = "行定位";
            // 
            // contextLinesGoToLine
            // 
            this.contextLinesGoToLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextLinesGoToLine.Name = "contextLinesGoToLine";
            this.contextLinesGoToLine.Size = new System.Drawing.Size(124, 22);
            this.contextLinesGoToLine.Text = "跳转行";
            this.contextLinesGoToLine.Click += new System.EventHandler(this.contextLinesGoToLine_Click);
            // 
            // contextLinesGoToFirstLine
            // 
            this.contextLinesGoToFirstLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextLinesGoToFirstLine.Name = "contextLinesGoToFirstLine";
            this.contextLinesGoToFirstLine.Size = new System.Drawing.Size(124, 22);
            this.contextLinesGoToFirstLine.Text = "跳转首行";
            this.contextLinesGoToFirstLine.Click += new System.EventHandler(this.contextLinesGoToFirstLine_Click);
            // 
            // contextLinesGoToLastLine
            // 
            this.contextLinesGoToLastLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.contextLinesGoToLastLine.Name = "contextLinesGoToLastLine";
            this.contextLinesGoToLastLine.Size = new System.Drawing.Size(124, 22);
            this.contextLinesGoToLastLine.Text = "跳转尾行";
            this.contextLinesGoToLastLine.Click += new System.EventHandler(this.contextLinesGoToLastLine_Click);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1124, 707);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(680, 460);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unity Log Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStripSeparator menuFileSep1;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripSeparator menuHelpSep1;
        private DarkUI.Controls.DarkContextMenu contextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFilter;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFilterClear;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFilterShowMatched;
        private System.Windows.Forms.ToolStripSeparator contextMenuSep1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSearch;
        private System.Windows.Forms.ToolStripSeparator contextMenuSep2;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExport;
        private System.Windows.Forms.ToolStripSeparator contextMenuSep3;
        private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExportAll;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExportSelected;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem contextLines;
        private System.Windows.Forms.ToolStripMenuItem contextLinesGoToLine;
        private System.Windows.Forms.ToolStripMenuItem contextLinesGoToFirstLine;
        private System.Windows.Forms.ToolStripMenuItem contextLinesGoToLastLine;
        private System.Windows.Forms.ToolStripMenuItem menuFileClose;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpenNewTab;
        private DarkUI.Controls.DarkMenuStrip menuStrip;
        private DarkUI.Docking.DarkDockPanel darkDockPanelMain;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMatchColor;
        private System.Windows.Forms.ToolStripMenuItem menuAdbLogcat;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpenUnityLogTab;
    }
}

