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

        /// <summary>
        /// 设置日志类型数量显示
        /// </summary>
        public void SetTypeCount()
        {
            this.toolStripButtonInfo.Text = Log.TypeInfoCount.ToString();
            this.toolStripButtonWarning.Text = Log.TypeWarningCount.ToString();
            this.toolStripButtonError.Text = Log.TypeErrorCount.ToString();
        }

        /// <summary>
        /// 搜索模式
        /// </summary>
        /// <returns></returns>
        public Global.SearchType GetSearchType()
        {
            if (this.ToolStripMenuItem2.Checked)
            {
                return Global.SearchType.SubStringCaseSensitive;
            }
            if (this.ToolStripMenuItem3.Checked)
            {
                return Global.SearchType.RegexCaseInsensitive;
            }
            if (this.ToolStripMenuItem4.Checked)
            {
                return Global.SearchType.RegexCaseSensitive;
            }
            return Global.SearchType.SubStringCaseInsensitive;
        }

        /// <summary>
        /// 是否只显示搜索内容
        /// </summary>
        /// <returns></returns>
        public bool IsShowMatch()
        {
            return this.toolStripButtonViewMatch.Checked;
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
            this.toolStripTextBoxSearch.Text = String.Empty;
            Log.OnSearchBegin(String.Empty);
        }

        private void toolStripTextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Perform search
                Log.OnSearchBegin(this.toolStripTextBoxSearch.Text);
                this.toolStripTextBoxSearch.AutoCompleteCustomSource.Add(this.toolStripTextBoxSearch.Text);
            }
        }

        private void toolStripButtonViewMatch_CheckedChanged(object sender, EventArgs e)
        {
            if (this.toolStripButtonViewMatch.Checked)
            {
                Log.List.ModelFilter = new ModelFilter(delegate (object x)
                {
                    return x != null && (((LogLine)x).SearchMatches.Intersect(Log.FilterIds).Any() == true || (((LogLine)x).IsContextLine == true));
                });

                if (Log.List.DefaultRenderer is HighlightTextRenderer high && high.Filter == null)
                {
                    var sc2 = Log.Searches.Items.Find(sc => sc.Id == Log.FilterIds[0]);
                    if (sc2 != null)
                    {
                        high.Filter = TextMatchFilter.Contains(Log.List, sc2.Pattern);
                    }
                }
            }
            else
            {
                Log.List.ModelFilter = null;
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ToolStripMenuItem1.Checked = true;
            this.ToolStripMenuItem2.Checked = false;
            this.ToolStripMenuItem3.Checked = false;
            this.ToolStripMenuItem4.Checked = false;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.ToolStripMenuItem1.Checked = false;
            this.ToolStripMenuItem2.Checked = true;
            this.ToolStripMenuItem3.Checked = false;
            this.ToolStripMenuItem4.Checked = false;
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.ToolStripMenuItem1.Checked = false;
            this.ToolStripMenuItem2.Checked = false;
            this.ToolStripMenuItem3.Checked = true;
            this.ToolStripMenuItem4.Checked = false;
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.ToolStripMenuItem1.Checked = false;
            this.ToolStripMenuItem2.Checked = false;
            this.ToolStripMenuItem3.Checked = false;
            this.ToolStripMenuItem4.Checked = true;
        }
    }
}
