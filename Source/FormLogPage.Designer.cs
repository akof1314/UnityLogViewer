namespace LogViewer
{
    partial class FormLogPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogPage));
            this.toolStripTab = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonError = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWarning = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInfo = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fastObjectListView1 = new BrightIdeasSoftware.FastObjectListView();
            this.richTextBoxStrace = new System.Windows.Forms.RichTextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabelPage = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageListLog = new System.Windows.Forms.ImageList(this.components);
            this.toolStripButtonCancle = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonHistory = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButtonViewMatch = new System.Windows.Forms.ToolStripButton();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripTab
            // 
            this.toolStripTab.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonViewMatch,
            this.toolStripDropDownButtonHistory,
            this.toolStripTextBoxSearch,
            this.toolStripButtonCancle,
            this.toolStripSeparator2,
            this.toolStripButtonError,
            this.toolStripButtonWarning,
            this.toolStripButtonInfo});
            this.toolStripTab.Location = new System.Drawing.Point(0, 0);
            this.toolStripTab.Name = "toolStripTab";
            this.toolStripTab.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripTab.Size = new System.Drawing.Size(879, 25);
            this.toolStripTab.TabIndex = 1;
            this.toolStripTab.Text = "toolStrip1";
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.toolStripTextBoxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(300, 25);
            this.toolStripTextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxSearch_KeyDown);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonError
            // 
            this.toolStripButtonError.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonError.Checked = true;
            this.toolStripButtonError.CheckOnClick = true;
            this.toolStripButtonError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonError.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonError.Image")));
            this.toolStripButtonError.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonError.Name = "toolStripButtonError";
            this.toolStripButtonError.Size = new System.Drawing.Size(49, 22);
            this.toolStripButtonError.Text = "333";
            this.toolStripButtonError.CheckedChanged += new System.EventHandler(this.toolStripButtonError_CheckedChanged);
            // 
            // toolStripButtonWarning
            // 
            this.toolStripButtonWarning.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonWarning.Checked = true;
            this.toolStripButtonWarning.CheckOnClick = true;
            this.toolStripButtonWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonWarning.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWarning.Image")));
            this.toolStripButtonWarning.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWarning.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.toolStripButtonWarning.Name = "toolStripButtonWarning";
            this.toolStripButtonWarning.Size = new System.Drawing.Size(49, 22);
            this.toolStripButtonWarning.Text = "222";
            this.toolStripButtonWarning.CheckedChanged += new System.EventHandler(this.toolStripButtonWarning_CheckedChanged);
            // 
            // toolStripButtonInfo
            // 
            this.toolStripButtonInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonInfo.Checked = true;
            this.toolStripButtonInfo.CheckOnClick = true;
            this.toolStripButtonInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonInfo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonInfo.Image")));
            this.toolStripButtonInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInfo.Margin = new System.Windows.Forms.Padding(0, 1, 1, 2);
            this.toolStripButtonInfo.Name = "toolStripButtonInfo";
            this.toolStripButtonInfo.Size = new System.Drawing.Size(35, 22);
            this.toolStripButtonInfo.Text = "1";
            this.toolStripButtonInfo.CheckedChanged += new System.EventHandler(this.toolStripButtonInfo_CheckedChanged);
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
            this.splitContainer1.Size = new System.Drawing.Size(879, 532);
            this.splitContainer1.SplitterDistance = 365;
            this.splitContainer1.TabIndex = 2;
            // 
            // fastObjectListView1
            // 
            this.fastObjectListView1.CellEditUseWholeCell = false;
            this.fastObjectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fastObjectListView1.HideSelection = false;
            this.fastObjectListView1.Location = new System.Drawing.Point(0, 0);
            this.fastObjectListView1.Name = "fastObjectListView1";
            this.fastObjectListView1.ShowGroups = false;
            this.fastObjectListView1.Size = new System.Drawing.Size(879, 365);
            this.fastObjectListView1.SmallImageList = this.imageListLog;
            this.fastObjectListView1.TabIndex = 0;
            this.fastObjectListView1.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView1.View = System.Windows.Forms.View.Details;
            this.fastObjectListView1.VirtualMode = true;
            this.fastObjectListView1.SelectedIndexChanged += new System.EventHandler(this.fastObjectListView1_SelectedIndexChanged);
            // 
            // richTextBoxStrace
            // 
            this.richTextBoxStrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxStrace.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxStrace.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxStrace.Name = "richTextBoxStrace";
            this.richTextBoxStrace.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.richTextBoxStrace.Size = new System.Drawing.Size(879, 143);
            this.richTextBoxStrace.TabIndex = 0;
            this.richTextBoxStrace.Text = "";
            this.richTextBoxStrace.WordWrap = false;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusProgress,
            this.statusLabelPage});
            this.statusStrip.Location = new System.Drawing.Point(0, 535);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip.Size = new System.Drawing.Size(879, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusProgress
            // 
            this.statusProgress.Name = "statusProgress";
            this.statusProgress.Size = new System.Drawing.Size(67, 16);
            this.statusProgress.Visible = false;
            this.statusProgress.Click += new System.EventHandler(this.statusProgress_Click);
            // 
            // statusLabelPage
            // 
            this.statusLabelPage.Name = "statusLabelPage";
            this.statusLabelPage.Size = new System.Drawing.Size(0, 17);
            // 
            // imageListLog
            // 
            this.imageListLog.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLog.ImageStream")));
            this.imageListLog.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLog.Images.SetKeyName(0, "1 (1).png");
            this.imageListLog.Images.SetKeyName(1, "1 (2).png");
            this.imageListLog.Images.SetKeyName(2, "1 (3).png");
            // 
            // toolStripButtonCancle
            // 
            this.toolStripButtonCancle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCancle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCancle.Image")));
            this.toolStripButtonCancle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCancle.Name = "toolStripButtonCancle";
            this.toolStripButtonCancle.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCancle.Text = "X";
            this.toolStripButtonCancle.ToolTipText = "清除搜索";
            this.toolStripButtonCancle.Click += new System.EventHandler(this.toolStripButtonCancle_Click);
            // 
            // toolStripDropDownButtonHistory
            // 
            this.toolStripDropDownButtonHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonHistory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1,
            this.ToolStripMenuItem2,
            this.ToolStripMenuItem3,
            this.ToolStripMenuItem4});
            this.toolStripDropDownButtonHistory.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonHistory.Image")));
            this.toolStripDropDownButtonHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonHistory.Name = "toolStripDropDownButtonHistory";
            this.toolStripDropDownButtonHistory.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonHistory.Text = "搜索模式";
            // 
            // toolStripButtonViewMatch
            // 
            this.toolStripButtonViewMatch.Checked = true;
            this.toolStripButtonViewMatch.CheckOnClick = true;
            this.toolStripButtonViewMatch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonViewMatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonViewMatch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonViewMatch.Image")));
            this.toolStripButtonViewMatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonViewMatch.Name = "toolStripButtonViewMatch";
            this.toolStripButtonViewMatch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonViewMatch.Text = "只显示搜索";
            this.toolStripButtonViewMatch.CheckedChanged += new System.EventHandler(this.toolStripButtonViewMatch_CheckedChanged);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Checked = true;
            this.ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem1.Text = "忽略大小写";
            this.ToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem2.Text = "匹配大小写";
            this.ToolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem3.Text = "忽略大小写（正则）";
            this.ToolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3_Click);
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItem4.Text = "匹配大小写（正则）";
            this.ToolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem4_Click);
            // 
            // FormLogPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 557);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripTab);
            this.Name = "FormLogPage";
            this.Text = "FormLogPage";
            this.toolStripTab.ResumeLayout(false);
            this.toolStripTab.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripTab;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonError;
        private System.Windows.Forms.ToolStripButton toolStripButtonWarning;
        private System.Windows.Forms.ToolStripButton toolStripButtonInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView1;
        private System.Windows.Forms.RichTextBox richTextBoxStrace;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar statusProgress;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelPage;
        private System.Windows.Forms.ImageList imageListLog;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancle;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonHistory;
        private System.Windows.Forms.ToolStripButton toolStripButtonViewMatch;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem4;
    }
}