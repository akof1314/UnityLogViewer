using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;

namespace LogViewer
{
    public partial class FormCustomTerms : DarkDialog
    {
        private Configuration config;
        private List<KeyValuePair<string, int>> listPairs;

        public FormCustomTerms(Configuration config)
        {
            InitializeComponent();
            btnOk.Text = "确定";
            btnOk.Click += BtnOkOnClick;
            btnOk.AutoSize = true;
            btnCancel.Text = "取消";
            btnCancel.AutoSize = true;
            this.config = config;

            foreach (Control control in Controls)
            {
                if (control.Name == "pnlFooter")
                {
                    Panel pnlFooter = (Panel) control;
                    if (pnlFooter != null)
                    {
                        pnlFooter.Size = new Size(767, 56);
                    }
                    break;
                }
            }

            listPairs = new List<KeyValuePair<string, int>>();
            for (var i = 0; i < config.SearchTerms.Length; i++)
            {
                listPairs.Add(new KeyValuePair<string, int>(config.SearchTerms[i], config.SearchTypes[i]));
                var shortText = config.SearchTerms[i];
                if (shortText.Length > 10)
                {
                    shortText = shortText.Substring(0, 10);
                }

                var showText = $"{shortText.PadRight(12)} {config.SearchTerms[i].PadRight(30)} {this.darkComboBoxAdd.Items[config.SearchTypes[i]]}";
                var item = new DarkListItem(showText);
                darkListViewTerms.Items.Add(item);
            }
        }

        private void FormCustomTerms_Load(object sender, EventArgs e)
        {
            this.darkComboBoxAdd.SelectedIndex = 0;
        }

        private void BtnOkOnClick(object sender, EventArgs e)
        {
            List<string> searchTerms = new List<string>();
            List<int> searchTypes = new List<int>();
            foreach (var pair in listPairs)
            {
                searchTerms.Add(pair.Key);
                searchTypes.Add(pair.Value);
            }

            this.config.SearchTerms = searchTerms.ToArray();
            this.config.SearchTypes = searchTypes.ToArray();
        }

        private void darkButtonAdd_Click(object sender, EventArgs e)
        {
            var searchText = this.darkTextBoxAdd.Text;
            if (string.IsNullOrEmpty(searchText))
            {
                DarkMessageBox.ShowError("请输入新增的搜索内容", "提示");
                return;
            }

            foreach (var pair in listPairs)
            {
                if (this.darkTextBoxAdd.Text == pair.Key)
                {
                    DarkMessageBox.ShowError("新增的搜索内容已存在", "提示");
                    return;
                }
            }

            listPairs.Add(new KeyValuePair<string, int>(searchText, this.darkComboBoxAdd.SelectedIndex));
            var shortText = searchText;
            if (shortText.Length > 10)
            {
                shortText = shortText.Substring(0, 10);
            }

            var showText = $"{shortText.PadRight(12)} {searchText.PadRight(30)} {this.darkComboBoxAdd.Items[this.darkComboBoxAdd.SelectedIndex]}";
            var item = new DarkListItem(showText);
            this.darkListViewTerms.Items.Add(item);
            var idx = this.darkListViewTerms.GetItemIndex(item);
            if (idx > -1)
            {
                this.darkListViewTerms.SelectItem(idx);
            }
            this.darkTextBoxAdd.Text = String.Empty;
        }

        private void ToolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            var items = this.darkListViewTerms.SelectedIndices;
            items.Sort();
            for (int i = items.Count - 1; i >= 0; i--)
            {
                listPairs.RemoveAt(items[i]);
                this.darkListViewTerms.Items.RemoveAt(items[i]);
            }
        }
    }
}
