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
    public partial class FormOrder : DevExpress.XtraEditors.XtraForm
    {
        public FormOrder()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormOrder_Closing);
        }
        public bool Cancel { get; set; }
        public bool newProductOrder; // yeni müşteri mi, update mi? tutuyor
        public bool ProductOrderSelectedFromGrid;
        productOrderOP productOrderOP = new productOrderOP();
        customerOP customerOP = new customerOP();
        productOP productOP = new productOP();
        DataTable dynamicTableNew = new DataTable();
        DataTable dynamicTableUpdate = new DataTable();
        DataTable dynamicTable2 = new DataTable();
        DataTable tableOrder = new DataTable();
        DataTable customerTable = new DataTable();
        DataTable productTable = new DataTable();
        DataTable productTable2 = new DataTable();
        DataTable updateProductListTable = new DataTable();
        DataTable table = new DataTable();
        productListOP productListOP = new productListOP();
        int productid;
        int productamount;
        int productOrderid;
        int CustomerID;
        List<product> productArray = new List<product>();
        bool existing;
        private void FormOrder_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
       
        private void FormOrder_Load(object sender, EventArgs e)
        {
            formLoad();
            newProductOrder = true;            

        }
        public void formLoad()
        {
            makeFillSearchers();
            makeFillSearchers2();
            makeFillSearchers3();
            makeFillSearchers4();

            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox1.Visible = true;

            groupBox1.Parent = this;
            groupBox2.Parent = this;
            groupBox3.Parent = this;
            groupBox4.Parent = this;

            tableOrder.Clear();
            customerTable.Clear();
            productTable.Clear();
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;

            tableOrder = productOrderOP.createProductOrderTable();
            dataGridView1.DataSource = tableOrder;

            customerTable = customerOP.createCustomerTable();
            dataGridView4.DataSource = customerTable;

            productTable = productOP.createProductTable();
            dataGridView2.DataSource = productTable;

            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView3.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView4.EditMode = DataGridViewEditMode.EditProgrammatically;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dynamicTableNew = productTable.Clone();
            dynamicTable2 = productTable.Clone();
            dynamicTableNew.Columns.Add("adet", typeof(Int32));
            dynamicTable2.Columns.Add("adet", typeof(Int32));

            dataGridView3.DataSource = dynamicTableNew;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            groupBox1.Visible = true;

            CustomerID = 0;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formLoad();
            newProductOrder = true;
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            MakeEmptyForm();
        }

        public void MakeEmptyForm() // temizlicen dynamic gridviewi / yeni kayıt için hazırlican
        {
            dynamicTableNew.Clear();
            dynamicTableUpdate.Clear();
            dataGridView3.DataSource = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
        }
       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateOrSee();
            
        }

        private void updateOrSee()
        {

            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    newProductOrder = false;
                    MakeFillForm(); // burada seçili olan ile dynamic gridviewi  dolduracaksın
                    groupBox1.Visible = false;
                    groupBox3.Visible = false;
                    groupBox2.Visible = true;
                    groupBox4.Visible = false;

                }
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız", "Seçim yapmadınız");
            }
        }

        public void MakeFillForm() // gridviewi dolduracak seçili olan ile
        {

            dynamicTableUpdate.Dispose();
            dynamicTableNew.Dispose();
            dataGridView3.DataSource = null;

            productArray= productListOP.productListByProductOrderID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value));

            dynamicTableUpdate = dynamicTable2.Clone();
            customer customer = productListOP.customerByProductOrderID();
            CustomerID = customer.code;
            label3.Text = customer.name.ToString()+" "+customer.surname.ToString();

            for (int i = 0; i <  productArray.Capacity; i++)
            {
                    // null product geliyor, bunları filtrelemen lazım!
                    if (productArray[i].productOrderId == Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value))
                    {
                        dynamicTableUpdate.Rows.Add(productArray[i].code, productArray[i].name, productArray[i].grup, productArray[i].price, productArray[i].brand, productArray[i].discount, productArray[i].amount);                          
                    }
            }
            dataGridView3.DataSource = dynamicTableUpdate;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    DialogResult result = MessageBox.Show("Silmek istediğinize emin misiniz?", "Silmek üzeresiniz", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int code = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
                        productOrderOP.productOrderSellDelete(code);
                        MessageBox.Show("Silme işlemi başarıyla gerçekleştirildi", "Silme işlemi");
                        formLoad();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Seçim yapınız", "Seçim yapmadınız");
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click_1(object sender, EventArgs e) // kaydet butonu
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                if (CustomerID != 0)
                {
                    if (newProductOrder)
                    {
                        saveProductOrder();
                        formLoad();
                    }
                    else if(!newProductOrder)
                    {
                        updateProductOrder();
                        formLoad();
                    }
                }
                else
                {
                    MessageBox.Show("Müşteri seçiniz", "Müşteri seçmediniz");
                }
            }
            else
            {
                MessageBox.Show("Ürün seçiniz", "Ürün seçmediniz");
            }
            
        }

        private void updateProductOrder() // update productorder içini doldurucan
        {
                    productOrder productOrder = new productOrder();
                    productListOP productListOP = new productListOP();
                    productList productList = new productList();

                    productOrder.customerID = CustomerID;
                    productOrder.status = 1;
                    productOrder.dateCarried = System.DateTime.Now;
                    productOrder.dateTake = System.DateTime.Now;
                    productOrder.productOrderCode = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
                    productOrderOP.productOrderSellUpdate(productOrder);


                    for (int i = 0; i < dynamicTableNew.Rows.Count; i++)
                    {
                        productList.ProductOrderID = productOrder.productOrderCode;

                        productList.amount = Convert.ToInt32(dynamicTableUpdate.Rows[i][6]);
                        productList.discount = Convert.ToInt32(dynamicTableUpdate.Rows[i][5]);
                        productList.price = Convert.ToInt32(dynamicTableUpdate.Rows[i][3]);
                        productList.productCode = Convert.ToInt32(dynamicTableUpdate.Rows[i][0]);


                        productListOP.productListUpdate(productList);
                    }
                    MessageBox.Show("Siparişiniz başarıyla güncellendi", "Sipariş güncelleme");

        }

        private void saveProductOrder()
        {
                    productOrder productOrder = new productOrder();
                    productOrder.customerID = CustomerID;
                    productOrder.status = 1;
                    productOrder.dateCarried = System.DateTime.Now;
                    productOrder.dateTake = System.DateTime.Now;
                    int productOrderCode;
                    productOrderCode = productOrderOP.productOrderSellAdd(productOrder);
                    productListOP productListOP = new productListOP();
                    productList productList = new productList();

                    for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                    {
                        productList.ProductOrderID = productOrderCode;
                        productList.amount = Convert.ToInt32(dynamicTableNew.Rows[i][6]);
                        productList.discount = Convert.ToInt32(dynamicTableNew.Rows[i][5]);
                        productList.price = Convert.ToInt32(dynamicTableNew.Rows[i][3]);
                        productList.productCode = Convert.ToInt32(dynamicTableNew.Rows[i][0]);

                        productListOP.productListAdd(productList);
                    }
                    MessageBox.Show("Siparişiniz başarıyla alındı", "Sipariş alımı"); 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            groupBox4.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView4.CurrentRow.Selected)
            {
                CustomerID = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
                label3.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView4.CurrentRow.Cells[2].Value.ToString();
                groupBox3.Visible = false;
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                groupBox4.Visible = false;
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız","Seçim yapmadınız");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e) ///////////////////////// burada stuck olduk abi! ıııı ıııı ıııı
        {
            if (newProductOrder)
            {
                if (dataGridView2.Rows.Count > 1)
                {
                    if (dataGridView2.CurrentRow.Selected)
                    {
                        if (control.integerControl(textBox14.Text))
                        {
                            existing = false;

                            for (int i = 0; i < dynamicTableNew.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value) == Convert.ToInt32(dynamicTableNew.Rows[i][0]))
                                {
                                    dynamicTableNew.Rows[i][6] = Convert.ToInt32(dynamicTableNew.Rows[i][6]) + Convert.ToInt32(textBox14.Text);
                                    existing = true;
                                };
                            }
                            if (!existing)
                            {
                                int code = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                                string name = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                                string group = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                                decimal price = Convert.ToDecimal(dataGridView2.CurrentRow.Cells[3].Value);
                                string brand = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                                int discount = Convert.ToInt32(dataGridView2.CurrentRow.Cells[5].Value);
                                int amount = Convert.ToInt32(textBox14.Text);

                                dynamicTableNew.Rows.Add(code, name, group, price, brand, discount, amount);

                            }
                            dataGridView3.DataSource = dynamicTableNew;
                        }
                        else
                        {
                            errorProvider1.SetError(textBox14, "Sayı Giriniz");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("lütfen seçim yapınız", "Seçim yapmadınız");
                }
            }
            else if (!newProductOrder)
            {
                if (dataGridView2.CurrentRow.Selected)
                {
                    existing = false;

                    for (int i = 0; i < dynamicTableUpdate.Rows.Count; i++)
                    {
                            if (Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value)==Convert.ToInt32(dynamicTableUpdate.Rows[i][0]))
                            {
                                dynamicTableUpdate.Rows[i][6] = Convert.ToInt32(dynamicTableUpdate.Rows[i][6]) + Convert.ToInt32(textBox14.Text);
                                existing = true;
                            } 
                    }

                    if (!existing)
                    {
                        int code = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                        string name = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                        string group = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                        decimal price = Convert.ToDecimal(dataGridView2.CurrentRow.Cells[3].Value);
                        string brand = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                        int discount = Convert.ToInt32(dataGridView2.CurrentRow.Cells[5].Value);
                        int amount = Convert.ToInt32(textBox14.Text);

                        dynamicTableUpdate.Rows.Add(code, name, group, price, brand, discount, amount);
                    }

                    dataGridView3.DataSource = dynamicTableUpdate; // not dynamic table /////////////////////////////////////////////////////////////////
                }
                else
                {
                    MessageBox.Show("lütfen seçim yapınız", "Seçim yapmadınız");
                }
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (newProductOrder)
            {
                if (dataGridView3.SelectedRows.Count != 0)
                {
                    if (dataGridView3.CurrentRow.Selected)
                    {
                        for (int i = 0; i < dynamicTableNew.Rows.Count; i++)
                        {
                            if (dynamicTableNew.Rows[i][0].ToString() == dataGridView3.CurrentRow.Cells[0].Value.ToString())
                            {
                                dynamicTableNew.Rows.RemoveAt(i);
                            }
                        }
                    }
                }
            }
            else
            {
                if (dataGridView3.SelectedRows.Count!=0)
                {
                    if (dataGridView3.CurrentRow.Selected)
                    {
                        for (int i = 0; i < dynamicTableUpdate.Rows.Count; i++)
                        {
                            if (dynamicTableUpdate.Rows[i][0].ToString()==dataGridView3.CurrentRow.Cells[0].Value.ToString())
                            {
                                dynamicTableUpdate.Rows.RemoveAt(i);
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           DialogResult result= MessageBox.Show("Teslim işlemi gerçekleştiriyorsunuz","Teslim işlemi",MessageBoxButtons.YesNo);
           if (result == DialogResult.Yes)
           {
               if (dataGridView1.Rows.Count > 1)
               {
                   if (dataGridView1.CurrentRow.Selected)
                   {
                       productOrderOP.productOrderDelivery(Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value));
                       MessageBox.Show("başarıyla kaydedildi", "Sipariş teslimi");
                       formLoad();
                   }
               }
               else
               {
                   MessageBox.Show("Lütfen seçim yapınız", "Seçim yapmadınız");
               }
           }
           else
           {

           }
        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            updateOrSee();
        }
        #region region
        public void makeFillSearchers()
        {
            textBox1.Text = "Kod'a Göre";
            textBox2.Text = "Ad'a Göre";
            textBox3.Text = "Soyad'a Göre";
            textBox4.Text = "Sipariş No'ya Göre";
            textBox5.Text = "Teslim Durum'a Göre";
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

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox5.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productOrderListByVariable(textBox1.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productOrderListByVariable(textBox2.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productOrderListByVariable(textBox3.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productOrderListByVariable(textBox4.Text, 3);
            dataGridView1.DataSource = table;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productOrderListByVariable(textBox5.Text, 6);
            dataGridView1.DataSource = table;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productOrderListByDate(dateTimePicker1.Value,dateTimePicker2.Value, 5);
            dataGridView1.DataSource = table;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = productOrderOP.productOrderListByDate(dateTimePicker1.Value, dateTimePicker2.Value, 5);
            dataGridView1.DataSource = table;
        }
        #endregion
        #region siparisEkleUpdate
        public void makeFillSearchers3()
        {
            textBox6.Text = "Kod'a Göre";
            textBox7.Text = "Ad'a Göre";
            textBox8.Text = "Grup'a Göre";
            textBox9.Text = "Marka'ya Göre";
        }
        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox6.Text = "";
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox7.Text = "";
        }

        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox8.Text = "";
        }

        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox9.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox6.Text, 0);
            dataGridView2.DataSource = table;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox7.Text, 1);
            dataGridView2.DataSource = table;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox8.Text, 2);
            dataGridView2.DataSource = table;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox9.Text, 4);
            dataGridView2.DataSource = table;
        }
        #endregion

        #region siparisinKendisi
        public void makeFillSearchers2()
        {
            textBox10.Text = "Kod'a Göre";
            textBox11.Text = "Ad'a Göre";
            textBox12.Text = "Grup'a Göre";
            textBox13.Text = "Marka'ya Göre";
        }
        private void textBox10_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox10.Text = "";
        }

        private void textBox11_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox11.Text = "";
        }

        private void textBox12_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox12.Text = "";
        }

        private void textBox13_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox13.Text = "";
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region musteriSec
        public void makeFillSearchers4()
        {
            textBox16.Text = "Kod'a Göre";
            textBox17.Text = "Ad'a Göre";
            textBox18.Text = "Soyad'a Göre";
            textBox19.Text = "Banka'ya Göre";
            textBox20.Text = "Semt'e Göre";
            textBox21.Text = "Mahalle'ye Göre";
            textBox22.Text = "Apartman'a Göre";
        }

        private void textBox16_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox16.Text = "";
        }

        private void textBox17_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox17.Text = "";
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

        private void textBox22_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox22.Text = "";
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox16.Text, 0);
            dataGridView4.DataSource = table;
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox17.Text, 1);
            dataGridView4.DataSource = table;
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox18.Text, 2);
            dataGridView4.DataSource = table;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox19.Text, 5);
            dataGridView4.DataSource = table;
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox20.Text, 24);
            dataGridView4.DataSource = table;
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox21.Text, 31);
            dataGridView4.DataSource = table;
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox22.Text, 28);
            dataGridView4.DataSource = table;
        }
#endregion

    }
}