using System;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Forms;
using LogViewer.ControlEx;

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

        public static DialogResult ShowErrorDialog(
            string message)
        {
            using (DarkMessageBoxDpi darkMessageBox = new DarkMessageBoxDpi(message, "提示", DarkMessageBoxIcon.Error, DarkDialogButton.Ok))
            {
                return darkMessageBox.ShowDialog();
            }
        }
    }
}
