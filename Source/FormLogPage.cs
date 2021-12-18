using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace LogViewer
{
    public partial class FormLogPage : Form
    {
        internal LogFile Log { get; set; }

        public FormLogPage()
        {
            InitializeComponent();
        }

        public FastObjectListView GetFastObjectListView()
        {
            return this.fastObjectListView1;
        }

        public ToolStripStatusLabel GetToolStripStatusLabel()
        {
            return this.statusLabelPage;
        }

        public ToolStripProgressBar GetToolStripProgressBar()
        {
            return this.statusProgress;
        }

        public void SetTypeCount()
        {
            this.toolStripButtonInfo.Text = Log.TypeInfoCount.ToString();
            this.toolStripButtonWarning.Text = Log.TypeWarningCount.ToString();
            this.toolStripButtonError.Text = Log.TypeErrorCount.ToString();
        }

        private void statusProgress_Click(object sender, EventArgs e)
        {
            Log.OnProgressCancel();
        }

        private void fastObjectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.richTextBoxStrace.Clear();
            if (Log.List != null)
            {
                var selectedObjects = Log.List.SelectedObjects;
                if (selectedObjects.Count == 1)
                {
                    this.richTextBoxStrace.Text = Log.GetLineStackTrace(((LogLine)selectedObjects[0]).LineNumber);
                }
            }
        }

        private void AppendText(string text, Color color)
        {
            var box = this.richTextBoxStrace;
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        private void toolStripButtonInfo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButtonWarning_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButtonError_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButtonCancle_Click(object sender, EventArgs e)
        {
            TextMatchFilter filter = TextMatchFilter.Contains(Log.List, "Si");
            Log.List.ModelFilter = filter;
            Log.List.DefaultRenderer = new HighlightTextRenderer(filter);
        }

        private void toolStripTextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Perform search
            }
        }
    }
}
