using System;

namespace LogViewer
{
    public class Global
    {
        #region Enums
        /// <summary>
        /// 
        /// </summary>
        public enum SearchType
        {
            SubStringCaseInsensitive = 0,
            SubStringCaseSensitive = 1,
            RegexCaseInsensitive = 2,
            RegexCaseSensitive = 3,
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ViewMode
        {
            Standard = 1,
            FilterShow = 2,
            FilterHide = 3
        }

        public enum LogType
        {
            None = 0,
            Info = 1,
            Warning = 2,
            Error = 4,
        }
        #endregion
    }
}
