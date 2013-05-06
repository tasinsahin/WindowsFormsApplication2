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
    public partial class FormStore : DevExpress.XtraEditors.XtraForm
    {
        public FormStore()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormStore_Closing);
        }

        private void FormStore_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public bool Cancel { get; set; }
        storeOP storeOP = new storeOP();
        DataTable storeTable = new DataTable();


        private void FormStore_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        public void formLoad()
        {
            makeFillSearchers();
            storeTable.Clear();
            storeTable = storeOP.createStoreTable();
            dataGridView1.DataSource = storeTable;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        public void makeFillSearchers()
        {
            textBox1.Text = "Koda Göre";
            textBox2.Text = "Ad'a Göre";
            textBox3.Text = "Adet'e Göre";
            textBox4.Text = "İşlem Türü'ne Göre";
            dateTimePicker1.Value = System.DateTime.Now;
            dateTimePicker2.Value = System.DateTime.Now;
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

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox4.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table = storeOP.chargeListByVariable(textBox1.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = storeOP.chargeListByVariable(textBox2.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = storeOP.chargeListByVariable(textBox3.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = storeOP.chargeListByVariable(textBox4.Text, 3);
            dataGridView1.DataSource = table;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = storeOP.chargeListByDate(dateTimePicker1.Value, dateTimePicker2.Value, 4);
            dataGridView1.DataSource = table;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = storeOP.chargeListByDate(dateTimePicker1.Value, dateTimePicker2.Value, 4);
            dataGridView1.DataSource = table;
        }
    }
}
