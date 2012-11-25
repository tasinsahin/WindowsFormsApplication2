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
    public partial class FormCash : DevExpress.XtraEditors.XtraForm
    {
        public FormCash()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormCash_Closing);
        }
        public bool Cancel { get; set; }
        private void FormCash_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private void FormCash_Load(object sender, EventArgs e)
        {

        }
    }
}
