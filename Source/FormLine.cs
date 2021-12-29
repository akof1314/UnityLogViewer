using System;
using System.Windows.Forms;
using DarkUI.Forms;

namespace LogViewer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormLine : DarkForm
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public FormLine(string line)
        {
            InitializeComponent();

            textLine.Text = line;
        }
        #endregion

        #region Button Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
