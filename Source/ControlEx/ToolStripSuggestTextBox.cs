using System;
using System.Windows.Forms;
using DarkUI.Controls;

namespace LogViewer.ControlEx
{
    class ToolStripSuggestTextBox : ToolStripTextBox
    {
        private DarkListView _listBox;
        private bool _isAdded;
        private String _formerValue = String.Empty;

        public event EventHandler SelectedSuggest;

        public ToolStripSuggestTextBox()
        {
            InitializeComponent();
            ResetListBox();
        }

        private void InitializeComponent()
        {
            _listBox = new DarkListView();
            _listBox.Font = Font;
            _listBox.Height = 150;
            _listBox.DoubleClick += ListBoxOnDoubleClick;
            _listBox.Leave += ListBoxOnLeave;
            this.KeyDown += this_KeyDown;
            this.KeyUp += this_KeyUp;
            this.GotFocus += this_GotFocus;
        }

        private void ListBoxOnLeave(object sender, EventArgs e)
        {
            if (!this.Focused)
            {
                ResetListBox();
            }
        }

        private void ShowListBox()
        {
            if (!_isAdded)
            {
                Parent.Parent.Controls.Add(_listBox);
                _listBox.Left = TextBox.Left;
                _listBox.Top = TextBox.Top + Height;
                _isAdded = true;
            }
            _listBox.Width = Width;
            _listBox.Visible = true;
            _listBox.BringToFront();
        }

        private void ResetListBox()
        {
            _listBox.Visible = false;
        }

        private void ListBoxOnDoubleClick(object sender, EventArgs e)
        {
            if (_listBox.Visible)
            {
                if (_listBox.SelectedIndices.Count > 0)
                {
                    Text = _listBox.Items[_listBox.SelectedIndices[0]].Text;
                }
                ResetListBox();
                _formerValue = Text;
                this.Select(this.Text.Length, 0);

                if (SelectedSuggest != null)
                {
                    SelectedSuggest(this, null);
                }
            }
        }

        private void this_GotFocus(object sender, EventArgs e)
        {
            // 获得焦点的时候，要显示全部的提示框
            UpdateListBox(true);
        }

        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateListBox();
        }

        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                    {
                        if (_listBox.Visible)
                        {
                            if (_listBox.SelectedIndices.Count > 0)
                            {
                                Text = _listBox.Items[_listBox.SelectedIndices[0]].Text;
                            }
                            ResetListBox();
                            _formerValue = Text;
                            this.Select(this.Text.Length, 0);
                            e.Handled = true;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_listBox.Visible))
                        {
                            if (_listBox.SelectedIndices.Count == 0 && _listBox.Items.Count > 0)
                            {
                                _listBox.SelectItem(0);
                            }
                            else if (_listBox.SelectedIndices.Count > 0 &&
                                     _listBox.SelectedIndices[0] < _listBox.Items.Count - 1)
                            {
                                _listBox.SelectItem(_listBox.SelectedIndices[0] + 1);
                            }
                        }
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible))
                        {
                            if (_listBox.SelectedIndices.Count > 0 &&
                                _listBox.SelectedIndices[0] > 0)
                            {
                                _listBox.SelectItem(_listBox.SelectedIndices[0] - 1);
                            }
                        }
                        e.Handled = true;
                        break;
                    }
                case Keys.Escape:
                    ResetListBox();
                    break;
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                    if (_listBox.Visible)
                        return true;
                    else
                        return false;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        private void UpdateListBox(bool isForce = false)
        {
            if (Text == _formerValue && !isForce)
                return;

            _formerValue = this.Text;
            string word = this.Text;

            if (AutoCompleteCustomSource.Count != 0)
            {
                _listBox.Items.Clear();
                foreach (string item in AutoCompleteCustomSource)
                {
                    if (string.IsNullOrEmpty(word) || item.Contains(word))
                    {
                        _listBox.Items.Add(new DarkListItem(item));
                    }
                }

                // 默认不选中，避免回车都取到了选中项
                if (_listBox.Items.Count > 0)
                {
                    ShowListBox();
                    Focus();
                }
                else
                {
                    ResetListBox();
                }
            }
            else
            {
                ResetListBox();
            }
        }

        protected override void OnLeave(EventArgs e)
        { 
            base.OnLeave(e);
            if (!_listBox.Focused)
            {
                ResetListBox();
            }
        }
    }
}
