namespace LogViewer
{
    partial class DocLogFile
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocLogFile));
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle13 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle14 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle15 = new BrightIdeasSoftware.HeaderStateStyle();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip = new DarkUI.Controls.DarkStatusStrip();
            this.statusLabelPage = new System.Windows.Forms.ToolStripStatusLabel();
            this.richTextBoxStrace = new System.Windows.Forms.RichTextBox();
            this.imageListLog = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fastObjectListView1 = new BrightIdeasSoftware.FastObjectListView();
            this.headerFormatStyleLog = new BrightIdeasSoftware.HeaderFormatStyle();
            this.toolStripButtonInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWarning = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonError = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonHistory = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButtonViewMatch = new System.Windows.Forms.ToolStripButton();
            this.toolStripTab = new DarkUI.Controls.DarkToolStrip();
            this.toolStripButtonCancle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonErrorNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonErrorPrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSearchPrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearchNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCustom = new System.Windows.Forms.ToolStripButton();
            this.highlightTextRendererLog = new BrightIdeasSoftware.HighlightTextRenderer();
            this.darkToolStripAdb = new DarkUI.Controls.DarkToolStrip();
            this.toolStripDropDownButtonAdbCon = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemAdbConLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdbConMu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdbConYe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdbConXiao = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxAdbConIp = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonAdbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonAdbDevices = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButtonPicAdbLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPauseAdbLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonResumeAdbLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearAdbLog = new System.Windows.Forms.ToolStripButton();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).BeginInit();
            this.toolStripTab.SuspendLayout();
            this.darkToolStripAdb.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusProgress
            // 
            this.statusProgress.Name = "statusProgress";
            this.statusProgress.Size = new System.Drawing.Size(67, 16);
            this.statusProgress.Visible = false;
            this.statusProgress.Click += new System.EventHandler(this.statusProgress_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.statusStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusProgress,
            this.statusLabelPage});
            this.statusStrip.Location = new System.Drawing.Point(0, 617);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip.Size = new System.Drawing.Size(894, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabelPage
            // 
            this.statusLabelPage.Name = "statusLabelPage";
            this.statusLabelPage.Size = new System.Drawing.Size(0, 17);
            // 
            // richTextBoxStrace
            // 
            this.richTextBoxStrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.richTextBoxStrace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxStrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxStrace.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxStrace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.richTextBoxStrace.Location = new System.Drawing.Point(4, 0);
            this.richTextBoxStrace.Name = "richTextBoxStrace";
            this.richTextBoxStrace.Size = new System.Drawing.Size(888, 162);
            this.richTextBoxStrace.TabIndex = 0;
            this.richTextBoxStrace.Text = "";
            this.richTextBoxStrace.WordWrap = false;
            // 
            // imageListLog
            // 
            this.imageListLog.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLog.ImageStream")));
            this.imageListLog.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLog.Images.SetKeyName(0, "1 (1).png");
            this.imageListLog.Images.SetKeyName(1, "1 (2).png");
            this.imageListLog.Images.SetKeyName(2, "1 (3).png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fastObjectListView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxStrace);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4, 0, 2, 20);
            this.splitContainer1.Size = new System.Drawing.Size(894, 589);
            this.splitContainer1.SplitterDistance = 403;
            this.splitContainer1.TabIndex = 5;
            // 
            // fastObjectListView1
            // 
            this.fastObjectListView1.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.fastObjectListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.fastObjectListView1.CellEditUseWholeCell = false;
            this.fastObjectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastObjectListView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.fastObjectListView1.HeaderFormatStyle = this.headerFormatStyleLog;
            this.fastObjectListView1.HideSelection = false;
            this.fastObjectListView1.Location = new System.Drawing.Point(0, 0);
            this.fastObjectListView1.Name = "fastObjectListView1";
            this.fastObjectListView1.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(110)))), ((int)(((byte)(175)))));
            this.fastObjectListView1.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.fastObjectListView1.ShowGroups = false;
            this.fastObjectListView1.Size = new System.Drawing.Size(894, 403);
            this.fastObjectListView1.SmallImageList = this.imageListLog;
            this.fastObjectListView1.TabIndex = 0;
            this.fastObjectListView1.UnfocusedSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.fastObjectListView1.UnfocusedSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.fastObjectListView1.UseAlternatingBackColors = true;
            this.fastObjectListView1.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView1.View = System.Windows.Forms.View.Details;
            this.fastObjectListView1.VirtualMode = true;
            this.fastObjectListView1.SelectedIndexChanged += new System.EventHandler(this.fastObjectListView1_SelectedIndexChanged);
            // 
            // headerFormatStyleLog
            // 
            headerStateStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(77)))), ((int)(((byte)(95)))));
            headerStateStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.headerFormatStyleLog.Hot = headerStateStyle13;
            headerStateStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            headerStateStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.headerFormatStyleLog.Normal = headerStateStyle14;
            this.headerFormatStyleLog.Pressed = headerStateStyle15;
            // 
            // toolStripButtonInfo
            // 
            this.toolStripButtonInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonInfo.Checked = true;
            this.toolStripButtonInfo.CheckOnClick = true;
            this.toolStripButtonInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonInfo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonInfo.Image")));
            this.toolStripButtonInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInfo.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.toolStripButtonInfo.Name = "toolStripButtonInfo";
            this.toolStripButtonInfo.Size = new System.Drawing.Size(77, 22);
            this.toolStripButtonInfo.Text = "1111111";
            this.toolStripButtonInfo.CheckedChanged += new System.EventHandler(this.toolStripButtonInfo_CheckedChanged);
            // 
            // toolStripButtonWarning
            // 
            this.toolStripButtonWarning.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonWarning.Checked = true;
            this.toolStripButtonWarning.CheckOnClick = true;
            this.toolStripButtonWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonWarning.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWarning.Image")));
            this.toolStripButtonWarning.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWarning.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.toolStripButtonWarning.Name = "toolStripButtonWarning";
            this.toolStripButtonWarning.Size = new System.Drawing.Size(77, 22);
            this.toolStripButtonWarning.Text = "2222222";
            this.toolStripButtonWarning.CheckedChanged += new System.EventHandler(this.toolStripButtonWarning_CheckedChanged);
            // 
            // toolStripButtonError
            // 
            this.toolStripButtonError.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonError.Checked = true;
            this.toolStripButtonError.CheckOnClick = true;
            this.toolStripButtonError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonError.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonError.Image")));
            this.toolStripButtonError.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonError.Name = "toolStripButtonError";
            this.toolStripButtonError.Size = new System.Drawing.Size(98, 22);
            this.toolStripButtonError.Text = "3332222222";
            this.toolStripButtonError.CheckedChanged += new System.EventHandler(this.toolStripButtonError_CheckedChanged);
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.toolStripTextBoxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.toolStripTextBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripTextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(300, 25);
            this.toolStripTextBoxSearch.Enter += new System.EventHandler(this.toolStripTextBoxSearch_Enter);
            this.toolStripTextBoxSearch.Leave += new System.EventHandler(this.toolStripTextBoxSearch_Leave);
            this.toolStripTextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxSearch_KeyDown);
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStripMenuItem4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem4.Text = "匹配大小写（正则）";
            this.ToolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem4_Click);
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStripMenuItem3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem3.Text = "忽略大小写（正则）";
            this.ToolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem2.Text = "匹配大小写";
            this.ToolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStripMenuItem1.Checked = true;
            this.ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem1.Text = "忽略大小写";
            this.ToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // toolStripDropDownButtonHistory
            // 
            this.toolStripDropDownButtonHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripDropDownButtonHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonHistory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1,
            this.ToolStripMenuItem2,
            this.ToolStripMenuItem3,
            this.ToolStripMenuItem4});
            this.toolStripDropDownButtonHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripDropDownButtonHistory.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonHistory.Image")));
            this.toolStripDropDownButtonHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonHistory.Name = "toolStripDropDownButtonHistory";
            this.toolStripDropDownButtonHistory.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonHistory.Text = "搜索模式";
            // 
            // toolStripButtonViewMatch
            // 
            this.toolStripButtonViewMatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonViewMatch.Checked = true;
            this.toolStripButtonViewMatch.CheckOnClick = true;
            this.toolStripButtonViewMatch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonViewMatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonViewMatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonViewMatch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonViewMatch.Image")));
            this.toolStripButtonViewMatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonViewMatch.Name = "toolStripButtonViewMatch";
            this.toolStripButtonViewMatch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonViewMatch.Text = "只显示搜索";
            this.toolStripButtonViewMatch.ToolTipText = "只显示搜索(F12)";
            this.toolStripButtonViewMatch.CheckedChanged += new System.EventHandler(this.toolStripButtonViewMatch_CheckedChanged);
            // 
            // toolStripTab
            // 
            this.toolStripTab.AutoSize = false;
            this.toolStripTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripTab.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonViewMatch,
            this.toolStripDropDownButtonHistory,
            this.toolStripTextBoxSearch,
            this.toolStripButtonCancle,
            this.toolStripButtonErrorNext,
            this.toolStripButtonErrorPrev,
            this.toolStripButtonError,
            this.toolStripButtonWarning,
            this.toolStripButtonInfo,
            this.toolStripSeparator1,
            this.toolStripButtonSearchPrev,
            this.toolStripButtonSearchNext,
            this.toolStripButtonCustom});
            this.toolStripTab.Location = new System.Drawing.Point(0, 25);
            this.toolStripTab.Name = "toolStripTab";
            this.toolStripTab.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStripTab.Size = new System.Drawing.Size(894, 25);
            this.toolStripTab.TabIndex = 4;
            this.toolStripTab.Text = "toolStrip1";
            // 
            // toolStripButtonCancle
            // 
            this.toolStripButtonCancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonCancle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCancle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonCancle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCancle.Image")));
            this.toolStripButtonCancle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCancle.Name = "toolStripButtonCancle";
            this.toolStripButtonCancle.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCancle.Text = "X";
            this.toolStripButtonCancle.ToolTipText = "清除搜索";
            this.toolStripButtonCancle.Click += new System.EventHandler(this.toolStripButtonCancle_Click);
            // 
            // toolStripButtonErrorNext
            // 
            this.toolStripButtonErrorNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonErrorNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonErrorNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonErrorNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonErrorNext.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonErrorNext.Image")));
            this.toolStripButtonErrorNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonErrorNext.Name = "toolStripButtonErrorNext";
            this.toolStripButtonErrorNext.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonErrorNext.Text = "下一个错误日志";
            this.toolStripButtonErrorNext.ToolTipText = "下一个错误日志(F8)";
            this.toolStripButtonErrorNext.Click += new System.EventHandler(this.toolStripButtonErrorNext_Click);
            // 
            // toolStripButtonErrorPrev
            // 
            this.toolStripButtonErrorPrev.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonErrorPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonErrorPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonErrorPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonErrorPrev.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonErrorPrev.Image")));
            this.toolStripButtonErrorPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonErrorPrev.Name = "toolStripButtonErrorPrev";
            this.toolStripButtonErrorPrev.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonErrorPrev.Text = "上一个错误日志";
            this.toolStripButtonErrorPrev.ToolTipText = "上一个错误日志(F7)";
            this.toolStripButtonErrorPrev.Click += new System.EventHandler(this.toolStripButtonErrorPrev_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSearchPrev
            // 
            this.toolStripButtonSearchPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonSearchPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearchPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonSearchPrev.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearchPrev.Image")));
            this.toolStripButtonSearchPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearchPrev.Name = "toolStripButtonSearchPrev";
            this.toolStripButtonSearchPrev.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearchPrev.Text = "上一个搜索日志";
            this.toolStripButtonSearchPrev.ToolTipText = "上一个搜索日志(Shitf+F3)";
            this.toolStripButtonSearchPrev.Click += new System.EventHandler(this.toolStripButtonSearchPrev_Click);
            // 
            // toolStripButtonSearchNext
            // 
            this.toolStripButtonSearchNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonSearchNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearchNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonSearchNext.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearchNext.Image")));
            this.toolStripButtonSearchNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearchNext.Name = "toolStripButtonSearchNext";
            this.toolStripButtonSearchNext.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearchNext.Text = "下一个搜索日志";
            this.toolStripButtonSearchNext.ToolTipText = "下一个搜索日志(F3)";
            this.toolStripButtonSearchNext.Click += new System.EventHandler(this.toolStripButtonSearchNext_Click);
            // 
            // toolStripButtonCustom
            // 
            this.toolStripButtonCustom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonCustom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCustom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCustom.Image")));
            this.toolStripButtonCustom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCustom.Name = "toolStripButtonCustom";
            this.toolStripButtonCustom.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCustom.Text = "自定义过滤";
            this.toolStripButtonCustom.Click += new System.EventHandler(this.toolStripButtonCustom_Click);
            // 
            // darkToolStripAdb
            // 
            this.darkToolStripAdb.AutoSize = false;
            this.darkToolStripAdb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkToolStripAdb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkToolStripAdb.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.darkToolStripAdb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonAdbCon,
            this.toolStripButtonAdbRefresh,
            this.toolStripDropDownButtonAdbDevices,
            this.toolStripButtonPicAdbLog,
            this.toolStripButtonClearAdbLog,
            this.toolStripButtonResumeAdbLog,
            this.toolStripButtonPauseAdbLog});
            this.darkToolStripAdb.Location = new System.Drawing.Point(0, 0);
            this.darkToolStripAdb.Name = "darkToolStripAdb";
            this.darkToolStripAdb.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.darkToolStripAdb.Size = new System.Drawing.Size(894, 25);
            this.darkToolStripAdb.TabIndex = 7;
            this.darkToolStripAdb.Text = "toolStrip1";
            // 
            // toolStripDropDownButtonAdbCon
            // 
            this.toolStripDropDownButtonAdbCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripDropDownButtonAdbCon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAdbConLocal,
            this.toolStripMenuItemAdbConMu,
            this.toolStripMenuItemAdbConYe,
            this.toolStripMenuItemAdbConXiao,
            this.toolStripSeparator2,
            this.toolStripTextBoxAdbConIp});
            this.toolStripDropDownButtonAdbCon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripDropDownButtonAdbCon.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonAdbCon.Image")));
            this.toolStripDropDownButtonAdbCon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonAdbCon.Name = "toolStripDropDownButtonAdbCon";
            this.toolStripDropDownButtonAdbCon.Size = new System.Drawing.Size(85, 22);
            this.toolStripDropDownButtonAdbCon.Text = "连接本机";
            // 
            // toolStripMenuItemAdbConLocal
            // 
            this.toolStripMenuItemAdbConLocal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripMenuItemAdbConLocal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripMenuItemAdbConLocal.Name = "toolStripMenuItemAdbConLocal";
            this.toolStripMenuItemAdbConLocal.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemAdbConLocal.Text = "连接本机";
            this.toolStripMenuItemAdbConLocal.Click += new System.EventHandler(this.toolStripMenuItemAdbConLocal_Click);
            // 
            // toolStripMenuItemAdbConMu
            // 
            this.toolStripMenuItemAdbConMu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripMenuItemAdbConMu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripMenuItemAdbConMu.Name = "toolStripMenuItemAdbConMu";
            this.toolStripMenuItemAdbConMu.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemAdbConMu.Text = "连接MuMu模拟器";
            this.toolStripMenuItemAdbConMu.Click += new System.EventHandler(this.toolStripMenuItemAdbConMu_Click);
            // 
            // toolStripMenuItemAdbConYe
            // 
            this.toolStripMenuItemAdbConYe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripMenuItemAdbConYe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripMenuItemAdbConYe.Name = "toolStripMenuItemAdbConYe";
            this.toolStripMenuItemAdbConYe.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemAdbConYe.Text = "连接夜神模拟器";
            this.toolStripMenuItemAdbConYe.Click += new System.EventHandler(this.toolStripMenuItemAdbConYe_Click);
            // 
            // toolStripMenuItemAdbConXiao
            // 
            this.toolStripMenuItemAdbConXiao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripMenuItemAdbConXiao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripMenuItemAdbConXiao.Name = "toolStripMenuItemAdbConXiao";
            this.toolStripMenuItemAdbConXiao.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemAdbConXiao.Text = "连接逍遥模拟器";
            this.toolStripMenuItemAdbConXiao.Click += new System.EventHandler(this.toolStripMenuItemAdbConXiao_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripTextBoxAdbConIp
            // 
            this.toolStripTextBoxAdbConIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripTextBoxAdbConIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxAdbConIp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripTextBoxAdbConIp.Name = "toolStripTextBoxAdbConIp";
            this.toolStripTextBoxAdbConIp.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripButtonAdbRefresh
            // 
            this.toolStripButtonAdbRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonAdbRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonAdbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdbRefresh.Image")));
            this.toolStripButtonAdbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdbRefresh.Name = "toolStripButtonAdbRefresh";
            this.toolStripButtonAdbRefresh.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonAdbRefresh.Text = "刷新Adb设备";
            this.toolStripButtonAdbRefresh.Click += new System.EventHandler(this.toolStripButtonAdbRefresh_Click);
            // 
            // toolStripDropDownButtonAdbDevices
            // 
            this.toolStripDropDownButtonAdbDevices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripDropDownButtonAdbDevices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripDropDownButtonAdbDevices.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonAdbDevices.Image")));
            this.toolStripDropDownButtonAdbDevices.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonAdbDevices.Name = "toolStripDropDownButtonAdbDevices";
            this.toolStripDropDownButtonAdbDevices.Size = new System.Drawing.Size(73, 22);
            this.toolStripDropDownButtonAdbDevices.Text = "空设备";
            // 
            // toolStripButtonPicAdbLog
            // 
            this.toolStripButtonPicAdbLog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonPicAdbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonPicAdbLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonPicAdbLog.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPicAdbLog.Image")));
            this.toolStripButtonPicAdbLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPicAdbLog.Name = "toolStripButtonPicAdbLog";
            this.toolStripButtonPicAdbLog.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonPicAdbLog.Text = "截屏";
            this.toolStripButtonPicAdbLog.Click += new System.EventHandler(this.toolStripButtonPicAdbLog_Click);
            // 
            // toolStripButtonPauseAdbLog
            // 
            this.toolStripButtonPauseAdbLog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonPauseAdbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonPauseAdbLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonPauseAdbLog.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPauseAdbLog.Image")));
            this.toolStripButtonPauseAdbLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPauseAdbLog.Name = "toolStripButtonPauseAdbLog";
            this.toolStripButtonPauseAdbLog.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonPauseAdbLog.Text = "暂停接收日志";
            this.toolStripButtonPauseAdbLog.Click += new System.EventHandler(this.toolStripButtonPauseAdbLog_Click);
            // 
            // toolStripButtonResumeAdbLog
            // 
            this.toolStripButtonResumeAdbLog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonResumeAdbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonResumeAdbLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonResumeAdbLog.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonResumeAdbLog.Image")));
            this.toolStripButtonResumeAdbLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonResumeAdbLog.Name = "toolStripButtonResumeAdbLog";
            this.toolStripButtonResumeAdbLog.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonResumeAdbLog.Text = "继续接收日志";
            this.toolStripButtonResumeAdbLog.Click += new System.EventHandler(this.toolStripButtonResumeAdbLog_Click);
            // 
            // toolStripButtonClearAdbLog
            // 
            this.toolStripButtonClearAdbLog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonClearAdbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripButtonClearAdbLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripButtonClearAdbLog.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClearAdbLog.Image")));
            this.toolStripButtonClearAdbLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearAdbLog.Name = "toolStripButtonClearAdbLog";
            this.toolStripButtonClearAdbLog.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonClearAdbLog.Text = "清除日志";
            this.toolStripButtonClearAdbLog.Click += new System.EventHandler(this.toolStripButtonClearAdbLog_Click);
            // 
            // DocLogFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripTab);
            this.Controls.Add(this.darkToolStripAdb);
            this.Name = "DocLogFile";
            this.Size = new System.Drawing.Size(894, 639);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).EndInit();
            this.toolStripTab.ResumeLayout(false);
            this.toolStripTab.PerformLayout();
            this.darkToolStripAdb.ResumeLayout(false);
            this.darkToolStripAdb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripProgressBar statusProgress;
        private DarkUI.Controls.DarkStatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelPage;
        private System.Windows.Forms.RichTextBox richTextBoxStrace;
        private System.Windows.Forms.ImageList imageListLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView1;
        private System.Windows.Forms.ToolStripButton toolStripButtonInfo;
        private System.Windows.Forms.ToolStripButton toolStripButtonWarning;
        private System.Windows.Forms.ToolStripButton toolStripButtonError;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonHistory;
        private System.Windows.Forms.ToolStripButton toolStripButtonViewMatch;
        private DarkUI.Controls.DarkToolStrip toolStripTab;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private BrightIdeasSoftware.HeaderFormatStyle headerFormatStyleLog;
        private BrightIdeasSoftware.HighlightTextRenderer highlightTextRendererLog;
        private System.Windows.Forms.ToolStripButton toolStripButtonErrorNext;
        private System.Windows.Forms.ToolStripButton toolStripButtonErrorPrev;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearchPrev;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearchNext;
        private System.Windows.Forms.ToolStripButton toolStripButtonCustom;
        private DarkUI.Controls.DarkToolStrip darkToolStripAdb;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonAdbCon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdbConLocal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdbConMu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdbConYe;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdbConXiao;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxAdbConIp;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdbRefresh;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonAdbDevices;
        private System.Windows.Forms.ToolStripButton toolStripButtonPicAdbLog;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearAdbLog;
        private System.Windows.Forms.ToolStripButton toolStripButtonResumeAdbLog;
        private System.Windows.Forms.ToolStripButton toolStripButtonPauseAdbLog;
    }
}
