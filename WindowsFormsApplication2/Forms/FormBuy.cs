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
        productOP productOP = new productOP();
        product product = new product();
        company company = new company();
        companyOP companyOP = new companyOP();
        DataTable Companytable = new DataTable();
        DataTable dynamicTable = new DataTable();
        DataTable productTable = new DataTable();
        DataTable productBuyTable = new DataTable();
        productOrder productOrder = new productOrder();
        productList productList = new productList();
        productOrderOP productOrderOP = new productOrderOP();
        productListOP productListOP = new productListOP();
        int code;
        string name;
        string group;
        decimal price;
        string brand;
        int discount;
        int amount;
        bool existing;
        private void FormBuy_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormBuy_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        public  void formLoad()
        {
            makeFillSearchers();
            makeFillSearchers2();
            makeFillSearchers3();
            makeFillSearchers4();

            groupBox2.Visible = false;
            groupBox1.Visible = true;
            groupBox4.Visible = false;

            groupBox1.Parent = this;
            groupBox2.Parent = this;
            groupBox4.Parent = this;

            label2.Text = "";
            productTable.Clear();
            Companytable.Clear();
            dynamicTable.Clear();
            productBuyTable.Clear();
            productTable = productOP.createProductTable();
            Companytable = companyOP.CreateCompanyTable();
            dynamicTable = productTable.Clone();
            dynamicTable.Columns.Add("amount", typeof(int));
            productBuyTable = productOrderOP.producBuyTable();
            dataGridView1.DataSource = productTable;
            dataGridView2.DataSource = dynamicTable;
            dataGridView3.DataSource = Companytable;
            dataGridView4.DataSource = productBuyTable;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView3.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView4.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
            formLoad();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
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
                            code = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                            name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                            group = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                            price = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[3].Value);
                            brand = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                            discount = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                            amount = Convert.ToInt32(textBox17.Text);

                            dynamicTable.Rows.Add(code, name, group, price, brand, discount, amount);
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(textBox17, "Sayı Giriniz");
                    }

                    dataGridView2.DataSource = dynamicTable;
                }
            }
            else
            {
                MessageBox.Show("lütfen seçim yapınız", "Seçim yapmadınız");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                if (dataGridView2.CurrentRow.Index != -1)
                {
                    if (dataGridView2.CurrentRow.Selected)
                    {
                        dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
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
                MessageBox.Show("seçim yapınız","Seçim yapmadınız");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count != 0)
            {
                if (dataGridView3.CurrentRow.Selected)
                {
                    company.code = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                    groupBox2.Visible = false;
                    groupBox1.Visible = true;
                    label2.Text = Convert.ToString(dataGridView3.CurrentRow.Cells[1].Value) + " " + Convert.ToString(dataGridView3.CurrentRow.Cells[2].Value);
                }
            }
            else
            {
                label2.Text = "";
                MessageBox.Show("Lütfen seçim yapınız", "Seçim yapmadınız");
            }
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (company.code != 0)
            {
                if (dataGridView2.Rows.Count > 1)
                {
                    productOrder.customerID = company.code;  // product orderı ekliyor dbye
                    productOrder.dateTake = System.DateTime.Now;
                    productOrder.dateCarried = System.DateTime.Now;
                    productOrder.status = 0;
                    productList.ProductOrderID = productOrderOP.productOrderBuyAdd(productOrder);
                    bool isInteger = control.integerControl(textBox13.Text);
                    if (isInteger)
                    {
                        for (int i = 0; i < dataGridView2.Rows.Count - 1; i++) // ürün sayısı kadar product listesini ekliyor dbye
                        {
                            productList.productCode = Convert.ToInt32(dynamicTable.Rows[i][0]);
                            productList.discount = Convert.ToInt32(dynamicTable.Rows[i][5]);
                            productList.price = Convert.ToDecimal(dynamicTable.Rows[i][3]);
                            productListOP.productListAdd(productList);

                            stockOP stockOP = new stockOP();
                            DataTable table = stockOP.createStockTable();
                            int productCode = Convert.ToInt32(productList.productCode);

                            int productID = Convert.ToInt32(dynamicTable.Rows[i][0]);
                            int amount = Convert.ToInt32(dynamicTable.Rows[i][6]);

                            stockOP.stockIncrease(productID, amount, System.DateTime.Now);
                        }
                        if (textBox13.Text == String.Empty)
                        {

                        }
                        else if (textBox13.Text == "0")
                        {

                        }
                        else
                        {
                            companyOP.companyPay(company.code, System.DateTime.Now, Convert.ToDecimal(textBox13.Text)); // customer ödemesini yapıyor!
                        }

                        MessageBox.Show("başarıyla gerçekleşti", "Satış İşlemi");

                        company.code = 0; // compandy code u sıfırlıyor ki, her seferinde bilinçli seçim yapsın
                        formLoad(); // formu baştan yüklüyor ki değişiklikler görüntülensin
                    }
                    else
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
               MessageBox.Show("Firma seçmediniz","Lütfen firma seçiniz");
	        }

          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox2.Visible = false;
            groupBox1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox4.Visible = false;            
        }

        #region AlisUrunEkle
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

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region AlisinKendisi
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

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region AlisDokumu

        public void makeFillSearchers3()
        {
            textBox18.Text = "Kod'a Göre";
            textBox19.Text = "Ad'a Göre";
            textBox20.Text = "Sipariş Kodu'na Göre";
            textBox21.Text = "Teslim Durumuna Göre";
        }

        private void textBox18_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox18.Text = "";
        }

        private void textBox19_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox19.Text = "";
        }

        private void textBox20_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox20.Text = "";
        }

        private void textBox21_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox21.Text = "";
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productBuyTableByVariable(textBox18.Text, 0);
            dataGridView4.DataSource = table;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productBuyTableByVariable(textBox19.Text, 1);
            dataGridView4.DataSource = table;
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productBuyTableByVariable(textBox20.Text, 2);
            dataGridView4.DataSource = table;
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productBuyTableByVariable(textBox21.Text, 5);
            dataGridView4.DataSource = table;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productBuyTableByDate(dateTimePicker1.Value, dateTimePicker2.Value, 3);
            dataGridView4.DataSource = table;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productBuyTableByDate(dateTimePicker1.Value, dateTimePicker2.Value, 3);
            dataGridView4.DataSource = table;
        }

        #endregion
        #region FirmaSec
        public void makeFillSearchers4()
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
            makeFillSearchers4();
            textBox9.Text = "";
        }

        private void textBox10_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox10.Text = "";
        }

        private void textBox11_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox11.Text = "";
        }

        private void textBox12_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox12.Text = "";
        }
        private void textBox14_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox14.Text = "";
        }
        private void textBox15_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox15.Text = "";
        }
        private void textBox16_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox16.Text = "";
        }


        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox9.Text, 0);
            dataGridView3.DataSource = table;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox10.Text, 1);
            dataGridView3.DataSource = table;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox11.Text, 2);
            dataGridView3.DataSource = table;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox12.Text, 6);
            dataGridView3.DataSource = table;

        }
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox14.Text, 25);
            dataGridView3.DataSource = table;

        }
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox15.Text, 32);
            dataGridView3.DataSource = table;

        }
        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox16.Text, 29);
            dataGridView3.DataSource = table;
        }


        #endregion
    }
}
