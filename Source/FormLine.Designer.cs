using DarkUI.Controls;

namespace LogViewer
{
    partial class FormLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLine));
            this.buttonClose = new DarkUI.Controls.DarkButton();
            this.darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.textLine = new System.Windows.Forms.RichTextBox();
            this.darkSectionPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.AutoSize = true;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(485, 198);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonClose.Size = new System.Drawing.Size(75, 35);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "关闭";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.darkSectionPanel1.Controls.Add(this.textLine);
            this.darkSectionPanel1.Location = new System.Drawing.Point(12, 12);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = null;
            this.darkSectionPanel1.Size = new System.Drawing.Size(548, 180);
            this.darkSectionPanel1.TabIndex = 2;
            // 
            // textLine
            // 
            this.textLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.textLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLine.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textLine.HideSelection = false;
            this.textLine.Location = new System.Drawing.Point(1, 25);
            this.textLine.Name = "textLine";
            this.textLine.ReadOnly = true;
            this.textLine.Size = new System.Drawing.Size(546, 154);
            this.textLine.TabIndex = 1;
            this.textLine.Text = "";
            // 
            // FormLine
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(572, 245);
            this.Controls.Add(this.darkSectionPanel1);
            this.Controls.Add(this.buttonClose);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(533, 250);
            this.Name = "FormLine";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "行内容";
            this.darkSectionPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkButton buttonClose;
        private DarkSectionPanel darkSectionPanel1;
        private System.Windows.Forms.RichTextBox textLine;
    }
}