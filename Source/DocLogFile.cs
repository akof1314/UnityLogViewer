using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using DarkUI.Docking;

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
                this.toolStripTab.Items.RemoveByKey(CUSTOMSEARCH + i);
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
            btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btn.CheckOnClick = true;
            btn.AutoSize = false;
            btn.Click += new System.EventHandler(this.toolStripButtonCustomIdx_Click);
            this.toolStripTab.Items.Add(btn);
            btn.AutoSize = true;
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
            SetSearchTip();
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

        private void toolStripButtonSearchPrev_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonSearchNext_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonErrorPrev_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonErrorNext_Click(object sender, EventArgs e)
        {

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
                        Console.WriteLine(idx);
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
