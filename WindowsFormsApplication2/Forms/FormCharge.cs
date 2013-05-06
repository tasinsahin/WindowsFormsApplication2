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
        chargeOP chargeOP = new chargeOP();
        customerOP customerOP = new customerOP();
        DataTable chargetable = new DataTable();

        private void FormAlacak_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide(); 
        }

        private void FormAlacak_Load(object sender, EventArgs e)
        {
            formLoad();

        }

        public void formLoad()
        {
            makeFillSearchers();
            chargetable.Clear();
            chargetable = chargeOP.createChargeTable();
            dataGridView1.DataSource = chargetable;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isInteger = control.integerControl(textBox8.Text);
            if (isInteger)
            {
                if (dataGridView1.Rows.Count > 1)
                {
                    if (dataGridView1.CurrentRow.Selected)
                    {
                        takeMoney();
                    }
                }
            }
            else
            {
                errorProvider1.SetError(textBox8, "Sayı Giriniz");
            }
            
        }

        public void takeMoney()
        {
            if (textBox8.Text.Length > 0)
            {
                if (Convert.ToInt32(textBox8.Text) != 0)
                {
                    // customer id sini al
                    customerOP.CustomerPay(Convert.ToInt32(dataGridView1.CurrentRow.Cells["Kodu"].Value), System.DateTime.Now, Convert.ToInt32(textBox8.Text));
                    MessageBox.Show("Başarıyla yapıldı", "Ödeme İşlemi");
                    formLoad();
                }
                else
                {
                    errorProvider1.SetError(textBox8, "Sıfırdan büyük miktar giriniz");
                }
            }
            else
            {
                errorProvider1.SetError(textBox8, "Miktar giriniz");
            }
        }
        public void makeFillSearchers()
        {
            textBox1.Text = "Kodu'na Göre";
            textBox2.Text = "Ad'ına Göre";
            textBox3.Text = "Soyadı'na Göre";
            textBox4.Text = "Tutar'a Göre";
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
            DataTable table = chargeOP.chargeListByVariable(textBox1.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = chargeOP.chargeListByVariable(textBox2.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = chargeOP.chargeListByVariable(textBox3.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = chargeOP.chargeListByVariable(textBox4.Text, 3);
            dataGridView1.DataSource = table;
        }
    }
}
