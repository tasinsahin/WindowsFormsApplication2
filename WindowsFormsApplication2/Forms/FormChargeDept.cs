using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsApplication2
{
    public partial class FormCharge : DevExpress.XtraEditors.XtraForm
    {
        public FormCharge()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormAlacak_Closing);
        }

        private void FormAlacak_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide(); ;
        }

        private void FormAlacak_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false; ;
            groupBox2.Visible = false;
            groupBox2.Parent = this;
            groupBox1.Parent = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }
    }
}
