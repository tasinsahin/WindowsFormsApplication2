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
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            InitializeComponent();
            
            this.Closing += new CancelEventHandler(this.FormMain_Closing);
            
        } 
        public bool Cancel { get; set; }
        private void FormMain_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //DataTable table1 = toDatatable.toDb<cCharge>(MasisData.Charges);
            //dataGridView1.DataSource = table1;

            //DataTable table2 = toDatatable.toDb<cDept>(MasisData.Depts);
            //dataGridView2.DataSource = table2;

            //DataTable table3 = toDatatable.toDb<cService>(MasisData.Services);
            //dataGridView3.DataSource = table3;

            //DataTable table4 = toDatatable.toDb<cPerson>(MasisData.persons);
            //dataGridView4.DataSource = table4;

            //DataTable table5 = toDatatable.toDb<cProduct>(MasisData.Products);
            //dataGridView5.DataSource = table5;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = this.Owner;
            //(f as FormFrame).formAlacak.MdiParent = this.Owner;
            FormCharge fc = new FormCharge();
            fc = ((f as FormFrame).formAlacak as FormCharge);
            fc.Show();
           
            //(f as FormFrame).formAlacak.Focus();
            //button1.Click += (f as FormFrame).barItem18_ItemClick(object sender , DevExpress.XtraBars.ItemCancelEventArgs e);
            

            
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        
    }
}
