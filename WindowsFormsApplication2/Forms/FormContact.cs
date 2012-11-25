using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace WindowsFormsApplication2
{
    public partial class FormContact : DevExpress.XtraEditors.XtraForm
    {
        public FormContact()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormContact_Closing);
        }
        public bool Cancel { get; set; }
        private void FormContact_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormContact_Load(object sender, EventArgs e)
        {
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.tasinsahin.com");
        }
    }
}
