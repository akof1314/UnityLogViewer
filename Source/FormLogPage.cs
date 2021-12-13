using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace LogViewer
{
    public partial class FormLogPage : Form
    {
        internal LogFile Log { get; set; }

        public FormLogPage()
        {
            InitializeComponent();
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

        private void statusProgress_Click(object sender, EventArgs e)
        {
            Log.OnProgressCancel();
        }
    }
}
