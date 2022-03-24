using System;
using System.Drawing;
using System.Windows.Forms;
using BrightIdeasSoftware;
using DarkUI.Docking;
using woanware;

namespace LogViewer
{
    public partial class DocLogFile : DarkDocument
    {
        internal LogFile Log { get; set; }
        internal AdbClient adb { get; set; }
        internal NetClient udp { get; set; }
        private Configuration config;
        private bool searchHasText;
        private HighlightTextColorRenderer highlightTextRendererLog;
        private const string CUSTOMSEARCH = "toolStripButtonCustom";
        private static Font listFont;
        private static System.Drawing.Text.PrivateFontCollection pfc;

        public DocLogFile()
        {
            InitializeComponent();
            InitListFont();
            this.toolStripTextBoxSearch.SelectedSuggest += ToolStripTextBoxSearchOnSelectedSuggest;
            this.toolStripTextBoxUdpPm.SelectedSuggest += ToolStripTextBoxUdpPmOnSelectedSuggest;
            SetSearchTip();
            //InitDpi();
        }

        public DocLogFile(string text)
            : this()
        {
            DockText = text;
        }

        public void ClearObjects()
        {
            if (adb != null)
            {
                adb.ClearObjects();
            }
            if (udp != null)
            {
                udp.ClearObjects();
            }
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
            if (config.SplitterDistance > 0)
            {
                this.splitContainer1.SplitterDistance = config.SplitterDistance;
            }
            AllSearchTerms();
            SetMatchColor();
            this.darkToolStripAdb.Visible = Log.IsAdbLog;
            this.darkToolStripUdp.Visible = Log.IsUdpLog;
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

        public void SetAdbStart()
        {
            if (adb != null)
            {
                throw new Exception("重复创建");
            }
            if (Log.IsAdbLog)
            {
                ClearAdbDevicesList();
                DisconnectAdbDevice();
                GetToolStripStatusLabel().Text = "查找设备中...";

                adb = new AdbClient(this);
                adb.GetDevices();
            }
        }

        public void SetUdpStart()
        {
            if (udp != null)
            {
                throw new Exception("重复创建");
            }
            if (Log.IsUdpLog)
            {
                DisconnectUdpDevice();
                this.toolStripTextBoxEndPoint.Text = config.UdpIpAddress;
                udp = new NetClient(this);
                udp.SetEndPoint(config.UdpIpAddress, config.UdpIpPort);
            }
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

        public void SetSearchFocus()
        {
            this.toolStripTextBoxSearch.Focus();
        }

        /// <summary>
        /// 设置日志类型勾选
        /// </summary>
        public void SetTypeChecked(Global.LogType logType)
        {
            if (logType == Global.LogType.Info)
            {
                this.toolStripButtonInfo.Checked = !this.toolStripButtonInfo.Checked;
            }
            else if (logType == Global.LogType.Warning)
            {
                this.toolStripButtonWarning.Checked = !this.toolStripButtonWarning.Checked;
            }
        }

        public void ClearStackTraceText()
        {
            this.richTextBoxStrace.Clear();
        }

        private void statusProgress_Click(object sender, EventArgs e)
        {
            Log.OnProgressCancel();
        }

        private void InitDpi()
        {
            var allSize = this.statusStrip.Size.Height + this.toolStripTab.Size.Height;
            this.statusStrip.Size = new Size(this.statusStrip.Size.Width,
                Convert.ToInt32(this.statusStrip.Size.Height * DeviceDpi / 96f));
            this.toolStripTab.Size = new Size(this.toolStripTab.Size.Width,
                Convert.ToInt32(this.toolStripTab.Size.Height * DeviceDpi / 96f));
            
            var ma = this.splitContainer1.Panel2.Padding;
            ma.Bottom = ma.Bottom + Convert.ToInt32(allSize * (DeviceDpi / 96f - 1f));
            this.splitContainer1.Panel2.Padding = ma;
        }

        private void InitListFont()
        {
            highlightTextRendererLog = new HighlightTextColorRenderer();
            highlightTextRendererLog.UseRoundedRectangle = false;   // 匹配框是矩形，而不是圆角

            if (listFont == null)
            {
                var path = System.IO.Path.Combine(Misc.GetApplicationDirectory(), "YaHei.Consolas.ttf");
                if (System.IO.File.Exists(path))
                {
                    try
                    {
                        pfc = new System.Drawing.Text.PrivateFontCollection();
                        pfc.AddFontFile(path);//字体文件的路径
                        listFont = new Font(pfc.Families[0], 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        highlightTextRendererLog.UseGdiTextRendering = false; // 使用GDI+更清晰，但是查找字符的时候，需要字体包含中文，否则定位不到位置
                        //this.richTextBoxStrace.Font = listFont; 不要设置rich的字体，会导致行间距变大
                    }
                    catch (System.Exception)
                    {
                        // ignored
                    }
                }

                if (listFont == null)
                {
                    //listFont = new Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    listFont = this.richTextBoxStrace.Font; // 一样的字体
                }
            }

            this.fastObjectListView1.Font = listFont;
        }

        private void fastObjectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.richTextBoxStrace.Clear();
            if (Log.List != null)
            {
                var selectedObjects = Log.List.SelectedObjects;
                if (selectedObjects.Count == 1)
                {
                    //this.richTextBoxStrace.Text = Log.GetLineStackTrace(((LogLine)selectedObjects[0]).LineNumber);
                    Log.ShowLineStackTrace(((LogLine)selectedObjects[0]).LineNumber);
                }
            }
        }

        public void StackTraceAppendText(string text)
        {
            StackTraceAppendText(text, this.richTextBoxStrace.ForeColor);
        }

        public void StackTraceAppendText(string text, Color color)
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

                foreach (string autoText in this.toolStripTextBoxSearch.AutoCompleteCustomSource)
                {
                    if (autoText == this.toolStripTextBoxSearch.Text)
                    {
                        return;
                    }
                }
                this.toolStripTextBoxSearch.AutoCompleteCustomSource.Add(this.toolStripTextBoxSearch.Text);
            }
        }

        private void ToolStripTextBoxSearchOnSelectedSuggest(object sender, EventArgs e)
        {
            if (!searchHasText)
            {
                this.toolStripTextBoxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            }
            //Perform search
            Log.CurSearch.Pattern = this.toolStripTextBoxSearch.Text;
            Log.CurSearch.Type = this.GetSearchType();
            Log.OnSearchBegin();
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

        /// <summary>
        /// 拆分器滑动后，保存滑动距离
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (config != null)
            {
                config.SplitterDistance = this.splitContainer1.SplitterDistance;
            }
        }

        #region ADB

        /// <summary>
        /// 刷新设备列表
        /// </summary>
        public void RefreshAdbDevicesList()
        {
            ClearAdbDevicesList();

            var idx = 0;
            foreach (var deviceName in adb.DevicesNameList)
            {
                var item = new System.Windows.Forms.ToolStripMenuItem();
                item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
                item.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
                item.Name = "ToolStripMenuItem" + idx++;
                item.Size = new System.Drawing.Size(184, 22);
                item.Text = deviceName;
                item.Click += new System.EventHandler(this.toolStripButtonAdbChooseDevice_Click);
                this.toolStripDropDownButtonAdbDevices.DropDownItems.Add(item);
            }
            GetToolStripStatusLabel().Text = "发现设备数量： " + adb.DevicesNameList.Count;

            if (adb.DevicesNameList.Count > 0)
            {
                ChooseAdbDevice(0);
            }
        }

        private void ClearAdbDevicesList()
        {
            this.toolStripDropDownButtonAdbDevices.Text = "空设备";
            this.toolStripDropDownButtonAdbDevices.DropDownItems.Clear();
        }

        private void ChooseAdbDevice(int idx)
        {
            adb.IsPausing = false;
            DisconnectAdbDevice();
            this.toolStripDropDownButtonAdbDevices.Text = adb.DevicesNameList[idx];
            GetToolStripStatusLabel().Text = "尝试连接设备： " + this.toolStripDropDownButtonAdbDevices.Text;
            adb.ChooseDevice(idx);
        }

        public void DisconnectAdbDevice()
        {
            GetToolStripStatusLabel().Text = "设备断开连接 ";
            this.toolStripButtonPauseAdbLog.Visible = false;
            this.toolStripButtonResumeAdbLog.Visible = false;
            this.toolStripButtonClearAdbLog.Visible = false;
            this.toolStripButtonPicAdbLog.Visible = false;
        }

        public void ConnectAdbDevice()
        {
            adb.IsPausing = false;
            this.toolStripButtonPauseAdbLog.Visible = true;
            this.toolStripButtonResumeAdbLog.Visible = false;
            this.toolStripButtonClearAdbLog.Visible = true;
            this.toolStripButtonPicAdbLog.Visible = true;
            GetToolStripStatusLabel().Text = "连接设备中： " + this.toolStripDropDownButtonAdbDevices.Text;
        }

        public void TipConnectText(string tipText)
        {
            GetToolStripStatusLabel().Text = tipText;
        }

        /// <summary>
        /// 选择某个设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAdbChooseDevice_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem btn)
            {
                if (this.toolStripDropDownButtonAdbDevices.Text == btn.Name)
                {
                    return;
                }

                var idx = adb.DevicesNameList.IndexOf(btn.Text);
                if (idx > -1)
                {
                    ChooseAdbDevice(idx);
                }
            }
        }

        private void toolStripButtonAdbRefresh_Click(object sender, EventArgs e)
        {
            GetToolStripStatusLabel().Text = "刷新设备中...";
            adb.GetDevices();
        }

        private void toolStripMenuItemAdbConLocal_Click(object sender, EventArgs e)
        {
            adb.SetConnect("127.0.0.1:5555");
        }

        private void toolStripMenuItemAdbConMu_Click(object sender, EventArgs e)
        {
            adb.SetConnect("127.0.0.1:7555");
        }

        private void toolStripMenuItemAdbConYe_Click(object sender, EventArgs e)
        {
            adb.SetConnect("127.0.0.1:62001");
        }

        private void toolStripMenuItemAdbConXiao_Click(object sender, EventArgs e)
        {
            adb.SetConnect("127.0.0.1:21503");
        }

        private void toolStripButtonPicAdbLog_Click(object sender, EventArgs e)
        {
            adb.GetScreenCap();
        }

        private void toolStripButtonPauseAdbLog_Click(object sender, EventArgs e)
        {
            adb.IsPausing = true;
            this.toolStripButtonPauseAdbLog.Visible = false;
            this.toolStripButtonResumeAdbLog.Visible = true;
        }

        private void toolStripButtonResumeAdbLog_Click(object sender, EventArgs e)
        {
            adb.IsPausing = false;
            this.toolStripButtonPauseAdbLog.Visible = true;
            this.toolStripButtonResumeAdbLog.Visible = false;
        }

        private void toolStripButtonClearAdbLog_Click(object sender, EventArgs e)
        {
            Log.ClearAdbLines();
        }

        private void toolStripTextBoxAdbConIp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                adb.SetConnect(this.toolStripTextBoxAdbConIp.Text);
            }
        }

        #endregion

        #region UDP

        public void DisconnectUdpDevice()
        {
            GetToolStripStatusLabel().Text = "目标断开连接 ";
            this.toolStripButtonPauseUdpLog.Visible = false;
            this.toolStripButtonResumeUdpLog.Visible = false;
            this.toolStripButtonClearUdpLog.Visible = false;
            this.toolStripLabelUdpPm.Visible = false;
            this.toolStripTextBoxUdpPm.Visible = false;
            this.toolStripButtonPicUdpLog.Visible = false;
        }

        public void ConnectUdpDevice()
        {
            udp.IsPausing = false;
            this.toolStripButtonPauseUdpLog.Visible = true;
            this.toolStripButtonResumeUdpLog.Visible = false;
            this.toolStripButtonClearUdpLog.Visible = true;
            this.toolStripLabelUdpPm.Visible = true;
            this.toolStripTextBoxUdpPm.Visible = true;
            this.toolStripButtonPicUdpLog.Visible = true;
            GetToolStripStatusLabel().Text = "连接目标中： " + this.toolStripTextBoxEndPoint.Text;
        }

        private void toolStripTextBoxEndPoint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (udp.SetEndPoint(this.toolStripTextBoxEndPoint.Text, config.UdpIpPort))
                {
                    config.UdpIpAddress = this.toolStripTextBoxEndPoint.Text;
                }
            }
        }

        private void toolStripButtonConEndPoint_Click(object sender, EventArgs e)
        {
            if (udp.SetEndPoint(this.toolStripTextBoxEndPoint.Text, config.UdpIpPort))
            {
                config.UdpIpAddress = this.toolStripTextBoxEndPoint.Text;
            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var pmStr = this.toolStripTextBoxUdpPm.Text.Trim();
                if (!string.IsNullOrEmpty(pmStr))
                {
                    udp.SendShellMsg(pmStr);

                    foreach (string autoText in this.toolStripTextBoxUdpPm.AutoCompleteCustomSource)
                    {
                        if (autoText == pmStr)
                        {
                            return;
                        }
                    }
                    this.toolStripTextBoxUdpPm.AutoCompleteCustomSource.Add(pmStr);
                }
            }
        }

        private void ToolStripTextBoxUdpPmOnSelectedSuggest(object sender, EventArgs e)
        {
            var pmStr = this.toolStripTextBoxUdpPm.Text.Trim();
            if (!string.IsNullOrEmpty(pmStr))
            {
                udp.SendShellMsg(pmStr);
            }
        }

        private void toolStripButtonPauseUdpLog_Click(object sender, EventArgs e)
        {
            udp.IsPausing = true;
            this.toolStripButtonPauseUdpLog.Visible = false;
            this.toolStripButtonResumeUdpLog.Visible = true;
        }

        private void toolStripButtonResumeUdpLog_Click(object sender, EventArgs e)
        {
            udp.IsPausing = false;
            this.toolStripButtonPauseUdpLog.Visible = true;
            this.toolStripButtonResumeUdpLog.Visible = false;
        }

        private void toolStripButtonClearUdpLog_Click(object sender, EventArgs e)
        {
            Log.ClearAdbLines();
        }

        private void toolStripButtonPicUdpLog_Click(object sender, EventArgs e)
        {
            udp.GetScreenCap();
        }

        #endregion
    }
}
