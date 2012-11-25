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
    public partial class FormBuy : DevExpress.XtraEditors.XtraForm
    {
        public FormBuy()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormBuy_Closing);
        }
        public bool Cancel { get; set; }
        private void FormBuy_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormBuy_Load(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = false ;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button15_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox4.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox4.Visible = false;
        }
    }
}
