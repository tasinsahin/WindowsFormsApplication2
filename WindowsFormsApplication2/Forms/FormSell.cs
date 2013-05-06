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
    public partial class FormSell : DevExpress.XtraEditors.XtraForm
    {
        public FormSell()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormBuy_Closing);
        }
        customer customer = new customer();
        customerOP customerOP = new customerOP();
        product product = new product();
        productOP productOP = new productOP();
        productList productList = new productList();
        productListOP productListOP = new productListOP();
        productOrder productOrder = new productOrder();
        productOrderOP productOrderOP = new productOrderOP();
        stockOP stockOP = new stockOP();
        bool existing=false;

        int[] productArray = new int[100];

        DataTable productTable = new DataTable();
        DataTable customerTable = new DataTable();
        DataTable dynamicTable = new DataTable();
        DataTable productTable2 = new DataTable();

        private void FormBuy_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private void FormSell_Load(object sender, EventArgs e)
        {
            formLoad();

        }

        public void formLoad()
        {
            makeFillSearchers();
            makeFillSearchers2();
            makeFillSearchers3();
            makeFillSearchers4();

            productTable.Clear();
            dynamicTable.Clear();
            customerTable.Clear();
            productTable2.Clear();
            groupBox1.Parent = this;
            groupBox2.Parent = this;
            groupBox4.Parent = this;

            label2.Text = "";

            productTable = productOP.createProductTable();
            customerTable = customerOP.createCustomerTable();
            dynamicTable = productTable.Clone();
            dynamicTable.Columns.Add("amount", typeof(int));
            productTable2 = productOrderOP.productOrderSellView2();

            dataGridView1.DataSource = productTable;
            dataGridView2.DataSource = dynamicTable;
            dataGridView3.DataSource = customerTable;
            dataGridView4.DataSource = productTable2;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView3.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView4.EditMode = DataGridViewEditMode.EditProgrammatically;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow.Selected)
            {
                customer.code = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                label2.Text = Convert.ToString(dataGridView3.CurrentRow.Cells[1].Value)+" "+Convert.ToString(dataGridView3.CurrentRow.Cells[2].Value);
                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
            else
            {
                label2.Text = "";
                MessageBox.Show("Lütfen seçim yapınız","Seçim yapmadınız");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    bool isInteger = control.integerControl(textBox17.Text);
                    if (isInteger)
                    {
                        existing = false;
                        for (int i = 0; i < dynamicTable.Rows.Count; i++)
                        {
                         if (Convert.ToInt32(dynamicTable.Rows[i][0]) == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value))
                           {
                               dynamicTable.Rows[i][6] = Convert.ToInt32(dynamicTable.Rows[i][6]) + Convert.ToInt32(textBox17.Text);
                               existing = true;
                               break;
                           }
                         }
                        if (!existing)
                        {
                           int code = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                           string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                           string group = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                           decimal price = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[3].Value);
                           string brand = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                           int discount = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);

                           dynamicTable.Rows.Add(code, name, group, price, brand, discount, Convert.ToInt32(textBox17.Text));
                        }
                        dataGridView2.DataSource = dynamicTable;
                    }
                    else
                    {
                        errorProvider1.SetError(textBox17, "Sayı Giriniz");
                    }
                }
            }
            else
            {
                MessageBox.Show("lütfen seçim yapınız", "Seçim yapmadınız");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (customer.code != 0)
                {
                    if (dataGridView2.Rows.Count > 1)
                    {
                        if (control.integerControl(textBox13.Text))
                        {
                            bool isInteger2 = control.integerControl(textBox13.Text);
                            if (isInteger2)
                            {
                                DialogResult result = MessageBox.Show("Satış yapılsın mı?", "Satış işlemi", MessageBoxButtons.YesNo);

                                if (result == DialogResult.Yes)
                                {

                                    productOrder.customerID = customer.code;  // product orderı ekliyor dbye
                                    productOrder.dateTake = System.DateTime.Now;
                                    productOrder.dateCarried = System.DateTime.Now;
                                    productOrder.status = 0;
                                    productList.ProductOrderID = productOrderOP.productOrderSellAdd(productOrder);

                                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++) // ürün sayısı kadar product listesini ekliyor dbye
                                    {
                                        productList.productCode = Convert.ToInt32(dynamicTable.Rows[i][0]);
                                        productList.discount = Convert.ToInt32(dynamicTable.Rows[i][5]);
                                        productList.price = Convert.ToDecimal(dynamicTable.Rows[i][3]);

                                        DataTable table = stockOP.createStockTable();
                                        int productCode = Convert.ToInt32(productList.productCode);

                                        int amount = Convert.ToInt32(dynamicTable.Rows[i][6]);
                                        int productID = Convert.ToInt32(dynamicTable.Rows[i][0]);
                                        stockOP.stockDecrease(productID, -amount, System.DateTime.Now);

                                        productListOP.productListAdd(productList);
                                    }
                                    bool isInteger = control.integerControl(textBox13.Text);
                                    if (textBox13.Text == String.Empty)
                                    {
                                        errorProvider1.SetError(textBox13, "Boş değer Giremezsiniz");
                                    }
                                    else if (isInteger)
                                    {
                                        if (textBox13.Text == "0")
                                        {
                                        }
                                        else
                                        {
                                            customerOP.CustomerPay(customer.code, System.DateTime.Now, Convert.ToDecimal(textBox13.Text)); // customer ödemesini yapıyor!
                                        }
                                    }

                                    MessageBox.Show("başarıyla gerçekleşti", "Satış İşlemi");
                                    customer.code = 0;
                                    formLoad();
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(textBox13, "Sayı Giriniz");
                            }
                        }
                        else if (!control.integerControl(textBox13.Text))
                        {
                            errorProvider1.SetError(textBox13, "Sayı Giriniz");
                        }         
           
                    }
                    else
                    {
                        MessageBox.Show("Ürün Seçmediniz", "Seçim İşlemi");
                    }

                }
                else
                {
                    MessageBox.Show("Müşteri Seçiniz", "Müşteri Seçmediniz");
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                if (dataGridView2.CurrentRow.Selected)
                {
                    if (dataGridView1.CurrentRow.Index != Convert.ToInt32(dataGridView1.Rows.Count) - 1)
                    {
                        for (int i = 0; i < dynamicTable.Rows.Count; i++)
                        {
                            if (dynamicTable.Rows[i][0].ToString() == dataGridView2.CurrentRow.Cells[0].Value.ToString())
                            {
                                dynamicTable.Rows.RemoveAt(i);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("seçim yapınız", "Seçim yapmadınız");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
        }

        #region urunEkleUpdate
        public void makeFillSearchers()
        {
            textBox1.Text = "Kod'a Göre";
            textBox2.Text = "Ad'a Göre";
            textBox4.Text = "Grup'a Göre";
            textBox3.Text = "Marka'ya Göre";

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

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox4.Text = "";
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox3.Text = "";
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox4.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox3.Text, 4);
            dataGridView1.DataSource = table;
        }
        #endregion
        #region SatisinKendisi
        public void makeFillSearchers2() 
        {
            textBox8.Text = "Kod'a Göre";
            textBox7.Text = "Ad'a Göre";
            textBox6.Text = "Grup'a Göre";
            textBox5.Text = "Marka'ya Göre";
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

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox6.Text = "";
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox5.Text = "";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox8.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox7.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox6.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox5.Text, 4);
            dataGridView1.DataSource = table;
        }
        #endregion
        #region SatisDokumu
        public void makeFillSearchers4()
        {
            textBox18.Text = "Kod'a Göre";
            textBox19.Text = "Ad'a Göre";
            textBox20.Text = "Sipariş Kodu'na Göre";
            textBox21.Text = "Teslim Durumu'na Göre";
        }
        private void textBox18_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox18.Text = "";
        }

        private void textBox19_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox19.Text = "";
        }

        private void textBox20_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox20.Text = "";
        }

        private void textBox21_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox21.Text = "";
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productOrderSellView2ByVariable(textBox18.Text,0);
            dataGridView4.DataSource = table;
            
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productOrderSellView2ByVariable(textBox19.Text, 1);
            dataGridView4.DataSource = table;
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productOrderSellView2ByVariable(textBox20.Text, 4);
            dataGridView4.DataSource = table;
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productOrderSellView2ByVariable(textBox21.Text, 7);
            dataGridView4.DataSource = table;
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productOrderSellView2ByDate(dateTimePicker2.Value,dateTimePicker1.Value,5);
            dataGridView4.DataSource = table;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productOrderSellView2ByDate(dateTimePicker2.Value, dateTimePicker1.Value, 5);
            dataGridView4.DataSource = table;
        }
        #endregion
        #region musteriSec
        public void makeFillSearchers3()
        {
            textBox9.Text = "Kod'a Göre";
            textBox10.Text = "Ad'a Göre";
            textBox11.Text = "Soyad'a Göre";
            textBox12.Text = "Banka'ya Göre";
            textBox14.Text = "Semt'e Göre";
            textBox15.Text = "Mahalle'ye Göre";
            textBox16.Text = "Apartman'a Göre";
        }
        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox9.Text = "";
        }

        private void textBox10_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox10.Text = "";
        }

        private void textBox11_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox11.Text = "";
        }

        private void textBox12_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox12.Text = "";
        }
        private void textBox14_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox14.Text = "";
        }
        private void textBox15_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox15.Text = "";
        }
        private void textBox16_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox16.Text = "";
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox9.Text, 0);
            dataGridView3.DataSource = table;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox10.Text, 1);
            dataGridView3.DataSource = table;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox11.Text, 2);
            dataGridView3.DataSource = table;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox12.Text, 5);
            dataGridView3.DataSource = table;
        }
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox14.Text, 24);
            dataGridView3.DataSource = table;
        }
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox15.Text, 31);
            dataGridView3.DataSource = table;
        }
        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox16.Text, 28);
            dataGridView3.DataSource = table;
        }
        #endregion
    }
}