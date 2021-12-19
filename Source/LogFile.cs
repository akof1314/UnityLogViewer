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
        public delegate void SearchBeginEvent(LogFile lf, string text);
        public delegate void SearchCompleteEvent(LogFile lf, string fileName, TimeSpan duration, long matches, int numSearchTerms, bool cancelled, string searchText);
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
        private Color highlightColour { get; set; }  = Color.Lime;
        private Color contextColour { get; set; }  = Color.LightGray;
        public Searches Searches { get; set; }
        public Global.ViewMode ViewMode { get; set; }  = Global.ViewMode.Standard;
        public List<LogLine> Lines { get; private set; } = new List<LogLine>();
        public LogLine LongestLine { get; private set; } = new LogLine();
        public int LineCount { get; private set; } = 0;
        private FileStream fileStream;
        private Mutex readMutex = new Mutex();
        public string FileName { get; private set; }
        public List<ushort> FilterIds { get; private set; }  = new List<ushort>();
        public FastObjectListView List { get; set; }
        public string Guid { get; private set; }
        public FormLogPage pageForm { get; private set; }
        public int TypeInfoCount { get; private set; }
        public int TypeWarningCount { get; private set; }
        public int TypeErrorCount { get; private set; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public LogFile()
        {           
            this.Guid = System.Guid.NewGuid().ToString();
            this.Searches = new Searches();
        }

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="ct"></param>
        public void Load(string filePath, SynchronizationContext st, CancellationToken ct)
        {
            this.Dispose();
            this.FileName = Path.GetFileName(filePath);

            Task.Run(() => {

                DateTime start = DateTime.Now;
                bool cancelled = false;
                bool error = false;
                try
                {                    
                    byte[] tempBuffer = new byte[1024 * 1024];

                    this.fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
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
                                    int logType = 1;
                                    if (indexOf - startIndex > 13)
                                    {
                                        if (tempStr[startIndex + 8] == '3' && tempStr[startIndex + 9] == '-' && tempStr[startIndex + 7] == 't')
                                        {
                                            logType = 3;
                                            newStartOffset = 13;
                                        }
                                        else if (tempStr[startIndex + 8] == '2' && tempStr[startIndex + 9] == '-' && tempStr[startIndex + 7] == 't')
                                        {
                                            logType = 2;
                                            newStartOffset = 13;
                                        }
                                        else if (tempStr[startIndex + 8] == '1' && tempStr[startIndex + 9] == '-' && tempStr[startIndex + 7] == 't')
                                        {
                                            logType = 1;
                                            newStartOffset = 13;
                                        }
                                    }

                                    if (preCr)
                                    {
                                        AddLine(lineStartOffset + newStartOffset, charCount - newStartOffset, curCr, logType);
                                    }
                                    else
                                    {
                                        AppendLineStackTrace(lineStartOffset, charCount, curCr);
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
                                AddLine(lineStartOffset, bufferRemainder + (numBytesRead - startIndex), true, 1);
                                return;
                            }
                            
                            bufferRemainder += numBytesRead - startIndex;
                        }
                        else
                        {
                            // The entire content of the buffer doesn't contain \r so just add the rest of content as the last line
                            if (lastSection == true)
                            {
                                AddLine(lineStartOffset, bufferRemainder + (numBytesRead - startIndex), true, 1);
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
            this.FilterIds = new List<ushort>();
            this.List.ModelFilter = null;
            this.FilterIds.Clear();
            this.List.ClearObjects();

            if (this.fileStream != null)
            {
                this.fileStream.Dispose();
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="searchType"></param>
        public void SearchMulti(List<SearchCriteria> scs, CancellationToken ct, int numContextLines)
        {
            Task.Run(() => {

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
                        // Reset the match flag
                        ll.SearchMatches.Clear();
                        ClearContextLine(ll.LineNumber, numContextLines);

                        foreach (SearchCriteria sc in scs)
                        {
                            line = this.GetLine(ll.LineNumber);

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
                                    if (Regex.Match(line, sc.Pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled) != Match.Empty)
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
                                ll.SearchMatches.Add(sc.Id);

                                if (numContextLines > 0)
                                {
                                    this.SetContextLines(ll.LineNumber, numContextLines);
                                }
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
                }
                finally
                {
                    DateTime end = DateTime.Now;

                    OnProgressUpdate(100);
                    OnSearchComplete(end - start, matches, scs.Count, cancelled, String.Empty);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="searchType"></param>
        public void Search(SearchCriteria sc, bool cumulative, CancellationToken ct, int numContextLines)
        {
            Task.Run(() => {

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
                        if (cumulative == false)
                        {
                            // Reset the match flag
                            ll.SearchMatches.Clear();
                            //ll.IsContextLine = false;

                            ClearContextLine(ll.LineNumber, numContextLines);
                        }
                        else
                        {
                            if (ll.SearchMatches.Count > 0) {
                                continue;
                            }
                        }

                        line = this.GetLine(ll.LineNumber);

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
                                if (Regex.Match(line, sc.Pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled) != Match.Empty)
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

                        if (located == false)
                        {
                            ll.SearchMatches.Remove(sc.Id);
                        }
                        else
                        {
                            matches++;
                            ll.SearchMatches.Add(sc.Id);

                            if (numContextLines > 0)
                            {
                                this.SetContextLines(ll.LineNumber, numContextLines);
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
                }
                finally
                {
                    DateTime end = DateTime.Now;

                    OnProgressUpdate(100);
                    OnSearchComplete(end - start, matches, 1, cancelled, sc.Pattern);
                }
            });
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

        public TabPage Initialise(string filePath)
        {
            OLVColumn colLineNumber = ((OLVColumn)(new OLVColumn()));
            OLVColumn colText = ((OLVColumn)(new OLVColumn()));

            colLineNumber.Text = "Line No.";
            colLineNumber.Width = 95;
            colText.Text = "Data";

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

            colText.ImageGetter = delegate(object x)
            {
                LogLine log = (LogLine) x;
                if (log == null)
                {
                    return "";
                }

                if (log.LogType == 1)
                {
                    return "1 (2).png";
                }
                if (log.LogType == 2)
                {
                    return "1 (3).png";
                }
                if (log.LogType == 3)
                {
                    return "1 (1).png";
                }
                return "";
            };

            FormLogPage logPage = new FormLogPage();
            logPage.TopLevel = false;
            logPage.FormBorderStyle = FormBorderStyle.None;
            logPage.Visible = true;
            logPage.Left = 0;
            logPage.Top = 0;
            logPage.Dock = DockStyle.Fill;
            pageForm = logPage;
            pageForm.Log = this;
            FastObjectListView lv = logPage.GetFastObjectListView();

            lv.AllColumns.Add(colLineNumber);
            lv.AllColumns.Add(colText);
            lv.AllowDrop = true;
            lv.AutoArrange = false;
            lv.CausesValidation = false;
            lv.CellEditUseWholeCell = false;
            lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colLineNumber,
            colText});
            //lv.ContextMenuStrip = this.contextMenu;
            lv.Dock = System.Windows.Forms.DockStyle.Fill;
            //lv.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lv.FullRowSelect = true;
            lv.GridLines = true;
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
            

            this.List = lv;
            TabPage tp = new TabPage();
            tp.Controls.Add(logPage);
            tp.Location = new System.Drawing.Point(4, 33);
            tp.Name = "tabPage" + this.Guid;
            tp.Padding = new System.Windows.Forms.Padding(3);
            tp.Size = new System.Drawing.Size(1685, 946);
            tp.TabIndex = 0;
            tp.Text = "Loading...";
            tp.UseVisualStyleBackColor = true;
            tp.Tag = this.Guid;
            tp.ToolTipText = filePath;

            return tp;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetContextMenu(ContextMenuStrip ctx)
        {
            this.List.ContextMenuStrip = ctx;
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
                            lineBytes = Encoding.ASCII.GetBytes(lineStr);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="charCount"></param>
        private void AddLine(long offset, int charCount, bool endCr, int logType)
        {           
            LogLine ll = new LogLine();
            ll.Offset = offset;
            ll.CharCount = charCount;
            ll.LineNumber = this.LineCount;
            ll.IsCrLine = endCr;
            ll.LogType = logType;
            this.Lines.Add(ll);
            if (charCount > this.LongestLine.CharCount)
            {
                this.LongestLine.CharCount = charCount;
                this.LongestLine.LineNumber = ll.LineNumber;
            }

            this.LineCount++;
            if (logType == 1)
            {
                TypeInfoCount++;
            }
            else if (logType == 2)
            {
                TypeWarningCount++;
            }
            else if (logType == 3)
            {
                TypeErrorCount++;
            }
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

                ll.StackTraceCharCount += charCount;
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
            catch (Exception){}

            //return Regex.Replace(Encoding.ASCII.GetString(buffer), "[\0-\b\n\v\f\x000E-\x001F\x007F-ÿ]", "", RegexOptions.Compiled);
            var str = Encoding.UTF8.GetString(buffer);
            str = GetPureLines(str, out this.Lines[lineNumber].TagPosInfos);
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
            catch (Exception) { }

            //return Regex.Replace(Encoding.ASCII.GetString(buffer), "[\0-\b\n\v\f\x000E-\x001F\x007F-ÿ]", "", RegexOptions.Compiled);
            return GetLine(lineNumber) + "\n" + Encoding.UTF8.GetString(buffer);
        }

        #region HTMLTag

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

        private string GetPureLines(string input, out List<int> posList)
        {
            m_StringBuilder.Length = 0;
            m_TagStack.Clear();
            posList = null;

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
                            posList = null;
                            return input;
                        }
                    }

                    if (posList == null)
                    {
                        posList = new List<int>();
                    }
                    posList.Add(oldPos);
                    posList.Add(pos);

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
                posList = null;
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

        private int GetOriginalCharIndex(int idx, List<int> posList)
        {
            if (posList == null || posList.Count == 0)
            {
                return idx;
            }

            int idx2 = 0;
            for (int i = 0; i < posList.Count && (i + 1) < posList.Count;)
            {
                int idx1 = idx2;
                if ((i - 1) > 0)
                {
                    idx2 += posList[i] - posList[i - 1] - 1;
                }
                else
                {
                    idx2 = posList[i] - 1;
                }

                if (idx >= idx1 && idx <= idx2)
                {
                    if ((i - 1) > 0)
                    {
                        return posList[i - 1] + idx - idx1;
                    }

                    return idx;
                }

                i += 2;
            }

            return posList[posList.Count - 1] + idx - idx2;
        }

//        private void SearchIndexToTagIndex(EntryInfo entryInfo, int searchLength)
//        {
//            if (entryInfo.searchIndex == -1)
//            {
//                return;
//            }
//
//            entryInfo.searchEndIndex = GetOriginalCharIndex(entryInfo.searchIndex + searchLength,
//                entryInfo.tagPosInfos);
//            entryInfo.searchIndex = GetOriginalCharIndex(entryInfo.searchIndex, entryInfo.tagPosInfos);
//        }

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
        private void OnSearchComplete(TimeSpan duration, long matches, int numTerms, bool cancelled, string searchText)
        {
            SearchComplete?.Invoke(this, this.FileName, duration, matches, numTerms, cancelled, searchText);
        }

        public void OnProgressCancel()
        {
            ProgressCancel?.Invoke(this, 0);
        }

        public void OnSearchBegin(string text)
        {
            SearchBegin?.Invoke(this, text);
        }
        #endregion
    }
}
