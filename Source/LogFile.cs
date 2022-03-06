using BrightIdeasSoftware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogViewer
{
    /// <summary>
    /// 
    /// </summary>
    internal class LogFile
    {
        #region Delegates

        public delegate void SearchBeginEvent(LogFile lf);

        public delegate void SearchCompleteEvent(LogFile lf, string fileName, TimeSpan duration, long matches,
            int numSearchTerms, bool cancelled);

        public delegate void CompleteEvent(LogFile lf, string fileName, TimeSpan duration, bool cancelled);

        public delegate void BoolEvent(string fileName, bool val);

        public delegate void MessageEvent(LogFile lf, string fileName, string message);

        public delegate void ProgressUpdateEvent(LogFile lf, int percent);

        #endregion

        #region Events

        public event SearchBeginEvent SearchBegin;
        public event SearchCompleteEvent SearchComplete;
        public event CompleteEvent LoadComplete;
        public event CompleteEvent ExportComplete;
        public event ProgressUpdateEvent ProgressUpdate;
        public event MessageEvent LoadError;
        public event ProgressUpdateEvent ProgressCancel;

        #endregion



        #region Member Variables

        private Color highlightColour { get; set; } = Color.Lime;
        private Color contextColour { get; set; } = Color.LightGray;
        public Searches Searches { get; set; } // 所有搜索自定义过滤
        public Global.ViewMode ViewMode { get; set; } = Global.ViewMode.Standard;
        public List<LogLine> Lines { get; private set; } = new List<LogLine>(); // 所有行
        public LogLine LongestLine { get; private set; } = new LogLine(); // 最长的行
        public int LineCount { get; private set; } = 0; //总行数
        private FileStream fileStream; // 文件流
        private Mutex readMutex = new Mutex();
        public string FileName { get; private set; } // 文件名
        public SearchCriteria CurSearch { get; set; } = new SearchCriteria();
        public FastObjectListView List { get; set; }
        public string Guid { get; private set; }
        public DocLogFile pageForm { get; private set; }
        public int TypeInfoCount { get; private set; }
        public int TypeWarningCount { get; private set; }
        public int TypeErrorCount { get; private set; }
        public bool ShowTypeInfo { get; set; } = true;
        public bool ShowTypeWarning { get; set; } = true;
        public bool ShowTypeError { get; set; } = true;
        public bool IsAdbLog { get; set; } = false;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public LogFile()
        {
            this.Guid = System.Guid.NewGuid().ToString();
            this.Searches = new Searches();
            CurSearch.Id = ushort.MaxValue - 2;
        }

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ct"></param>
        public void Load(string filePath, SynchronizationContext st, CancellationToken ct)
        {
            this.FileName = Path.GetFileName(filePath);

            Task.Run(() =>
            {

                DateTime start = DateTime.Now;
                bool cancelled = false;
                bool error = false;
                try
                {
                    byte[] tempBuffer = new byte[1024 * 1024];

                    this.fileStream = new FileStream(filePath, FileMode.Open,
                        IsAdbLog ? FileAccess.ReadWrite : FileAccess.Read);
                    FileInfo fileInfo = new FileInfo(filePath);

                    // Calcs and finally point the position to the end of the line
                    long position = 0;
                    // Holds the offset to the start of the next line
                    long lineStartOffset = 0;
                    // Checks if we have read less than requested e.g. buffer not filled/end of file
                    bool lastSection = false;
                    // Counter for process reporting
                    int counter = 0;
                    // Holds a counter to start checking for the next indexOf('\r')
                    int startIndex = 0;
                    // Once all of the \r (lines) have been emnumerated, there might still be data left in the
                    // buffer, so this holds the number of bytes that need to be added onto the next line
                    int bufferRemainder = 0;
                    // Holds how many bytes were read from the last file stream read
                    int numBytesRead = 0;
                    // Holds the temporary string generated from the file stream buffer
                    string tempStr = string.Empty;
                    // Length of the current line
                    int charCount;
                    // Return value from IndexOf function
                    int indexOf;
                    bool isTiny = false;

                    while (position < this.fileStream.Length)
                    {
                        numBytesRead = this.fileStream.Read(tempBuffer, 0, 1024 * 1024);
                        if (numBytesRead < 1048576)

                        {
                            lastSection = true;
                        }

                        tempStr = Encoding.ASCII.GetString(tempBuffer).Substring(0, numBytesRead);
                        startIndex = 0;

                        // Does the buffer contain at least one "\n", so now enumerate all instances of "\n"
                        if (tempStr.IndexOf('\n') != -1)
                        {
                            while ((indexOf = tempStr.IndexOf('\n', startIndex)) != -1 && startIndex < numBytesRead)
                            {
                                if (indexOf != -1)
                                {
                                    charCount = 0;
                                    bool preCr = IsLastLineCr();
                                    bool curCr = false;

                                    // Check if the line contains a CR as well, if it does then we remove the last char as the char count
                                    if (indexOf != 0 && (int)tempBuffer[Math.Max(0, indexOf - 1)] == 13)
                                    {
                                        charCount = bufferRemainder + (indexOf - startIndex - 1);
                                        position += (long)charCount + 2L;

                                        curCr = true;
                                    }
                                    else
                                    {
                                        charCount = bufferRemainder + (indexOf - startIndex);
                                        position += (long)charCount + 1L;
                                    }

                                    int newStartOffset = 0;
                                    Global.LogType logType = Global.LogType.Info;
                                    // ConsoleTiny 的解析
                                    if (indexOf - startIndex > 13 && tempStr[startIndex + 9] == '-' &&
                                        tempStr[startIndex + 7] == 't')
                                    {
                                        if (tempStr[startIndex + 8] == '3')
                                        {
                                            logType = Global.LogType.Error;
                                            newStartOffset = 13;
                                            isTiny = true;
                                        }
                                        else if (tempStr[startIndex + 8] == '2')
                                        {
                                            logType = Global.LogType.Warning;
                                            newStartOffset = 13;
                                            isTiny = true;
                                        }
                                        else if (tempStr[startIndex + 8] == '1')
                                        {
                                            logType = Global.LogType.Info;
                                            newStartOffset = 13;
                                            isTiny = true;
                                        }
                                    }

                                    // 不是tiny格式的话，就当做unity默认的
                                    if (newStartOffset != 13 && !isTiny)
                                    {
                                        // unity格式不以当行结尾是否cr来判断，而是以下一行是否\r空行来判断
                                        if (charCount == 0)
                                        {
                                            SetLastLineCr();
                                            if (!IsLastLineLogType())
                                            {
                                                SetLastLineLogType(Global.LogType.Info);
                                            }
                                        }
                                        else
                                        {
                                            if (preCr)
                                            {
                                                AddLine(lineStartOffset + newStartOffset, charCount - newStartOffset,
                                                    false, Global.LogType.None);
                                            }
                                            else
                                            {
                                                if (!IsLastLineLogType())
                                                {
                                                    if (indexOf - startIndex > 22 && tempStr[startIndex + 17] == ':' &&
                                                        tempStr[startIndex + 18] == 'L')
                                                    {
                                                        if (tempStr[startIndex + 21] == 'E')
                                                        {
                                                            logType = Global.LogType.Error;
                                                            SetLastLineLogType(logType);
                                                        }
                                                        else if (tempStr[startIndex + 21] == 'W')
                                                        {
                                                            logType = Global.LogType.Warning;
                                                            SetLastLineLogType(logType);
                                                        }
                                                        else if (tempStr[startIndex + 20] == 'g')
                                                        {
                                                            logType = Global.LogType.Info;
                                                            SetLastLineLogType(logType);
                                                        }
                                                    }
                                                }

                                                AppendLineStackTrace(lineStartOffset, charCount + (curCr ? 1 : 0),
                                                    false);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // 不能以换行符来作为新行，因为tiny都是有标记，所以按标记就可以，这样就可以显示日志带换行的
                                        if (newStartOffset == 13)
                                        {
                                            SetLastLineCr();
                                            AddLine(lineStartOffset + newStartOffset, charCount - newStartOffset, false,
                                                logType);
                                        }
                                        else
                                        {
                                            AppendLineStackTrace(lineStartOffset, charCount, false);
                                        }
                                    }

                                    // The remaining number in the buffer gets set to 0 e.g. after 
                                    //the first iteration as it would add onto the first line
                                    bufferRemainder = 0;

                                    // Set the offset to the end of the last line that has just been added
                                    lineStartOffset = position;
                                    startIndex = indexOf + 1;
                                }
                            }

                            // We had some '\r' in the last buffer read, now they are processing, so just add the rest as the last line
                            if (lastSection == true)
                            {
                                AddLine(lineStartOffset, bufferRemainder + (numBytesRead - startIndex), true,
                                    Global.LogType.Info);
                                return;
                            }

                            bufferRemainder += numBytesRead - startIndex;
                        }
                        else
                        {
                            // The entire content of the buffer doesn't contain \r so just add the rest of content as the last line
                            if (lastSection == true)
                            {
                                AddLine(lineStartOffset, bufferRemainder + (numBytesRead - startIndex), true,
                                    Global.LogType.Info);
                                return;
                            }

                            bufferRemainder += numBytesRead;
                        }

                        if (counter++ % 50 == 0)
                        {
                            OnProgressUpdate((int)((double)position / (double)fileInfo.Length * 100));

                            if (ct.IsCancellationRequested)
                            {
                                cancelled = true;
                                return;
                            }
                        }
                    } // WHILE
                }
                catch (IOException ex)
                {
                    OnLoadError(ex.Message);
                    error = true;
                }
                finally
                {
                    if (error == false)
                    {
                        DateTime end = DateTime.Now;

                        OnProgressUpdate(100);
                        OnLoadComplete(end - start, cancelled);
                    }
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Searches = new Searches();
            this.Lines.Clear();
            this.LongestLine = new LogLine();
            this.LineCount = 0;
            this.FileName = String.Empty;
            this.List.ModelFilter = null;
            this.List.ClearObjects();

            if (this.fileStream != null)
            {
                this.fileStream.Dispose();
            }

            if (pageForm != null)
            {
                pageForm.ClearObjects();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="searchType"></param>
        public void Search(CancellationToken ct, int numContextLines)
        {
            Task.Run(() =>
            {

                DateTime start = DateTime.Now;
                bool cancelled = false;
                long matches = 0;
                try
                {
                    long counter = 0;
                    string line = string.Empty;
                    bool located = false;

                    foreach (LogLine ll in this.Lines)
                    {
                        line = String.Empty;
                        ll.IsCurSearch = false;
                        ClearContextLine(ll.LineNumber, numContextLines);

                        if (Searches.Changed)
                        {
                            ll.IsTerms = true;
                            foreach (SearchCriteria sc in Searches.Items)
                            {
                                if (!sc.Enabled)
                                {
                                    continue;
                                }

                                if (string.IsNullOrEmpty(line))
                                {
                                    line = this.GetLine(ll.LineNumber);
                                }

                                located = false;
                                switch (sc.Type)
                                {
                                    case Global.SearchType.SubStringCaseInsensitive:
                                        if (line.IndexOf(sc.Pattern, 0, StringComparison.OrdinalIgnoreCase) > -1)
                                        {
                                            located = true;
                                        }

                                        break;

                                    case Global.SearchType.SubStringCaseSensitive:
                                        if (line.IndexOf(sc.Pattern, 0, StringComparison.Ordinal) > -1)
                                        {
                                            located = true;
                                        }

                                        break;

                                    case Global.SearchType.RegexCaseInsensitive:
                                        if (Regex.Match(line, sc.Pattern,
                                                RegexOptions.IgnoreCase | RegexOptions.Compiled) != Match.Empty)
                                        {
                                            located = true;
                                        }

                                        break;

                                    case Global.SearchType.RegexCaseSensitive:
                                        if (Regex.Match(line, sc.Pattern, RegexOptions.Compiled) != Match.Empty)
                                        {
                                            located = true;
                                        }

                                        break;

                                    default:
                                        break;
                                }

                                if (located == true)
                                {
                                }
                                else
                                {
                                    ll.IsTerms = false;
                                    break;
                                }
                            }
                        }

                        // 条件符合
                        if (ll.IsTerms && !string.IsNullOrEmpty(CurSearch.Pattern))
                        {
                            if (string.IsNullOrEmpty(line))
                            {
                                line = this.GetLine(ll.LineNumber);
                            }

                            var sc = CurSearch;
                            located = false;
                            switch (sc.Type)
                            {
                                case Global.SearchType.SubStringCaseInsensitive:
                                    if (line.IndexOf(sc.Pattern, 0, StringComparison.OrdinalIgnoreCase) > -1)
                                    {
                                        located = true;
                                    }

                                    break;

                                case Global.SearchType.SubStringCaseSensitive:
                                    if (line.IndexOf(sc.Pattern, 0, StringComparison.Ordinal) > -1)
                                    {
                                        located = true;
                                    }

                                    break;

                                case Global.SearchType.RegexCaseInsensitive:
                                    if (Regex.Match(line, sc.Pattern,
                                            RegexOptions.IgnoreCase | RegexOptions.Compiled) != Match.Empty)
                                    {
                                        located = true;
                                    }

                                    break;

                                case Global.SearchType.RegexCaseSensitive:
                                    if (Regex.Match(line, sc.Pattern, RegexOptions.Compiled) != Match.Empty)
                                    {
                                        located = true;
                                    }

                                    break;

                                default:
                                    break;
                            }

                            if (located == true)
                            {
                                matches++;
                                ll.IsCurSearch = true;
                            }
                        }

                        if (counter++ % 50 == 0)
                        {
                            OnProgressUpdate((int)((double)counter / (double)this.Lines.Count * 100));

                            if (ct.IsCancellationRequested)
                            {
                                cancelled = true;
                                return;
                            }
                        }
                    }

                    Searches.Changed = false;
                }
                finally
                {
                    DateTime end = DateTime.Now;

                    OnProgressUpdate(100);
                    OnSearchComplete(end - start, matches, 1, cancelled);
                }
            });
        }

        /// <summary>
        /// 对后面新增的也进行搜索
        /// </summary>
        /// <param name="numContextLines"></param>
        public void SearchNewLines(List<AdbClient.AdbLine> newLines)
        {
            {
                try
                {
                    string line = string.Empty;
                    bool located = false;

                    foreach (var ll in newLines)
                    {
                        line = String.Empty;
                        ll.IsCurSearch = false;

                        {
                            ll.IsTerms = true;
                            foreach (SearchCriteria sc in Searches.Items)
                            {
                                if (!sc.Enabled)
                                {
                                    continue;
                                }

                                if (string.IsNullOrEmpty(line))
                                {
                                    line = ll.LineText;
                                }

                                located = false;
                                switch (sc.Type)
                                {
                                    case Global.SearchType.SubStringCaseInsensitive:
                                        if (line.IndexOf(sc.Pattern, 0, StringComparison.OrdinalIgnoreCase) > -1)
                                        {
                                            located = true;
                                        }

                                        break;

                                    case Global.SearchType.SubStringCaseSensitive:
                                        if (line.IndexOf(sc.Pattern, 0, StringComparison.Ordinal) > -1)
                                        {
                                            located = true;
                                        }

                                        break;

                                    case Global.SearchType.RegexCaseInsensitive:
                                        if (Regex.Match(line, sc.Pattern,
                                                RegexOptions.IgnoreCase | RegexOptions.Compiled) != Match.Empty)
                                        {
                                            located = true;
                                        }

                                        break;

                                    case Global.SearchType.RegexCaseSensitive:
                                        if (Regex.Match(line, sc.Pattern, RegexOptions.Compiled) != Match.Empty)
                                        {
                                            located = true;
                                        }

                                        break;

                                    default:
                                        break;
                                }

                                if (located == true)
                                {
                                }
                                else
                                {
                                    ll.IsTerms = false;
                                    break;
                                }
                            }
                        }

                        // 条件符合
                        if (ll.IsTerms && !string.IsNullOrEmpty(CurSearch.Pattern))
                        {
                            if (string.IsNullOrEmpty(line))
                            {
                                line = ll.LineText;
                            }

                            var sc = CurSearch;
                            located = false;
                            switch (sc.Type)
                            {
                                case Global.SearchType.SubStringCaseInsensitive:
                                    if (line.IndexOf(sc.Pattern, 0, StringComparison.OrdinalIgnoreCase) > -1)
                                    {
                                        located = true;
                                    }

                                    break;

                                case Global.SearchType.SubStringCaseSensitive:
                                    if (line.IndexOf(sc.Pattern, 0, StringComparison.Ordinal) > -1)
                                    {
                                        located = true;
                                    }

                                    break;

                                case Global.SearchType.RegexCaseInsensitive:
                                    if (Regex.Match(line, sc.Pattern,
                                            RegexOptions.IgnoreCase | RegexOptions.Compiled) != Match.Empty)
                                    {
                                        located = true;
                                    }

                                    break;

                                case Global.SearchType.RegexCaseSensitive:
                                    if (Regex.Match(line, sc.Pattern, RegexOptions.Compiled) != Match.Empty)
                                    {
                                        located = true;
                                    }

                                    break;

                                default:
                                    break;
                            }

                            if (located == true)
                            {
                                ll.IsCurSearch = true;
                            }
                        }
                    }

                }
                finally
                {
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ct"></param>
        public void Export(string filePath, CancellationToken ct)
        {
            this.ExportToFile(this.Lines, filePath, ct);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="filePath"></param>
        /// <param name="ct"></param>
        public void Export(IEnumerable lines, string filePath, CancellationToken ct)
        {
            this.ExportToFile(lines, filePath, ct);
        }

        #endregion

        public DocLogFile Initialise(string filePath)
        {
            OLVColumn colLineNumber = ((OLVColumn)(new OLVColumn()));
            OLVColumn colText = ((OLVColumn)(new OLVColumn()));

            colLineNumber.Text = "行号";
            colLineNumber.Width = 58;
            colText.Text = "日志";
            colText.FillsFreeSpace = true;

            colLineNumber.AspectGetter = delegate (object x)
            {
                if (((LogLine)x) == null)
                {
                    return "";
                }

                return (((LogLine)x).LineNumber + 1);
            };

            colText.AspectGetter = delegate (object x)
            {
                if (((LogLine)x) == null)
                {
                    return "";
                }

                return (this.GetLine(((LogLine)x).LineNumber));
            };

            colText.ImageGetter = delegate (object x)
            {
                LogLine log = (LogLine)x;
                if (log == null)
                {
                    return "";
                }

                if (log.LogType == Global.LogType.Info)
                {
                    return "1 (2).png";
                }

                if (log.LogType == Global.LogType.Warning)
                {
                    return "1 (3).png";
                }

                if (log.LogType == Global.LogType.Error)
                {
                    return "1 (1).png";
                }

                return "";
            };

            DocLogFile logPage = new DocLogFile(Path.GetFileName(filePath));
            pageForm = logPage;
            pageForm.Log = this;
            FastObjectListView lv = logPage.GetFastObjectListView();
            lv.HeaderUsesThemes = false;
            logPage.GetHighlightTextRenderer().FillBrush = Brushes.Transparent;
            lv.DefaultRenderer = logPage.GetHighlightTextRenderer();

            colLineNumber.Width = Convert.ToInt32(colLineNumber.Width * lv.DeviceDpi / 96f);
            lv.AllColumns.Add(colLineNumber);
            lv.AllColumns.Add(colText);
            lv.AllowDrop = true;
            lv.AutoArrange = false;
            lv.CausesValidation = false;
            lv.CellEditUseWholeCell = false;
            lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
            {
                colLineNumber,
                colText
            });
            //lv.ContextMenuStrip = this.contextMenu;
            lv.Dock = System.Windows.Forms.DockStyle.Fill;
            //lv.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lv.FullRowSelect = true;
            //lv.GridLines = true;
            lv.HasCollapsibleGroups = false;
            lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            lv.HideSelection = false;
            lv.IsSearchOnSortColumn = false;
            lv.Location = new System.Drawing.Point(3, 3);
            lv.Margin = new System.Windows.Forms.Padding(4);
            lv.Name = "listLines0";
            lv.SelectColumnsMenuStaysOpen = false;
            lv.SelectColumnsOnRightClick = false;
            lv.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            lv.ShowFilterMenuOnRightClick = false;
            lv.ShowGroups = false;
            lv.ShowSortIndicators = false;
            lv.Size = new System.Drawing.Size(1679, 940);
            lv.TabIndex = 1;
            lv.TriggerCellOverEventsWhenOverHeader = false;
            lv.UseCompatibleStateImageBehavior = false;
            lv.UseFiltering = true;
            lv.View = System.Windows.Forms.View.Details;
            lv.VirtualMode = true;
            lv.Tag = this.Guid;
            lv.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.FormatRow);
            lv.ForeColor = Color.FromArgb(204, 204, 204);
            lv.SelectedForeColor = lv.ForeColor;
            lv.UnfocusedSelectedForeColor = lv.ForeColor;
            lv.SelectedBackColor = Color.FromArgb(62, 95, 150);
            lv.UnfocusedSelectedBackColor = lv.SelectedBackColor;

            this.List = lv;
            return pageForm;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetContextMenu(ContextMenuStrip ctx)
        {
            this.List.ContextMenuStrip = ctx;
        }

        /// <summary>
        /// 搜索结束
        /// </summary>
        public void SetSearchEnd()
        {
            SetShowType();
            pageForm.GetToolStripProgressBar().Visible = false;
            List.Refresh();
        }

        /// <summary>
        /// 设置列表显示
        /// </summary>
        public void SetShowType()
        {
            var selectedLine = -1;
            var selectedObjects = List.SelectedObject;
            if (selectedObjects != null)
            {
                selectedLine = ((LogLine)selectedObjects).LineNumber;
            }

            List.ModelFilter = new ModelFilter(delegate (object x)
            {
                var line = (LogLine)x;
                var isShowType = (ShowTypeInfo && (line.LogType == Global.LogType.Info)) ||
                                 (ShowTypeWarning && (line.LogType == Global.LogType.Warning)) ||
                                 (ShowTypeError && (line.LogType == Global.LogType.Error));
                if (isShowType)
                {
                    if (pageForm.IsShowMatch() && !string.IsNullOrEmpty(CurSearch.Pattern))
                    {
                        return line.IsCurSearch;
                    }
                    else
                    {
                        return line.IsTerms;
                    }
                }

                return false;
            });

            if (string.IsNullOrEmpty(CurSearch.Pattern))
            {
                ViewMode = Global.ViewMode.Standard;
                pageForm.GetHighlightTextRenderer().Filter = null;
            }
            else
            {
                this.ViewMode = Global.ViewMode.FilterShow;
                pageForm.GetHighlightTextRenderer().Filter = null;
                TextMatchFilter filter = null;
                switch (CurSearch.Type)
                {
                    case Global.SearchType.SubStringCaseInsensitive:
                        {
                            filter = TextMatchFilter.Contains(List, CurSearch.Pattern);
                        }
                        break;
                    case Global.SearchType.SubStringCaseSensitive:
                        {
                            filter = TextMatchFilter.Contains(List, CurSearch.Pattern);
                            filter.StringComparison = StringComparison.Ordinal;
                        }
                        break;
                    case Global.SearchType.RegexCaseInsensitive:
                        {
                            filter = TextMatchFilter.Regex(List, CurSearch.Pattern);
                        }
                        break;
                    case Global.SearchType.RegexCaseSensitive:
                        {
                            filter = TextMatchFilter.Regex(List, CurSearch.Pattern);
                            filter.StringComparison = StringComparison.Ordinal;
                        }
                        break;
                }

                pageForm.GetHighlightTextRenderer().Filter = filter;
            }

            if (selectedLine > -1)
            {
                for (int i = 0; i < List.GetItemCount(); i++)
                {
                    var modelObject = List.GetModelObject(i);
                    var line = (LogLine)modelObject;
                    if (line != null)
                    {
                        if (line.LineNumber == selectedLine)
                        {
                            SetSelectedLine(i);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 前进后退行
        /// </summary>
        /// <param name="isError"></param>
        /// <param name="isNext"></param>
        public void SetGoLine(bool isError, bool isNext)
        {
            if (!isError && string.IsNullOrEmpty(CurSearch.Pattern))
            {
                return;
            }

            var selectedObjects = List.SelectedIndices;
            int[] selectedList;
            if (selectedObjects.Count > 0)
            {
                selectedList = new int[selectedObjects.Count];
                selectedObjects.CopyTo(selectedList, 0);
            }
            else
            {
                selectedList = new[] { 0 };
            }

            if (isNext)
            {
                var idx = selectedList.Max();
                for (int i = idx + 1; i < List.GetItemCount(); i++)
                {
                    var modelObject = List.GetModelObject(i);
                    var line = (LogLine)modelObject;
                    if (line != null)
                    {
                        if (isError)
                        {
                            if (line.LogType == Global.LogType.Error)
                            {
                                SetSelectedLine(i);
                                return;
                            }
                        }
                        else
                        {
                            if (line.IsCurSearch)
                            {
                                SetSelectedLine(i);
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                var idx = selectedList.Min();
                for (int i = idx - 1; i >= 0; i--)
                {
                    var modelObject = List.GetModelObject(i);
                    var line = (LogLine)modelObject;
                    if (line != null)
                    {
                        if (isError)
                        {
                            if (line.LogType == Global.LogType.Error)
                            {
                                SetSelectedLine(i);
                                return;
                            }
                        }
                        else
                        {
                            if (line.IsCurSearch)
                            {
                                SetSelectedLine(i);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void SetSelectedLine(int idx)
        {
            List.SelectedIndex = idx;
            List.FocusedItem = List.SelectedItem;
            List.EnsureVisible(idx);
            var mid = (idx - List.TopItemIndex) / 2;
            if (idx + mid < List.GetItemCount())
            {
                List.EnsureVisible(idx + mid);
            }
            else
            {
                List.EnsureVisible(List.GetItemCount() - 1);
            }

            List.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FormatRow(object sender, FormatRowEventArgs e)
        {
            //if (this.viewMode != Global.ViewMode.FilterHide)
            //{
            if ((LogLine)e.Model == null)
            {
                return;
            }

            //            if (((LogLine)e.Model).SearchMatches.Intersect(this.FilterIds).Any() == true)
            //            {
            //                e.Item.BackColor = highlightColour;
            //            }
            //            else if (((LogLine)e.Model).IsContextLine == true)
            //            {
            //                e.Item.BackColor = contextColour;
            //            }
            //}            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineNumber"></param>
        /// <param name="numLines"></param>
        private void SetContextLines(long lineNumber, int numLines)
        {
            long temp = numLines;
            if (lineNumber < this.Lines.Count)
            {
                if (numLines + lineNumber > this.Lines.Count - 1)
                {
                    temp = this.Lines.Count - lineNumber - 1;
                }

                for (int index = 1; index <= temp; index++)
                {
                    this.Lines[(int)lineNumber + index].IsContextLine = true;
                }
            }

            if (lineNumber > 0)
            {
                if (lineNumber - numLines < 0)
                {
                    temp = lineNumber;
                }

                for (int index = 1; index <= temp; index++)
                {
                    this.Lines[(int)lineNumber - index].IsContextLine = true;
                }
            }
        }

        /// <summary>
        /// Clear the line that is the next after the farthest context
        /// line, so the flag is reset and we won't overwrite
        /// </summary>
        /// <param name="lineNumber"></param>
        /// <param name="numLines"></param>
        private void ClearContextLine(long lineNumber, int numLines)
        {
            long temp = numLines;
            if ((int)lineNumber + numLines + 1 < this.Lines.Count - 1)
            {
                this.Lines[(int)lineNumber + numLines + 1].IsContextLine = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ct"></param>
        private void ExportToFile(IEnumerable lines, string filePath, CancellationToken ct)
        {
            Task.Run(() =>
            {
                DateTime start = DateTime.Now;
                bool cancelled = false;
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        string lineStr = string.Empty;
                        byte[] lineBytes;
                        byte[] endLine = new byte[2] { 13, 10 };

                        long counter = 0;
                        foreach (LogLine ll in lines)
                        {
                            lineStr = this.GetLine(ll.LineNumber);
                            lineBytes = Encoding.UTF8.GetBytes(lineStr);
                            fs.Write(lineBytes, 0, lineBytes.Length);
                            // Add \r\n
                            fs.Write(endLine, 0, 2);

                            if (counter++ % 50 == 0)
                            {
                                OnProgressUpdate((int)((double)counter / (double)Lines.Count * 100));

                                if (ct.IsCancellationRequested)
                                {
                                    cancelled = true;
                                    return;
                                }
                            }
                        }

                    }
                }
                finally
                {
                    DateTime end = DateTime.Now;

                    OnProgressUpdate(100);
                    OnExportComplete(end - start, cancelled);
                }
            });
        }

        private LogLine NewLine(long offset, int charCount, bool endCr, Global.LogType logType)
        {
            LogLine ll = new LogLine();
            ll.Offset = offset;
            ll.CharCount = charCount;
            ll.LineNumber = this.LineCount;
            ll.IsCrLine = endCr;
            ll.LogType = logType;

            this.LineCount++;
            if (logType == Global.LogType.Info)
            {
                TypeInfoCount++;
            }
            else if (logType == Global.LogType.Warning)
            {
                TypeWarningCount++;
            }
            else if (logType == Global.LogType.Error)
            {
                TypeErrorCount++;
            }

            return ll;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="charCount"></param>
        private void AddLine(long offset, int charCount, bool endCr, Global.LogType logType)
        {
            var ll = NewLine(offset, charCount, endCr, logType);
            if (charCount > this.LongestLine.CharCount)
            {
                this.LongestLine.CharCount = charCount;
                this.LongestLine.LineNumber = ll.LineNumber;
            }

            this.Lines.Add(ll);
        }

        private void AppendLineStackTrace(long offset, int charCount, bool endCr)
        {
            if (this.Lines.Count > 0)
            {
                LogLine ll = this.Lines[this.Lines.Count - 1];
                if (ll.StackTraceOffset == 0)
                {
                    ll.StackTraceOffset = offset;
                }

                ll.StackTraceCharCount += charCount + 1;
                ll.IsCrLine = endCr;
            }
        }

        /// <summary>
        /// 最后一行是否结束cr了
        /// </summary>
        private bool IsLastLineCr()
        {
            if (this.Lines.Count > 0)
            {
                LogLine ll = this.Lines[this.Lines.Count - 1];
                return ll.IsCrLine;
            }

            return true;
        }

        /// <summary>
        /// Unity日志格式使用
        /// </summary>
        private void SetLastLineCr()
        {
            if (this.Lines.Count > 0)
            {
                LogLine ll = this.Lines[this.Lines.Count - 1];
                ll.IsCrLine = true;
            }
        }

        private bool IsLastLineLogType()
        {
            if (this.Lines.Count > 0)
            {
                LogLine ll = this.Lines[this.Lines.Count - 1];
                return ll.LogType != Global.LogType.None;
            }

            return true;
        }

        private void SetLastLineLogType(Global.LogType logType)
        {
            if (this.Lines.Count > 0)
            {
                LogLine ll = this.Lines[this.Lines.Count - 1];
                ll.LogType = logType;

                if (logType == Global.LogType.Info)
                {
                    TypeInfoCount++;
                }
                else if (logType == Global.LogType.Warning)
                {
                    TypeWarningCount++;
                }
                else if (logType == Global.LogType.Error)
                {
                    TypeErrorCount++;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public string GetLine(int lineNumber)
        {
            if (lineNumber >= this.Lines.Count)
            {
                return string.Empty;
            }

            byte[] buffer = new byte[this.Lines[lineNumber].CharCount];
            try
            {
                this.readMutex.WaitOne();
                this.fileStream.Seek(this.Lines[lineNumber].Offset, SeekOrigin.Begin);
                this.fileStream.Read(buffer, 0, this.Lines[lineNumber].CharCount);
                this.readMutex.ReleaseMutex();
            }
            catch (Exception)
            {
                // ignored
            }

            //return Regex.Replace(Encoding.ASCII.GetString(buffer), "[\0-\b\n\v\f\x000E-\x001F\x007F-ÿ]", "", RegexOptions.Compiled);
            var str = Encoding.UTF8.GetString(buffer);
            str = GetPureLines(str);
            return str;
        }

        public string GetLineStackTrace(int lineNumber)
        {
            if (lineNumber >= this.Lines.Count)
            {
                return string.Empty;
            }

            byte[] buffer = new byte[this.Lines[lineNumber].StackTraceCharCount];
            try
            {
                this.readMutex.WaitOne();
                this.fileStream.Seek(this.Lines[lineNumber].StackTraceOffset, SeekOrigin.Begin);
                this.fileStream.Read(buffer, 0, this.Lines[lineNumber].StackTraceCharCount);
                this.readMutex.ReleaseMutex();
            }
            catch (Exception)
            {
                // ignored
            }

            //return Regex.Replace(Encoding.ASCII.GetString(buffer), "[\0-\b\n\v\f\x000E-\x001F\x007F-ÿ]", "", RegexOptions.Compiled);
            return Encoding.UTF8.GetString(buffer);
        }

        public void WriteAdbLines(List<AdbClient.AdbLine> adbLines)
        {
            List<LogLine> newLines = new List<LogLine>(adbLines.Count);
            SearchNewLines(adbLines);

            this.readMutex.WaitOne();
            foreach (var adbLine in adbLines)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(adbLine.LineText);
                var charCount = buffer.Length;
                var offset = this.fileStream.Seek(0, SeekOrigin.End);
                this.fileStream.Write(buffer, 0, charCount);

                // 因为行内容包括了CRCF，所以这里要减2，在拼接的时候，才不会出错
                var ll = NewLine(offset, charCount - 2, true, (Global.LogType)(adbLine.LogType / 10));
                ll.IsTerms = adbLine.IsTerms;
                ll.IsCurSearch = adbLine.IsCurSearch;

                if (adbLine.StackTraceText.Length > 0)
                {
                    buffer = Encoding.UTF8.GetBytes(adbLine.StackTraceText);
                    charCount = buffer.Length;
                    offset = this.fileStream.Seek(0, SeekOrigin.End);
                    this.fileStream.Write(buffer, 0, charCount);
                    ll.StackTraceOffset = offset;
                    ll.StackTraceCharCount = charCount;
                }

                // Unity格式以空行标记
                buffer = Encoding.UTF8.GetBytes("\r\n");
                charCount = buffer.Length;
                this.fileStream.Seek(0, SeekOrigin.End);
                this.fileStream.Write(buffer, 0, charCount);

                newLines.Add(ll);
            }

            this.readMutex.ReleaseMutex();

            pageForm.BeginInvoke(new Action(() =>
            {
                bool isScroll = true;
                if (List.Items.Count > 0)
                {
                    // 判断最后一项是否可见，可见的话，说明要自动滚动
                    isScroll = List.Items[List.Items.Count - 1].Bounds.IntersectsWith(List.ClientRectangle);
                }

                bool reWidth = false;
                foreach (var ll in newLines)
                {
                    if (ll.CharCount > this.LongestLine.CharCount)
                    {
                        this.LongestLine.CharCount = ll.CharCount;
                        this.LongestLine.LineNumber = ll.LineNumber;
                        reWidth = true;
                    }
                }

                Lines.AddRange(newLines);
                List.AddObjects(newLines);
                pageForm.SetTypeCount();

                if (reWidth)
                {
                    ResizeWidth();
                }

                if (isScroll && List.Items.Count > 0)
                {
                    List.EnsureVisible(List.Items.Count - 1);
                }
            }));
        }

        public void ClearAdbLines()
        {
            this.readMutex.WaitOne();
            this.fileStream.SetLength(0);
            this.readMutex.ReleaseMutex();
            Lines.Clear();
            this.LineCount = 0;
            TypeInfoCount = 0;
            TypeWarningCount = 0;
            TypeErrorCount = 0;
            List.SetObjects(Lines);
            pageForm.SetTypeCount();
            pageForm.ClearStackTraceText();
        }

        public void ResizeWidth()
        {
            // Try and measure the length of the longest line in pixels
            // This is rough, and tends to be too short, but cannot find
            // another method to make column wide enough :-)
            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    string temp = GetLine(LongestLine.LineNumber);
                    var result = g.MeasureString(temp, List.Font);
                    var newWidth = Convert.ToInt32(result.Width * List.DeviceDpi / 96f + 200);
                    if (List.AllColumns[1].FillsFreeSpace)
                    {
                        if (List.Columns[1].Width < newWidth)
                        {
                            List.AllColumns[1].FillsFreeSpace = false;
                            List.Columns[1].Width = newWidth;
                        }
                    }
                    else
                    {
                        List.Columns[1].Width = newWidth;
                    }
                }
            }
        }

        #region HTMLTag

        private const int kTagColorIndex = 2;
        private const int kTagQuadIndex = 5;

        private readonly string[] m_TagStrings = new string[]
        {
            "b",
            "i",
            "color",
            "size",
            "material",
            "quad",
            "x",
            "y",
            "width",
            "height",
        };

        private readonly StringBuilder m_StringBuilder = new StringBuilder();
        private readonly Stack<int> m_TagStack = new Stack<int>();

        private int GetTagIndex(string input, ref int pos, out bool closing)
        {
            closing = false;
            if (input[pos] == '<')
            {
                int inputLen = input.Length;
                int nextPos = pos + 1;
                if (nextPos == inputLen)
                {
                    return -1;
                }

                closing = input[nextPos] == '/';
                if (closing)
                {
                    nextPos++;
                }

                for (int i = 0; i < m_TagStrings.Length; i++)
                {
                    var tagString = m_TagStrings[i];
                    bool find = true;

                    for (int j = 0; j < tagString.Length; j++)
                    {
                        int pingPos = nextPos + j;
                        if (pingPos == inputLen || char.ToLower(input[pingPos]) != tagString[j])
                        {
                            find = false;
                            break;
                        }
                    }

                    if (find)
                    {
                        int endPos = nextPos + tagString.Length;
                        if (endPos == inputLen)
                        {
                            continue;
                        }

                        if ((!closing && input[endPos] == '=') || (input[endPos] == ' ' && i == kTagQuadIndex))
                        {
                            while (input[endPos] != '>' && endPos < inputLen)
                            {
                                endPos++;
                            }
                        }

                        if (input[endPos] != '>')
                        {
                            continue;
                        }

                        pos = endPos;
                        return i;
                    }
                }
            }

            return -1;
        }

        private string GetPureLines(string input)
        {
            m_StringBuilder.Length = 0;
            m_TagStack.Clear();

            int preStrPos = 0;
            int pos = 0;
            while (pos < input.Length)
            {
                int oldPos = pos;
                bool closing;
                int tagIndex = GetTagIndex(input, ref pos, out closing);
                if (tagIndex != -1)
                {
                    if (closing)
                    {
                        if (m_TagStack.Count == 0 || m_TagStack.Pop() != tagIndex)
                        {
                            return input;
                        }
                    }

                    if (preStrPos != oldPos)
                    {
                        m_StringBuilder.Append(input, preStrPos, oldPos - preStrPos);
                    }

                    preStrPos = pos + 1;

                    if (closing || tagIndex == kTagQuadIndex)
                    {
                        continue;
                    }

                    m_TagStack.Push(tagIndex);
                }

                pos++;
            }

            if (m_TagStack.Count > 0)
            {
                return input;
            }

            if (preStrPos > 0 && preStrPos < input.Length)
            {
                m_StringBuilder.Append(input, preStrPos, input.Length - preStrPos);
            }

            if (m_StringBuilder.Length > 0)
            {
                return m_StringBuilder.ToString();
            }

            return input;
        }

        private Color ParseHTMLColor(string input, int oldPos, int endPos)
        {
            Console.WriteLine(input.Substring(oldPos + 7, endPos - oldPos - 7));
            return Color.AliceBlue;
            
        }

        #endregion

        #region Stacktrace

        internal class Constants
        {
            public static Color colorNamespace, colorNamespaceAlpha;
            public static Color colorClass, colorClassAlpha;
            public static Color colorMethod, colorMethodAlpha;
            public static Color colorParameters, colorParametersAlpha;
            public static Color colorPath, colorPathAlpha;
            public static Color colorFilename, colorFilenameAlpha;

            public static void Init()
            {
                colorNamespace = ColorTranslator.FromHtml("#6A87A7");
                colorClass = ColorTranslator.FromHtml("#1A7ECD");
                colorMethod = ColorTranslator.FromHtml("#0D9DDC");
                colorParameters = ColorTranslator.FromHtml("#4F7F9F");
                colorPath = ColorTranslator.FromHtml("#375E68");
                colorFilename = ColorTranslator.FromHtml("#4A6E8A");
                colorNamespaceAlpha = ColorTranslator.FromHtml("#4E5B6A");
                colorClassAlpha = ColorTranslator.FromHtml("#2A577B");
                colorMethodAlpha = ColorTranslator.FromHtml("#246581");
                colorParametersAlpha = ColorTranslator.FromHtml("#425766");
                colorPathAlpha = ColorTranslator.FromHtml("#375860");
                colorFilenameAlpha = ColorTranslator.FromHtml("#4A6E8A");
            }
        }

        public void ShowLineStackTrace(int lineNumber)
        {
            pageForm.StackTraceAppendText(GetLine(lineNumber) + "\n");

            int indexOf;
            int startIndex = 0;
            string tempStr = GetLineStackTrace(lineNumber);

            while ((indexOf = tempStr.IndexOf('\n', startIndex)) != -1)
            {
                var charCount = indexOf - startIndex;
                if (indexOf != 0 && (int)tempStr[Math.Max(0, indexOf - 1)] == 13)
                {
                    charCount -= 1;
                }

                var line = tempStr.Substring(startIndex, charCount);
                if (!ShowLineStackTraceCSharp(line))
                {
                    ShowLineStackTraceLua(line);
                }
                startIndex = indexOf + 1;
            }
        }

        const string textBeforeFilePath = ") (at ";
        const string fileInBuildSlave = "C:/buildslave/unity/";
        const string fileInBuildSlave2 = "D:/unity/";

        private bool ShowLineStackTraceCSharp(string line)
        {
            int methodLastIndex = line.IndexOf('(');
            if (methodLastIndex <= 0)
            {
                return false;
            }

            int argsLastIndex = line.IndexOf(')', methodLastIndex);
            if (argsLastIndex <= 0)
            {
                return false;
            }

            int methodFirstIndex = line.LastIndexOf(':', methodLastIndex);
            if (methodFirstIndex <= 0)
            {
                methodFirstIndex = line.LastIndexOf('.', methodLastIndex);
                if (methodFirstIndex <= 0)
                {
                    return false;
                }
            }

            string methodString = line.Substring(methodFirstIndex + 1, methodLastIndex - methodFirstIndex - 1);

            string classString;
            string namespaceString = String.Empty;
            int classFirstIndex = line.LastIndexOf('.', methodFirstIndex - 1);
            if (classFirstIndex <= 0)
            {
                classString = line.Substring(0, methodFirstIndex + 1);
            }
            else
            {
                classString = line.Substring(classFirstIndex + 1, methodFirstIndex - classFirstIndex);
                namespaceString = line.Substring(0, classFirstIndex + 1);
            }

            string argsString = line.Substring(methodLastIndex, argsLastIndex - methodLastIndex + 1);
            string fileString = String.Empty;
            string fileNameString = String.Empty;
            string fileLineString = String.Empty;
            bool alphaColor = true;

            int filePathIndex = line.IndexOf(textBeforeFilePath, argsLastIndex, StringComparison.Ordinal);
            if (filePathIndex > 0)
            {
                filePathIndex += textBeforeFilePath.Length;
                if (line[filePathIndex] != '<'
                ) // sometimes no url is given, just an id between <>, we can't do an hyperlink
                {
                    string filePathPart = line.Substring(filePathIndex);
                    int lineIndex =
                        filePathPart.LastIndexOf(":",
                            StringComparison.Ordinal); // LastIndex because the url can contain ':' ex:"C:"
                    if (lineIndex > 0)
                    {
                        int endLineIndex =
                            filePathPart.LastIndexOf(")",
                                StringComparison.Ordinal); // LastIndex because files or folder in the url can contain ')'
                        if (endLineIndex > 0)
                        {
                            string filePath = filePathPart.Substring(0, lineIndex);

                            bool isInBuildSlave = filePath.StartsWith(fileInBuildSlave, StringComparison.Ordinal) ||
                                                  filePath.StartsWith(fileInBuildSlave2, StringComparison.Ordinal);
                            if (!isInBuildSlave)
                            {
                                alphaColor = false;
                            }

                            fileNameString = System.IO.Path.GetFileName(filePath);
                            fileString = textBeforeFilePath.Substring(1) +
                                         filePath.Substring(0, filePath.Length - fileNameString.Length);
                            fileLineString = filePathPart.Substring(lineIndex, endLineIndex - lineIndex + 1);
                        }
                    }
                }
                else
                {
                    fileString = line.Substring(argsLastIndex + 1);
                }
            }

            var colorNamespace = Constants.colorNamespace;
            var colorClass = Constants.colorClass;
            var colorMethod = Constants.colorMethod;
            var colorParameters = Constants.colorParameters;
            var colorPath = Constants.colorPath;
            var colorFilename = Constants.colorFilename;

            if (alphaColor)
            {
                colorNamespace = Constants.colorNamespaceAlpha;
                colorClass = Constants.colorClassAlpha;
                colorMethod = Constants.colorMethodAlpha;
                colorParameters = Constants.colorParametersAlpha;
                colorPath = Constants.colorPathAlpha;
                colorFilename = Constants.colorFilenameAlpha;
            }

            if (!string.IsNullOrEmpty(namespaceString))
            {
                pageForm.StackTraceAppendText(namespaceString, colorNamespace);
            }
            pageForm.StackTraceAppendText(classString, colorClass);
            pageForm.StackTraceAppendText(methodString, colorMethod);
            pageForm.StackTraceAppendText(argsString, colorParameters);
            if (!string.IsNullOrEmpty(fileString))
            {
                pageForm.StackTraceAppendText(fileString, colorPath);
                pageForm.StackTraceAppendText(fileNameString, colorFilename);
                pageForm.StackTraceAppendText(fileLineString, colorPath);
            }

            pageForm.StackTraceAppendText("\n");

            return true;
        }

        const string luaCFunction = "[C]";
        const string luaMethodBefore = ": in function ";
        const string luaFileExt = ".lua";

        private bool ShowLineStackTraceLua(string line)
        {
            if (string.IsNullOrEmpty(line) || line[0] != '	')
            {
                return false;
            }

            string preMethodString = line;
            string methodString = String.Empty;
            int methodFirstIndex = line.IndexOf(luaMethodBefore, StringComparison.Ordinal);
            if (methodFirstIndex > 0)
            {
                methodString = line.Substring(methodFirstIndex + luaMethodBefore.Length);
                preMethodString = preMethodString.Remove(methodFirstIndex + luaMethodBefore.Length);
            }

            bool cFunction = line.IndexOf(luaCFunction, 1, StringComparison.Ordinal) == 1;
            if (!cFunction)
            {
                int lineIndex = line.IndexOf(':');
                if (lineIndex > 0)
                {
                    int endLineIndex = line.IndexOf(':', lineIndex + 1);
                    if (endLineIndex > 0)
                    {
                        string lineString =
                            line.Substring(lineIndex + 1, (endLineIndex) - (lineIndex + 1));
                        string filePath = line.Substring(1, lineIndex - 1);
                        if (!filePath.EndsWith(luaFileExt, StringComparison.Ordinal))
                        {
                            filePath += luaFileExt;
                        }

                        string namespaceString = String.Empty;
                        int classFirstIndex = filePath.LastIndexOf('/');
                        if (classFirstIndex > 0)
                        {
                            namespaceString = filePath.Substring(0, classFirstIndex + 1);
                        }

                        string classString = filePath.Substring(classFirstIndex + 1,
                            filePath.Length - namespaceString.Length - luaFileExt.Length);

                        pageForm.StackTraceAppendText("	");
                        pageForm.StackTraceAppendText(namespaceString, Constants.colorNamespace);
                        pageForm.StackTraceAppendText(classString, Constants.colorClass);
                        pageForm.StackTraceAppendText(":", Constants.colorPath);
                        pageForm.StackTraceAppendText(lineString, Constants.colorPath);
                        pageForm.StackTraceAppendText(luaMethodBefore, Constants.colorPath);
                        pageForm.StackTraceAppendText(methodString, Constants.colorMethod);
                    }
                }
            }
            else
            {
                pageForm.StackTraceAppendText(preMethodString, Constants.colorPathAlpha);
                pageForm.StackTraceAppendText(methodString, Constants.colorMethodAlpha);
            }
            pageForm.StackTraceAppendText("\n");

            return true;
        }

        #endregion

        #region Event Methods
        /// <summary>
        /// 
        /// </summary>
        private void OnLoadError(string message)
        {
            LoadError?.Invoke(this, this.FileName, message);
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnProgressUpdate(int progress)
        {
            ProgressUpdate?.Invoke(this, progress);
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnLoadComplete(TimeSpan duration, bool cancelled)
        {
            LoadComplete?.Invoke(this, this.FileName, duration, cancelled);
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnExportComplete(TimeSpan duration, bool cancelled)
        {
            ExportComplete?.Invoke(this, this.FileName, duration, cancelled);
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnSearchComplete(TimeSpan duration, long matches, int numTerms, bool cancelled)
        {
            SearchComplete?.Invoke(this, this.FileName, duration, matches, numTerms, cancelled);
        }

        public void OnProgressCancel()
        {
            ProgressCancel?.Invoke(this, 0);
        }

        public void OnSearchBegin()
        {
            SearchBegin?.Invoke(this);
        }
        #endregion
    }
}
