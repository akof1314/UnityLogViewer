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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogPage));
            this.toolStripTab = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
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
            this.toolStripTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBoxSearch,
            this.toolStripSeparator2,
            this.toolStripButtonError,
            this.toolStripButtonWarning,
            this.toolStripButtonInfo});
            this.toolStripTab.Location = new System.Drawing.Point(0, 0);
            this.toolStripTab.Name = "toolStripTab";
            this.toolStripTab.Size = new System.Drawing.Size(879, 25);
            this.toolStripTab.TabIndex = 1;
            this.toolStripTab.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "过滤";
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(300, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonError
            // 
            this.toolStripButtonError.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonError.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonError.Image")));
            this.toolStripButtonError.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonError.Name = "toolStripButtonError";
            this.toolStripButtonError.Size = new System.Drawing.Size(49, 22);
            this.toolStripButtonError.Text = "333";
            // 
            // toolStripButtonWarning
            // 
            this.toolStripButtonWarning.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonWarning.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWarning.Image")));
            this.toolStripButtonWarning.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWarning.Name = "toolStripButtonWarning";
            this.toolStripButtonWarning.Size = new System.Drawing.Size(49, 22);
            this.toolStripButtonWarning.Text = "222";
            // 
            // toolStripButtonInfo
            // 
            this.toolStripButtonInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonInfo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonInfo.Image")));
            this.toolStripButtonInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInfo.Name = "toolStripButtonInfo";
            this.toolStripButtonInfo.Size = new System.Drawing.Size(35, 22);
            this.toolStripButtonInfo.Text = "1";
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
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxStrace);
            this.splitContainer1.Size = new System.Drawing.Size(879, 532);
            this.splitContainer1.SplitterDistance = 365;
            this.splitContainer1.TabIndex = 2;
            // 
            // fastObjectListView1
            // 
            this.fastObjectListView1.CellEditUseWholeCell = false;
            this.fastObjectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastObjectListView1.HideSelection = false;
            this.fastObjectListView1.Location = new System.Drawing.Point(0, 0);
            this.fastObjectListView1.Name = "fastObjectListView1";
            this.fastObjectListView1.ShowGroups = false;
            this.fastObjectListView1.Size = new System.Drawing.Size(879, 365);
            this.fastObjectListView1.TabIndex = 0;
            this.fastObjectListView1.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView1.View = System.Windows.Forms.View.Details;
            this.fastObjectListView1.VirtualMode = true;
            // 
            // richTextBoxStrace
            // 
            this.richTextBoxStrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxStrace.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxStrace.Name = "richTextBoxStrace";
            this.richTextBoxStrace.Size = new System.Drawing.Size(879, 163);
            this.richTextBoxStrace.TabIndex = 0;
            this.richTextBoxStrace.Text = "";
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
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
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
    }
}