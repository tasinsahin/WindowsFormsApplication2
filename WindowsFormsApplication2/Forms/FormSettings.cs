using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class FormSettings : DevExpress.XtraEditors.XtraForm
    {
        public FormSettings()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormSettings_Closing);
        }
        public bool Cancel { get; set; }
        private void FormSettings_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
