using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using DarkUI.Docking;
using DarkUI.Forms;

namespace LogViewer
{
    public partial class DocLogFile : DarkDocument
    {
        internal LogFile Log { get; set; }
        private Configuration config;
        private bool searchHasText;
        private const string CUSTOMSEARCH = "toolStripButtonCustom";

        public DocLogFile()
        {
            InitializeComponent();
            SetSearchTip();
        }

        public DocLogFile(string text)
            : this()
        {
            DockText = text;
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

        public HighlightTextRenderer GetHighlightTextRenderer()
        {
            return this.highlightTextRendererLog;
        }

        public void SetConfig(Configuration configuration)
        {
            config = configuration;
            AllSearchTerms();
            SetMatchColor();
        }

        /// <summary>
        /// 设置日志类型数量显示
        /// </summary>
        public void SetTypeCount()
        {
            this.toolStripButtonInfo.Text = Log.TypeInfoCount.ToString();
            this.toolStripButtonWarning.Text = Log.TypeWarningCount.ToString();
            this.toolStripButtonError.Text = Log.TypeErrorCount.ToString();
            this.toolStripButtonInfo.AutoSize = false;
            this.toolStripButtonInfo.AutoSize = true;
            this.toolStripButtonWarning.AutoSize = false;
            this.toolStripButtonWarning.AutoSize = true;
            this.toolStripButtonError.AutoSize = false;
            this.toolStripButtonError.AutoSize = true;
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

        public void SetShowMatch(bool isShow)
        {
            this.toolStripButtonViewMatch.Checked = isShow;
        }

        public void SetMatchColor()
        {
            GetHighlightTextRenderer().FramePen = new Pen(config.GetMatchColour());
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

        private void SetSearchTip()
        {
            if (string.IsNullOrEmpty(this.toolStripTextBoxSearch.Text))
            {
                this.toolStripTextBoxSearch.Text = "键入搜索内容后回车";
                this.toolStripTextBoxSearch.ForeColor = Color.Gray;
                searchHasText = false;
            }
            else
            {
                searchHasText = true;
            }
        }

        private void ClearSearchTerms(int num)
        {
            for (int i = 0; i < num; i++)
            {
                var idx = this.toolStripTab.Items.IndexOfKey(CUSTOMSEARCH + i);
                if (idx > -1)
                {
                    var item = this.toolStripTab.Items[idx];
                    item.Click -= this.toolStripButtonCustomIdx_Click;
                    this.toolStripTab.Items.RemoveAt(idx);
                }
            }
        }

        private void AllSearchTerms()
        {
            for (int i = 0; i < config.SearchTerms.Length; i++)
            {
                AddSearchTerms(i, config.SearchTerms[i]);
            }
        }

        private void AddSearchTerms(int index, string searchText)
        {
            var shortText = searchText;
            if (shortText.Length > 10)
            {
                shortText = shortText.Substring(0, 10);
            }
            var btn = new System.Windows.Forms.ToolStripButton();
            btn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            btn.Name = CUSTOMSEARCH + index;
            btn.Text = shortText;
            btn.ToolTipText = searchText;
            btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btn.CheckOnClick = true;
            btn.AutoSize = false;
            btn.Click += new System.EventHandler(this.toolStripButtonCustomIdx_Click);
            this.toolStripTab.Items.Add(btn);
            btn.AutoSize = true;
            btn.Checked = Log.Searches.IsEnabledNewAdd((Global.SearchType)config.SearchTypes[index], config.SearchTerms[index]);
        }

        private void toolStripButtonInfo_CheckedChanged(object sender, EventArgs e)
        {
            Log.ShowTypeInfo = this.toolStripButtonInfo.Checked;
            Log.SetShowType();
        }

        private void toolStripButtonWarning_CheckedChanged(object sender, EventArgs e)
        {
            Log.ShowTypeWarning = this.toolStripButtonWarning.Checked;
            Log.SetShowType();
        }

        private void toolStripButtonError_CheckedChanged(object sender, EventArgs e)
        {
            Log.ShowTypeError = this.toolStripButtonError.Checked;
            Log.SetShowType();
        }

        private void toolStripButtonCancle_Click(object sender, EventArgs e)
        {
            this.toolStripTextBoxSearch.Text = String.Empty;
            Log.CurSearch.Pattern = String.Empty;
            SetSearchTip();
            Log.OnSearchBegin();
        }

        private void toolStripTextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Perform search
                Log.CurSearch.Pattern = this.toolStripTextBoxSearch.Text;
                Log.CurSearch.Type = this.GetSearchType();
                Log.OnSearchBegin();
                this.toolStripTextBoxSearch.AutoCompleteCustomSource.Add(this.toolStripTextBoxSearch.Text);
            }
        }

        private void toolStripButtonViewMatch_CheckedChanged(object sender, EventArgs e)
        {
            Log.SetShowType();
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

        private void toolStripButtonSearchPrev_Click(object sender, EventArgs e)
        {
            Log.SetGoLine(false, false);
        }

        private void toolStripButtonSearchNext_Click(object sender, EventArgs e)
        {
            Log.SetGoLine(false, true);
        }

        private void toolStripButtonErrorPrev_Click(object sender, EventArgs e)
        {
            Log.SetGoLine(true, false);
        }

        private void toolStripButtonErrorNext_Click(object sender, EventArgs e)
        {
            Log.SetGoLine(true, true);
        }

        private void toolStripButtonCustom_Click(object sender, EventArgs e)
        {
            using (FormCustomTerms f = new FormCustomTerms(config))
            {
                int num = config.SearchTerms.Length;
                DialogResult dr = f.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                ClearSearchTerms(num);
                AllSearchTerms();
            }
        }

        private void toolStripButtonCustomIdx_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton btn)
            {
                if (btn.Name.StartsWith(CUSTOMSEARCH, StringComparison.Ordinal))
                {
                    var str = btn.Name.Substring(CUSTOMSEARCH.Length);
                    if (int.TryParse(str, out var idx))
                    {
                        Log.Searches.SetEnabled((Global.SearchType)config.SearchTypes[idx], config.SearchTerms[idx], btn.Checked);
                        Log.OnSearchBegin();
                    }
                }
            }
        }

        private void toolStripTextBoxSearch_Enter(object sender, EventArgs e)
        {
            if (!searchHasText)
            {
                this.toolStripTextBoxSearch.Text = string.Empty;
                this.toolStripTextBoxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            }
        }

        private void toolStripTextBoxSearch_Leave(object sender, EventArgs e)
        {
            SetSearchTip();
        }

    }
}
