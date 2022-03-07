using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using woanware;
using System.Threading;
using DarkUI.Docking;
using DarkUI.Forms;
using System.Text;

namespace LogViewer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormMain : DarkForm
    {
        #region Member Variables
        private readonly SynchronizationContext synchronizationContext;
        private CancellationTokenSource cancellationTokenSource;
        private HourGlass hourGlass;
        private bool processing;
        private Color highlightColour = Color.Lime;
        private Color contextColour = Color.LightGray;
        private Configuration config;
        private Dictionary<string, LogFile> logs;
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            synchronizationContext = SynchronizationContext.Current;
            logs = new Dictionary<string, LogFile>();

        }
        #endregion

        #region Form Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.config = new Configuration();
            string ret = this.config.Load();
            if (ret.Length > 0)
            {
                Global.ShowErrorDialog(ret);
            }

            this.highlightColour = config.GetHighlightColour();
            this.contextColour = config.GetContextColour();
            if (config.FormSize.Length > 0)
            {
                this.Size = new Size(config.FormSize[0], config.FormSize[1]);
            }
            if (this.Width > Screen.PrimaryScreen.WorkingArea.Width)
            {
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            }
            if (this.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            }
            if (config.FormMaximized)
            {
                WindowState = FormWindowState.Maximized;
            }
            LogFile.Constants.Init();

            menuFileClose.Enabled = false;
            this.darkDockPanelMain.ContentRemoved += DarkDockPanelMainOnContentRemoved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var list = darkDockPanelMain.GetDocuments();
            foreach (var darkDockContent in list)
            {
                this.darkDockPanelMain.RemoveContent(darkDockContent);
            }

            config.FormMaximized = WindowState == FormWindowState.Maximized;
            if (WindowState == FormWindowState.Normal)
            {
                config.FormSize = new[] { Size.Width, Size.Height };
            }
            else
            {
                config.FormSize = new[] { RestoreBounds.Size.Width, RestoreBounds.Size.Height };
            }
            config.HighlightColour = this.highlightColour.ToKnownColor().ToString();
            string ret = config.Save();
            if (ret.Length > 0)
            {
                Global.ShowErrorDialog(ret);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            if (processing == true)
            {
                return;
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 0)
            {
                return;
            }

            if (files.Length > 1)
            {
                Global.ShowErrorDialog("一次只能处理一个文件");
                return;
            }

            LoadFile(files[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (processing == true)
            {
                return;
            }

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.F))
            {
                var tag = this.darkDockPanelMain.ActiveContent;
                DocLogFile doc = tag as DocLogFile;
                if (doc == null)
                {
                    return;
                }
                doc.SetSearchFocus();
            }
            else if (e.KeyCode == Keys.F3 && e.Shift)
            {
                var tag = this.darkDockPanelMain.ActiveContent;
                DocLogFile doc = tag as DocLogFile;
                if (doc == null)
                {
                    return;
                }
                doc.Log.SetGoLine(false, false);
            }
            else if (e.KeyCode == Keys.F3)
            {
                var tag = this.darkDockPanelMain.ActiveContent;
                DocLogFile doc = tag as DocLogFile;
                if (doc == null)
                {
                    return;
                }
                doc.Log.SetGoLine(false, true);
            }
            else if (e.KeyCode == Keys.F12)
            {
                var tag = this.darkDockPanelMain.ActiveContent;
                DocLogFile doc = tag as DocLogFile;
                if (doc == null)
                {
                    return;
                }
                doc.SetShowMatch(!doc.IsShowMatch());
            }
            else if (e.KeyCode == Keys.F7)
            {
                var tag = this.darkDockPanelMain.ActiveContent;
                DocLogFile doc = tag as DocLogFile;
                if (doc == null)
                {
                    return;
                }
                doc.Log.SetGoLine(true, false);
            }
            else if (e.KeyCode == Keys.F8)
            {
                var tag = this.darkDockPanelMain.ActiveContent;
                DocLogFile doc = tag as DocLogFile;
                if (doc == null)
                {
                    return;
                }
                doc.Log.SetGoLine(true, true);
            }
            else if (e.KeyCode == Keys.F5)
            {
                var tag = this.darkDockPanelMain.ActiveContent;
                DocLogFile doc = tag as DocLogFile;
                if (doc == null)
                {
                    return;
                }
                doc.SetTypeChecked(Global.LogType.Info);
            }
            else if (e.KeyCode == Keys.F6)
            {
                var tag = this.darkDockPanelMain.ActiveContent;
                DocLogFile doc = tag as DocLogFile;
                if (doc == null)
                {
                    return;
                }
                doc.SetTypeChecked(Global.LogType.Warning);
            }
        }

        private void DarkDockPanelMainOnContentRemoved(object sender, DockContentEventArgs e)
        {
            DocLogFile doc = e.Content as DocLogFile;
            if (doc == null)
            {
                return;
            }

            LogFile lf = doc.Log;
            lf.ProgressUpdate -= LogFile_LoadProgress;
            lf.ProgressCancel -= LogFile_LoadProgressCancel;
            lf.LoadComplete -= LogFile_LoadComplete;
            lf.SearchComplete -= LogFile_SearchComplete;
            lf.ExportComplete -= LogFile_ExportComplete;
            lf.LoadError -= LogFile_LoadError;
            lf.SearchBegin -= LogFile_SearchBegin;
            lf.List.ItemActivate -= (this.listLines_ItemActivate);
            lf.List.DragDrop -= (this.listLines_DragDrop);
            lf.List.DragEnter -= (this.listLines_DragEnter);
            logs.Remove(lf.Guid);
            lf.List.ClearObjects();
            lf.Dispose();
            if (logs.Count == 0)
            {
                menuFileClose.Enabled = false;
            }
        }
        #endregion

        #region Log File Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private void LoadFile(string filePath, int logType = 0)
        {
            this.processing = true;
            this.hourGlass = new HourGlass(this);
            SetProcessingState(false);
            this.cancellationTokenSource = new CancellationTokenSource();

            {
                LogFile lf = new LogFile();
                logs.Add(lf.Guid, lf);

                if (logType == 1)
                {
                    lf.IsAdbLog = true;
                }
                else if (logType == 2)
                {
                    lf.IsUdpLog = true;
                }

                this.darkDockPanelMain.AddContent(lf.Initialise(filePath));
                lf.pageForm.SetConfig(config);
                lf.pageForm.GetToolStripProgressBar().Visible = true;
                lf.SetContextMenu(contextMenu);
                lf.ViewMode = Global.ViewMode.Standard;
                lf.ProgressUpdate += LogFile_LoadProgress;
                lf.ProgressCancel += LogFile_LoadProgressCancel;
                lf.LoadComplete += LogFile_LoadComplete;
                lf.SearchComplete += LogFile_SearchComplete;
                lf.ExportComplete += LogFile_ExportComplete;
                lf.LoadError += LogFile_LoadError;
                lf.SearchBegin += LogFile_SearchBegin;
                lf.List.ItemActivate += new EventHandler(this.listLines_ItemActivate);
                lf.List.DragDrop += new DragEventHandler(this.listLines_DragDrop);
                lf.List.DragEnter += new DragEventHandler(this.listLines_DragEnter);
                lf.Load(filePath, synchronizationContext, cancellationTokenSource.Token);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        private void Export(string filePath)
        {
            this.processing = true;
            this.hourGlass = new HourGlass(this);
            SetProcessingState(false);
            this.cancellationTokenSource = new CancellationTokenSource();

            var tag = this.darkDockPanelMain.ActiveContent;
            DocLogFile doc = tag as DocLogFile;
            if (doc == null)
            {
                return;
            }
            doc.GetToolStripProgressBar().Visible = true;

            if (doc.Log.List.ModelFilter == null)
            {
                doc.Log.Export(filePath, cancellationTokenSource.Token);
            }
            else
            {
                doc.Log.Export(doc.Log.List.FilteredObjects, filePath, cancellationTokenSource.Token);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        private void ExportSelected(string filePath)
        {
            this.processing = true;
            this.hourGlass = new HourGlass(this);
            SetProcessingState(false);
            this.cancellationTokenSource = new CancellationTokenSource();

            var tag = this.darkDockPanelMain.ActiveContent;
            DocLogFile doc = tag as DocLogFile;
            if (doc == null)
            {
                return;
            }
            doc.GetToolStripProgressBar().Visible = true;
            doc.Log.Export(doc.Log.List.SelectedObjects, filePath, cancellationTokenSource.Token);
        }
        #endregion

        #region Log File Object Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        private void LogFile_LoadError(LogFile lf, string fileName, string message)
        {
            Global.ShowErrorDialog(message + " (" + fileName + ")");

            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                lf.pageForm.GetToolStripProgressBar().Visible = false;
                this.hourGlass.Dispose();
                SetProcessingState(true);
                this.cancellationTokenSource.Dispose();
                this.processing = false;

                // Lets clear the LogFile state and set the UI correctly
                menuFileClose_Click(this, null);

            }), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="percent"></param>
        private void LogFile_LoadProgress(LogFile lf, int percent)
        {
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                lf.pageForm.GetToolStripProgressBar().Value = (int)o;
            }), percent);
        }

        private void LogFile_LoadProgressCancel(LogFile lf, int percent)
        {
            this.cancellationTokenSource.Cancel();
        }

        private void LogFile_SearchBegin(LogFile lf)
        {
            this.processing = true;
            this.hourGlass = new HourGlass(this);
            SetProcessingState(false);
            lf.pageForm.GetToolStripProgressBar().Visible = true;
            this.cancellationTokenSource = new CancellationTokenSource();
            lf.Search(cancellationTokenSource.Token, config.NumContextLines);
        }

        /// <summary>
        /// 
        /// </summary>
        private void LogFile_SearchComplete(LogFile lf, string fileName, TimeSpan duration, long matches, int numTerms, bool cancelled)
        {
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                lf.SetSearchEnd();
                this.hourGlass.Dispose();
                SetProcessingState(true);
                this.cancellationTokenSource.Dispose();
                UpdateStatusLabel("找到 " + matches + " 条数据， 花费时间： " + duration + " (" + fileName + ")", lf.pageForm.GetToolStripStatusLabel());

                this.processing = false;

            }), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        private void LogFile_ExportComplete(LogFile lf, string fileName, TimeSpan duration, bool val)
        {
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                lf.pageForm.GetToolStripProgressBar().Visible = false;
                this.hourGlass.Dispose();
                SetProcessingState(true);
                this.cancellationTokenSource.Dispose();
                UpdateStatusLabel("导出完成，花费时间： " + duration + " (" + fileName + ")", lf.pageForm.GetToolStripStatusLabel());
                this.processing = false;
            }), null);
        }

        /// <summary>
        /// 
        /// </summary>
        private void LogFile_LoadComplete(LogFile lf, string fileName, TimeSpan duration, bool cancelled)
        {
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                lf.List.SetObjects(lf.Lines);
                lf.ResizeWidth();

                //lf.List.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                lf.pageForm.GetToolStripProgressBar().Visible = false;
                lf.pageForm.SetTypeCount();

                SetProcessingState(true);
                this.cancellationTokenSource.Dispose();
                UpdateStatusLabel(lf.Lines.Count + " 行，花费时间： " + duration + " (" + fileName + ")", lf.pageForm.GetToolStripStatusLabel());
                menuFileClose.Enabled = true;
                this.hourGlass.Dispose();
                this.processing = false;
                lf.pageForm.SetAdbStart();
                lf.pageForm.SetUdpStart();

            }), null);
        }
        #endregion

        #region List Event Handlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listLines_DragEnter(object sender, DragEventArgs e)
        {
            if (processing == true)
            {
                return;
            }

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listLines_DragDrop(object sender, DragEventArgs e)
        {
            if (processing == true)
            {
                return;
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 0)
            {
                return;
            }

            if (files.Length > 1)
            {
                Global.ShowErrorDialog("一次只能处理一个文件");
                return;
            }

            LoadFile(files[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listLines_ItemActivate(object sender, EventArgs e)
        {
            var lv = (FastObjectListView)sender;
            if (lv.SelectedObjects.Count != 1)
            {
                return;
            }

            LogFile lf = logs[lv.Tag.ToString()];
            LogLine ll = (LogLine)lv.SelectedObjects[0];
            using (FormLine f = new FormLine(lf.GetLine(ll.LineNumber)))
            {
                f.ShowDialog(this);
            }
        }
        #endregion

        #region Context Menu Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuFilterClear_Click(object sender, EventArgs e)
        {
            var tag = this.darkDockPanelMain.ActiveContent;
            DocLogFile doc = tag as DocLogFile;
            doc?.SetShowMatch(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuFilterShowMatched_Click(object sender, EventArgs e)
        {
            var tag = this.darkDockPanelMain.ActiveContent;
            DocLogFile doc = tag as DocLogFile;
            doc?.SetShowMatch(true);
        }

        private void ToolStripMenuItemMatchColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = false;
            cd.AllowFullOpen = false;
            cd.Color = config.GetMatchColour();
            cd.CustomColors = new[] { ColorTranslator.ToOle(config.GetMatchColour()), ColorTranslator.ToOle(Color.DarkOrange) };
            DialogResult dr = cd.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            config.MatchColour = cd.Color.ToKnownColor().ToString();
            var tag = this.darkDockPanelMain.ActiveContent;
            DocLogFile doc = tag as DocLogFile;
            doc?.SetMatchColor();
            doc.Log.List.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuExportAll_Click(object sender, EventArgs e)
        {
            var tag = this.darkDockPanelMain.ActiveContent;
            DocLogFile doc = tag as DocLogFile;
            if (doc == null)
            {
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "所有文件|*.*";
            sfd.FileName = "导出" + doc.DockText;
            sfd.Title = "选择导出文件";

            if (sfd.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            Export(sfd.FileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuExportSelected_Click(object sender, EventArgs e)
        {
            var tag = this.darkDockPanelMain.ActiveContent;
            DocLogFile doc = tag as DocLogFile;
            if (doc == null)
            {
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "所有文件|*.*";
            sfd.FileName = "导出选择项" + doc.DockText;
            sfd.Title = "选择导出文件";

            if (sfd.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            ExportSelected(sfd.FileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuCopy_Click(object sender, EventArgs e)
        {
            var tag = this.darkDockPanelMain.ActiveContent;
            DocLogFile doc = tag as DocLogFile;
            if (doc == null)
            {
                return;
            }

            LogFile lf = doc.Log;
            StringBuilder sb = new StringBuilder();
            foreach (LogLine ll in lf.List.SelectedObjects)
            {
                sb.AppendLine(lf.GetLine(ll.LineNumber));
            }

            Clipboard.SetText(sb.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextLinesGoToLine_Click(object sender, EventArgs e)
        {
            using (FormGoToLine f = new FormGoToLine())
            {
                DialogResult dr = f.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                var tag = this.darkDockPanelMain.ActiveContent;
                DocLogFile doc = tag as DocLogFile;
                if (doc == null)
                {
                    return;
                }

                LogFile lf = doc.Log;

                lf.List.EnsureVisible(f.LineNumber - 1);
                var ll = lf.Lines.SingleOrDefault(x => x.LineNumber == f.LineNumber);
                if (ll != null)
                {
                    lf.List.SelectedIndex = ll.LineNumber - 1;
                    if (lf.List.SelectedItem != null)
                    {
                        lf.List.FocusedItem = lf.List.SelectedItem;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextLinesGoToFirstLine_Click(object sender, EventArgs e)
        {
            var tag = this.darkDockPanelMain.ActiveContent;
            DocLogFile doc = tag as DocLogFile;
            if (doc == null)
            {
                return;
            }

            LogFile lf = doc.Log;

            lf.List.EnsureVisible(0);
            lf.List.SelectedIndex = 0;
            if (lf.List.SelectedItem != null)
            {
                lf.List.FocusedItem = lf.List.SelectedItem;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextLinesGoToLastLine_Click(object sender, EventArgs e)
        {
            var tag = this.darkDockPanelMain.ActiveContent;
            DocLogFile doc = tag as DocLogFile;
            if (doc == null)
            {
                return;
            }

            LogFile lf = doc.Log;

            lf.List.EnsureVisible(lf.LineCount - 1);
            lf.List.SelectedIndex = lf.LineCount - 1;
            if (lf.List.SelectedItem != null)
            {
                lf.List.FocusedItem = lf.List.SelectedItem;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
        #endregion

        #region Menu Event Handlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileOpenNewTab_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            openFileDialog.FileName = "*.*";
            openFileDialog.Title = "选择日志文件";

            if (openFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            LoadFile(openFileDialog.FileName);
        }

        private void menuFileOpenUnityLogTab_Click(object sender, EventArgs e)
        {
            var dir = @"C:\Users\Administrator\AppData\Local\Unity\Editor";
            if (!System.IO.Directory.Exists(dir))
            {
                Global.ShowErrorDialog("不存在路径：\n" + dir);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            openFileDialog.FileName = "*.*";
            openFileDialog.Title = "选择日志文件";
            openFileDialog.InitialDirectory = dir;

            if (openFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            LoadFile(openFileDialog.FileName);
        }

        /// <summary>
        /// Close the resources used for opening and processing the log file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileClose_Click(object sender, EventArgs e)
        {
            var tag = this.darkDockPanelMain.ActiveContent;
            this.darkDockPanelMain.RemoveContent(tag);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuHelpHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/akof1314/UnityLogViewer");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            using (FormAbout f = new FormAbout())
            {
                f.ShowDialog(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuToolsConfiguration_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 打开adb日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAdbLogcat_Click(object sender, EventArgs e)
        {
            var list = darkDockPanelMain.GetDocuments();
            foreach (var darkDockContent in list)
            {
                DocLogFile doc = darkDockContent as DocLogFile;
                if (doc == null)
                {
                    continue;
                }

                if (doc.Log.IsAdbLog)
                {
                    darkDockPanelMain.ActiveContent = doc;
                    return;
                }
            }

            string filePath = System.IO.Path.Combine(Misc.GetApplicationDirectory(), "ADB-Unity-日志.log");
            try
            {
                File.WriteAllText(filePath, String.Empty);
                LoadFile(filePath, 1);
            }
            catch (Exception exception)
            {
                Global.ShowErrorDialog(exception.Message);
            }
        }

        /// <summary>
        /// 打开UDP日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuUdpLogcat_Click(object sender, EventArgs e)
        {
            var list = darkDockPanelMain.GetDocuments();
            foreach (var darkDockContent in list)
            {
                DocLogFile doc = darkDockContent as DocLogFile;
                if (doc == null)
                {
                    continue;
                }

                if (doc.Log.IsUdpLog)
                {
                    darkDockPanelMain.ActiveContent = doc;
                    return;
                }
            }

            string filePath = System.IO.Path.Combine(Misc.GetApplicationDirectory(), "UDP-Unity-日志.log");
            try
            {
                File.WriteAllText(filePath, String.Empty);
                LoadFile(filePath, 2);
            }
            catch (Exception exception)
            {
                Global.ShowErrorDialog(exception.Message);
            }
        }

        #endregion

        #region UI Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled"></param>
        private void SetProcessingState(bool enabled)
        {
            MethodInvoker methodInvoker = delegate
            {
                menuFileOpenNewTab.Enabled = enabled;
                menuFileClose.Enabled = enabled;
                menuFileExit.Enabled = enabled;
            };

            if (this.InvokeRequired == true)
            {
                this.BeginInvoke(methodInvoker);
            }
            else
            {
                methodInvoker.Invoke();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled"></param>
        private void UpdateStatusLabel(string text, ToolStripStatusLabel control)
        {
            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                control.Text = (string)o;
            }), text);
        }
        #endregion
    }
}
