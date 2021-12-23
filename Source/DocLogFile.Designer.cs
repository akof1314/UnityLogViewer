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
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle4 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle5 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle6 = new BrightIdeasSoftware.HeaderStateStyle();
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.highlightTextRendererLog = new BrightIdeasSoftware.HighlightTextRenderer();
            this.toolStripButtonSearchPrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearchNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonErrorPrev = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonErrorNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCustom = new System.Windows.Forms.ToolStripButton();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).BeginInit();
            this.toolStripTab.SuspendLayout();
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
            this.richTextBoxStrace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxStrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxStrace.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxStrace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.richTextBoxStrace.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxStrace.Name = "richTextBoxStrace";
            this.richTextBoxStrace.Size = new System.Drawing.Size(894, 169);
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
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
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.splitContainer1.Size = new System.Drawing.Size(894, 614);
            this.splitContainer1.SplitterDistance = 421;
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
            this.fastObjectListView1.Size = new System.Drawing.Size(894, 421);
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
            headerStateStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(77)))), ((int)(((byte)(95)))));
            headerStateStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.headerFormatStyleLog.Hot = headerStateStyle4;
            headerStateStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            headerStateStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.headerFormatStyleLog.Normal = headerStateStyle5;
            this.headerFormatStyleLog.Pressed = headerStateStyle6;
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
            this.toolStripTextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxSearch_KeyDown);
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStripMenuItem4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem4.Text = "匹配大小写（正则）";
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStripMenuItem3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem3.Text = "忽略大小写（正则）";
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem2.Text = "匹配大小写";
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
            this.toolStripTab.Location = new System.Drawing.Point(0, 0);
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
            // 
            // DocLogFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripTab);
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
    }
}
