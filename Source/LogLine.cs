using System.Collections.Generic;

namespace LogViewer
{
    /// <summary>
    /// 
    /// </summary>
    internal class LogLine
    {
        #region Member Variables/Properties
        public int LineNumber { get; set; } = 0;
        public int CharCount { get; set; } = 0;
        public long Offset { get; set; } = 0;
        public bool IsTerms { get; set; }
        public bool IsCurSearch { get; set; }
        public bool IsContextLine { get; set; } = false;
        public long StackTraceOffset { get; set; } = 0;
        public int StackTraceCharCount { get; set; } = 0;
        public bool IsCrLine { get; set; } = false;
        public int LogType { get; set; } = 0;
        public List<int> TagPosInfos;
        #endregion
    }
}
