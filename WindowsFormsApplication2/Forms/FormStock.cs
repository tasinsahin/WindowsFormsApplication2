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
        productOP productOP = new productOP();
        stockOP stockOP = new stockOP();
        DataTable stockTable = new DataTable();
        private void FormStok_Closing(object sender, CancelEventArgs e)
        {
         	e.Cancel = true;
            this.Hide();
        }

        public bool Cancel { get; set; }
        public void FormStok_Load(object sender, EventArgs e)
        {
            formLoad();

        }

        public void formLoad()
        {
            makeFillSearchers();
            stockTable.Clear();
            stockTable= productOP.createProductStockTable();
            dataGridView1.DataSource = stockTable;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isInteger = control.integerControl(textBox8.Text);
            if (textBox8.Text != String.Empty)
            {
                if (isInteger)
                {
                    if (dataGridView1.CurrentRow.Selected)
                    {
                        if (dataGridView1.Rows.Count > 1)
                        {
                            int productid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                            int amount2 = Convert.ToInt32(textBox8.Text);
                            int amount = -amount2;
                            stockOP.stockDecrease(productid, amount, System.DateTime.Now);
                            MessageBox.Show("başarıyla azaltıldı", "ürün stok azlatımı");
                            formLoad();
                            textBox8.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Ürün seçiniz", "Ürün seçmediniz");
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox8, "Sayı Giriniz");
                }
            }
            else
            {
                errorProvider1.SetError(textBox8, "Boş Giremezsiniz");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool isInteger = control.integerControl(textBox7.Text);
            if (textBox7.Text != String.Empty)
            {
                if (isInteger)
                {
                    if (dataGridView1.CurrentRow.Selected)
                    {
                        if (dataGridView1.Rows.Count > 1)
                        {
                            int productid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                            int amount2 = Convert.ToInt32(textBox7.Text);
                            int amount = amount2;
                            stockOP.stockIncrease(productid, amount, System.DateTime.Now);
                            MessageBox.Show("başarıyla attırıldı", "ürün stok arttırımı");
                            formLoad();
                            textBox7.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("ürün seçiniz", "ürün seçmediniz");
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox7, "Sayı Giriniz");
                }
            }
            else
            {
                errorProvider1.SetError(textBox7, "Boş Giremezsiniz");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox1.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void makeFillSearchers()
        {
            textBox1.Text = "Kod'a Göre";
            textBox2.Text = "Ad'a Göre";
            textBox3.Text = "Fiyat'a Göre";
            textBox4.Text = "Grub'a Göre";
            textBox9.Text = "Marka'ya Göre";
            textBox6.Text = "İskonto'ya Göre";
            textBox5.Text = "Adet'e Göre";
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

        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox9.Text = "";
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox6.Text = "";
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox5.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table =productOP.productStockListByVariable(textBox1.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productStockListByVariable(textBox2.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productStockListByVariable(textBox3.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productStockListByVariable(textBox4.Text, 3);
            dataGridView1.DataSource = table;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productStockListByVariable(textBox9.Text, 4);
            dataGridView1.DataSource = table;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productStockListByVariable(textBox6.Text, 5);
            dataGridView1.DataSource = table;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productStockListByVariable(textBox5.Text, 6);
            dataGridView1.DataSource = table;
        }
    }
}
   