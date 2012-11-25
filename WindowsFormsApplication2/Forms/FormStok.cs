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
    public partial class FormStok : DevExpress.XtraEditors.XtraForm
    {
        public FormStok()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormStok_Closing);
        }

        private void FormStok_Closing(object sender, CancelEventArgs e)
        {
         	e.Cancel = true;
            this.Hide();
        }
        public bool Cancel { get; set; }
        private void FormStok_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox4.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox1.Visible = false;
        }
    }
}
   