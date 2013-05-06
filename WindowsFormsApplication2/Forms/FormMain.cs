using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlClient;   

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
        productOP productOP = new productOP();
        serviceOP serviceOP = new serviceOP();
        personOP personOP = new personOP();
        chargeOP chargeOP = new chargeOP();
        deptOP deptOP = new deptOP();
        DataTable serviceTable = new DataTable();
        DataTable productTable = new DataTable();
        DataTable personTable = new DataTable();
        DataTable chargeTable = new DataTable();
        DataTable deptTable = new DataTable();
        private void FormMain_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public  void FormMain_Load(object sender, EventArgs e)
        {
            formLoad();
            
        }

        public void formLoad()
        {
            makeFillSearchers();
            makeFillSearchers2();
            makeFillSearchers3();
            makeFillSearchers4();
            makeFillSearchers5();

            serviceTable.Clear();
            productTable.Clear();
            personTable.Clear();
            chargeTable.Clear();
            deptTable.Clear();

            serviceTable = serviceOP.createServiceTable();
            productTable = productOP.createProductTable();
            personTable = personOP.createPersonTable();
            chargeTable = chargeOP.createChargeTable();
            deptTable = deptOP.createDeptTable();

            dataGridView3.DataSource = serviceTable;
            dataGridView5.DataSource = productTable;
            dataGridView4.DataSource = personTable;
            dataGridView1.DataSource = chargeTable;
            dataGridView2.DataSource = deptTable;


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView5.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView5.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.AutoResizeColumnHeadersHeight();
            dataGridView2.AutoResizeColumnHeadersHeight();
            dataGridView3.AutoResizeColumnHeadersHeight();
            dataGridView4.AutoResizeColumnHeadersHeight();
            dataGridView5.AutoResizeColumnHeadersHeight();
        }
        #region region1
        public void makeFillSearchers()
        {
            textBox1.Text = "Ad'a Göre";
            textBox2.Text = "Soyad'a Göre";
            textBox3.Text = "Tutar'a Göre";
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox1.Text = "";
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox2.Text = "";
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox3.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table = chargeOP.chargeListByVariable(textBox1.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = chargeOP.chargeListByVariable(textBox2.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = chargeOP.chargeListByVariable(textBox3.Text, 3);
            dataGridView1.DataSource = table;
        }  
        #endregion
        #region region2
        public void makeFillSearchers2()
        {
            textBox9.Text = "Servis's Göre";
            textBox8.Text = "Müşteri'ye Göre";
            textBox7.Text = "Saat'e Göre";
        }
        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox9.Text = "";
        }

        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox8.Text = "";
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox7.Text = "";
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.serviceListByVariable(textBox9.Text, 1);
            dataGridView3.DataSource = table;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.serviceListByVariable(textBox8.Text, 3);
            dataGridView3.DataSource = table;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.serviceListByVariable(textBox7.Text, 5);
            dataGridView3.DataSource = table;
        }
        #endregion
        #region region3
        public void makeFillSearchers3()
        {
            textBox15.Text = "Kod'a Göre";
            textBox14.Text = "Ad'a Göre";
            textBox13.Text = "Marka'ya göre";
        }
        private void textBox15_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox15.Text = "";
        }

        private void textBox14_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox14.Text = "";
        }

        private void textBox13_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox13.Text = "";
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox15.Text, 0);
            dataGridView5.DataSource = table;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox14.Text, 1);
            dataGridView5.DataSource = table;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox13.Text, 4);
            dataGridView5.DataSource = table;
        }
        #endregion
        #region region4
        public void makeFillSearchers4()
        {
            textBox6.Text = "Ad'a Göre";
            textBox5.Text = "Sorumlu'ya Göre";
            textBox4.Text = "Tutar'a Göre";
        }
        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox6.Text = "";
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox5.Text = "";
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox4.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DataTable table = deptOP.deptListByVariable(textBox6.Text, 1);
            dataGridView2.DataSource = table;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable table = deptOP.deptListByVariable(textBox5.Text, 2);
            dataGridView2.DataSource = table;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = deptOP.deptListByVariable(textBox4.Text, 3);
            dataGridView2.DataSource = table;
        }
        #endregion
        #region region5
        public void makeFillSearchers5()
        {
            textBox12.Text = "Kod'a Göre";
            textBox11.Text = "Ad'a Göre";
        }

        private void textBox12_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers5();
            textBox12.Text = "";
        }

        private void textBox11_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers5();
            textBox11.Text = "";
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            DataTable table = personOP.personListByVariable(textBox12.Text, 0);
            dataGridView4.DataSource = table;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            DataTable table = personOP.personListByVariable(textBox11.Text, 1);
            dataGridView4.DataSource = table;
        }
        #endregion

    }
}
