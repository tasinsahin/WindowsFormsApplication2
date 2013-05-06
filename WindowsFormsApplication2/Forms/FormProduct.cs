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
    public partial class FormProduct : DevExpress.XtraEditors.XtraForm
    {
        public FormProduct()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.Form4_Closing);
        }
        public bool Cancel { get; set; }  
        public bool newProduct; // yeni product mi, update mi? tutuyor
        public bool ProductSelectedFromGrid;
        productOP productOP = new productOP();
        DataTable productTable = new DataTable();
        bool error1; bool error2; bool error3; bool error4; bool error5; bool error6;

        private void Form4_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        private void formLoad()
        {
            makeFillSearchers();
            productTable.Clear();
            grb2.Visible = false;
            productTable = productOP.createProductTable();
            dataGridView1.DataSource = productTable;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newProduct = true;
            grb1.Visible = false;
            grb2.Visible = true;
            callgroupbox3();
            textBox6.Enabled = false;
            grb2.Text = "Ürün Ekle";
            
        }

        private void callgroupbox3()
        {

            if (newProduct)
            {
                grb1.Visible = false;
                MakeEmptyGroupbox3();
                comboBox1.DataSource = productOP.CreateProductBrandList();
                grb2.Visible = true;

            }
            else if (!newProduct)
            {
                grb2.Visible = true;
                grb1.Visible = false;
                MakeFillGroupbox3();
            }
        }

        private void MakeFillGroupbox3()
        {
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void MakeEmptyGroupbox3()
        {
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            textBox11.Text = "";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
          bool isInteger;
          isInteger= control.integerControl(textBox9.Text);
          if (isInteger)
          {
              isInteger = control.integerControl(textBox11.Text);
              if (isInteger)
              {
                  if (newProduct)
                  {
                      if (textBox11.Text != String.Empty )
                      {
                          if (textBox9.Text != String.Empty)
                          {
                              product product = new product();

                              product.name = textBox7.Text.ToString();
                              product.grup = textBox8.Text.ToString();
                              product.price = Convert.ToDecimal(textBox9.Text);
                              product.brand = Convert.ToString(comboBox1.Text);
                              product.discount = Convert.ToInt32(textBox11.Text);
                              productOP.productAdd(product);
                              MessageBox.Show("Kayıt işlemi başarıyla gerçelşeştirildi", "Kayıt işlemi");
                              formLoad();
                              grb1.Visible = true;
                              grb2.Visible = false;
                          }
                          else
                          {
                              errorProvider1.SetError(textBox9, "Sayı Giriniz");
                          }
                      }
                      else
                      {
                          errorProvider1.SetError(textBox11, "Sayı Giriniz");
                      }

                  }
                  else
                  {
                      product product = new product();

                      product.code = Convert.ToInt32(textBox6.Text);
                      product.name = textBox7.Text.ToString();
                      product.grup = textBox8.Text.ToString();
                      product.price = Convert.ToDecimal(textBox9.Text);
                      product.brand = Convert.ToString(comboBox1.Text);
                      product.discount = Convert.ToInt32(textBox11.Text);

                      productOP.productUpdate(product);
                      MessageBox.Show("Güncelleme işlemi başarıyla gerçekleştirildi", "Güncelleme işlemi");
                      formLoad();
                      grb1.Visible = true;
                  }
              }
              else
              {
                  errorProvider1.SetError(textBox11, "Sayı Giriniz");
              }
          }
          else
          {
              errorProvider1.SetError(textBox9, "Sayı giriniz");
          }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    DialogResult result = MessageBox.Show("Ürünü silmek üzeresiniz", "Silmek istediğinizden emin misiniz?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        productOP.productDelete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                        MessageBox.Show("Silme işlemi başarıyla tamamlandı", "Silme işlemi");
                        formLoad();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız", "Seçim yapmadınız");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    newProduct = false;
                    callgroupbox3();
                    textBox6.Enabled = false;
                    grb2.Text = "Ürün Düzenle";
                }
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız", "Ürün seçmediniz");
            }

        }

        private void grb2_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void makeFillSearchers()
        {
            textBox1.Text = "Kod'a Göre";
            textBox2.Text = "Ad'a Göre";
            textBox3.Text = "Grup'a Göre";
            textBox4.Text = "Fiyat'a Göre";
            textBox5.Text = "Marka'ya Göre";
            textBox13.Text = "İskonto'ya Göre";
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

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox5.Text = "";
        }

        private void textBox13_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox13.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox1.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox2.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox3.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox4.Text, 3);
            dataGridView1.DataSource = table;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox5.Text, 4);
            dataGridView1.DataSource = table;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox13.Text, 5);
            dataGridView1.DataSource = table;
        }
    }
}
