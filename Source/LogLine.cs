using System.Drawing;

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
        public bool IsTerms { get; set; } = true;   // 多重条件过滤
        public bool IsCurSearch { get; set; }
        public bool IsContextLine { get; set; } = false;    // 上下文功能
        public long StackTraceOffset { get; set; } = 0;
        public int StackTraceCharCount { get; set; } = 0;
        public bool IsCrLine { get; set; } = false;
        public Global.LogType LogType { get; set; } = 0;
        public Color ForeColor { get; set; }       // 前景色
        #endregion
    }
}
