namespace LogViewer
{
    partial class FormCustomTerms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.darkSectionPanel2 = new DarkUI.Controls.DarkSectionPanel();
            this.darkListViewTerms = new DarkUI.Controls.DarkListView();
            this.darkContextMenu1 = new DarkUI.Controls.DarkContextMenu();
            this.ToolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.darkButtonAdd = new DarkUI.Controls.DarkButton();
            this.darkComboBoxAdd = new DarkUI.Controls.DarkComboBox();
            this.darkTextBoxAdd = new DarkUI.Controls.DarkTextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.darkSectionPanel2.SuspendLayout();
            this.darkContextMenu1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.darkSectionPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.panel1.Size = new System.Drawing.Size(512, 339);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.darkSectionPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(492, 246);
            this.panel3.TabIndex = 1;
            // 
            // darkSectionPanel2
            // 
            this.darkSectionPanel2.Controls.Add(this.darkListViewTerms);
            this.darkSectionPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkSectionPanel2.Location = new System.Drawing.Point(0, 0);
            this.darkSectionPanel2.Name = "darkSectionPanel2";
            this.darkSectionPanel2.SectionHeader = "过滤列表";
            this.darkSectionPanel2.Size = new System.Drawing.Size(492, 246);
            this.darkSectionPanel2.TabIndex = 0;
            // 
            // darkListViewTerms
            // 
            this.darkListViewTerms.ContextMenuStrip = this.darkContextMenu1;
            this.darkListViewTerms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkListViewTerms.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkListViewTerms.Location = new System.Drawing.Point(1, 25);
            this.darkListViewTerms.MultiSelect = true;
            this.darkListViewTerms.Name = "darkListViewTerms";
            this.darkListViewTerms.Size = new System.Drawing.Size(490, 220);
            this.darkListViewTerms.TabIndex = 0;
            // 
            // darkContextMenu1
            // 
            this.darkContextMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkContextMenu1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemDel});
            this.darkContextMenu1.Name = "darkContextMenu1";
            this.darkContextMenu1.Size = new System.Drawing.Size(101, 26);
            // 
            // ToolStripMenuItemDel
            // 
            this.ToolStripMenuItemDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStripMenuItemDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripMenuItemDel.Name = "ToolStripMenuItemDel";
            this.ToolStripMenuItemDel.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItemDel.Text = "删除";
            this.ToolStripMenuItemDel.Click += new System.EventHandler(this.ToolStripMenuItemDel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.darkSectionPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 83);
            this.panel2.TabIndex = 0;
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.Controls.Add(this.darkButtonAdd);
            this.darkSectionPanel1.Controls.Add(this.darkComboBoxAdd);
            this.darkSectionPanel1.Controls.Add(this.darkTextBoxAdd);
            this.darkSectionPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkSectionPanel1.Location = new System.Drawing.Point(0, 0);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = "新增过滤";
            this.darkSectionPanel1.Size = new System.Drawing.Size(492, 83);
            this.darkSectionPanel1.TabIndex = 0;
            // 
            // darkButtonAdd
            // 
            this.darkButtonAdd.AutoSize = true;
            this.darkButtonAdd.Location = new System.Drawing.Point(398, 34);
            this.darkButtonAdd.Name = "darkButtonAdd";
            this.darkButtonAdd.Padding = new System.Windows.Forms.Padding(5);
            this.darkButtonAdd.Size = new System.Drawing.Size(75, 39);
            this.darkButtonAdd.TabIndex = 2;
            this.darkButtonAdd.Text = "新增";
            this.darkButtonAdd.Click += new System.EventHandler(this.darkButtonAdd_Click);
            // 
            // darkComboBoxAdd
            // 
            this.darkComboBoxAdd.DisplayMember = "213123";
            this.darkComboBoxAdd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.darkComboBoxAdd.Items.AddRange(new object[] {
            "忽略大小写",
            "匹配大小写",
            "忽略大小写（正则）",
            "匹配大小写（正则）"});
            this.darkComboBoxAdd.Location = new System.Drawing.Point(227, 41);
            this.darkComboBoxAdd.Name = "darkComboBoxAdd";
            this.darkComboBoxAdd.Size = new System.Drawing.Size(148, 26);
            this.darkComboBoxAdd.TabIndex = 1;
            // 
            // darkTextBoxAdd
            // 
            this.darkTextBoxAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkTextBoxAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkTextBoxAdd.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkTextBoxAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkTextBoxAdd.Location = new System.Drawing.Point(14, 41);
            this.darkTextBoxAdd.Name = "darkTextBoxAdd";
            this.darkTextBoxAdd.Size = new System.Drawing.Size(187, 23);
            this.darkTextBoxAdd.TabIndex = 0;
            // 
            // FormCustomTerms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(512, 381);
            this.Controls.Add(this.panel1);
            this.DialogButtons = DarkUI.Forms.DarkDialogButton.OkCancel;
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(528, 419);
            this.Name = "FormCustomTerms";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自定义过滤";
            this.Load += new System.EventHandler(this.FormCustomTerms_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.darkSectionPanel2.ResumeLayout(false);
            this.darkContextMenu1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.darkSectionPanel1.ResumeLayout(false);
            this.darkSectionPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel2;
        private DarkUI.Controls.DarkListView darkListViewTerms;
        private System.Windows.Forms.Panel panel2;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkButton darkButtonAdd;
        private DarkUI.Controls.DarkComboBox darkComboBoxAdd;
        private DarkUI.Controls.DarkTextBox darkTextBoxAdd;
        private DarkUI.Controls.DarkContextMenu darkContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDel;
    }
}