using System.Windows.Forms;
using DarkUI.Forms;

namespace LogViewer
{
    public partial class FormAbout : DarkForm
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public FormAbout()
        {
            InitializeComponent();

            lblApp.Text = Application.ProductName;
            lblVer.Text = "v" + Application.ProductVersion;
        }
        #endregion


        #region Button Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
