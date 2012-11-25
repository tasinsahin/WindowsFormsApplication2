using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraBars;
using System.Reflection.Emit;

namespace WindowsFormsApplication2
{
    public partial class FormBill : DevExpress.XtraEditors.XtraForm
    {
        public FormBill()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormBill_Closing);
        }
        public bool Cancel { get; set; }
        private void FormBill_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        
        private void FormBill_Load(object sender, EventArgs e)
        {/*
            yeni.MdiParent = this;
            yeni2.MdiParent = this;
            yeni.Show();
            yeni2.Show();*/
            // bak bakalım iç içe mdi  parent yapılıyor muymş?

            groupBox3.Visible = false;
           /*
            BarManager barManager = new BarManager();
            barManager.Form = this;
            barManager.AllowCustomization = false;

            // Create a bar with a New button.
            barManager.BeginUpdate();
            Bar bar = new Bar(barManager, "My Bar");
            bar.DockStyle = BarDockStyle.Top;

            barManager.MainMenu = bar;

            BarItem barItem0 = new BarButtonItem(barManager, "Anasayfa    ");
            barItem0.ItemClick += new ItemClickEventHandler(barItem0_ItemClick);
            bar.ItemLinks.Add(barItem0);
            BarItem barItem = new BarButtonItem(barManager, "Müşteri    ");
            barItem.ItemClick += new ItemClickEventHandler(barItem_ItemClick);
            bar.ItemLinks.Add(barItem);

            barManager.EndUpdate();
            // Create an XtraTabbedMdiManager that will manage MDI child windows.
            XtraTabbedMdiManager mdiManager = new XtraTabbedMdiManager();
            mdiManager.MdiParent = this; */



        }

      /*  private void barItem0_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            yeni.Focus();
            yeni.Text = "Anasayfa  |  ";
            yeni.MdiParent = this;
            yeni.Show();
            yeni.Focus();
        }

        private void barItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            // formCustomer.Focus();
            yeni2.Text = "Müşteri  |  ";
            yeni2.MdiParent = this;
            yeni2.Show();
            yeni2.Focus();
            //
        } */

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox3.Visible = true;
            button10.Enabled = false;
            button11.Enabled = true;
        }

        private void button11_Click_2(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox3.Visible = false;
            button10.Enabled = true;
            button11.Enabled = false;
        }
    }
}
