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
    public partial class barCode : DevExpress.XtraEditors.XtraForm
    {
        public barCode()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.barCode_Closing);
        }
        public bool Cancel { get; set; }
        private void barCode_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        


        private void barCode_Load(object sender, EventArgs e)
        {

        }
    }
}
