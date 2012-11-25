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
        private void FormOrder_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            //DataTable table = toDatatable.toDb<cProductOrder>(MasisData.ProductOrders);
            // dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            newProductOrder = true;
            callgroupbox3();
        }

        private void callgroupbox3()
        {   
        if (newProductOrder)
            {
                groupBox1.Visible = false;
                groupBox3.Visible = false;
                MakeEmptyOrFillGroupbox3();
                groupBox1.Visible = true;
                ////////////////////// burada müşteri listesinden bi sonraki müşteri için id çekicen
                // textBox6.Text=Convert.ToString(MasisData.Customers.newCustomerID());
              //  textBox6.Enabled = false;
                
            }
        else if (!newProductOrder)
        {

            /////////////////////// update için formu grid den seçili olan müşteriyle doldurma fonksiyonu yazıcan

            gridToProductOrder();
            if (ProductOrderSelectedFromGrid == true)
            {
                MakeEmptyOrFillGroupbox3();
                groupBox2.Visible = true;
                textBox6.Enabled = false;
                groupBox1.Visible = false;
                groupBox3.Visible = false;
            }
        }
                      
        }
        
        private void gridToProductOrder() 
        {

            if (true) // selected olmasını kontro edicen , selected değilse , mesaj vericen.
            {
                MessageBox.Show("Lütfen, İşlem Yapacağınız Müşteriyi Seçiniz!");
                ProductOrderSelectedFromGrid = false;
            }
            // griddeki seçili olanı silme ve update işi için yukarda verilen customer ile dolduruyor
        }
        private void MakeEmptyOrFillGroupbox3()/////////////////// yeni müşteri için formun içini boşaltan fonksiyon yazıcan
        {
            if (newProductOrder)
            {
                ProductOrderEmpty();
            }
            else if (!newProductOrder)
            {
            }
        }
        private void ProductOrderEmpty() /// groupboxı yeni müşteri için temizliyor
        {/*
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox38.Text = "";
            textBox39.Text = ""; */
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
        }
       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            newProductOrder = false;
            callgroupbox3();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }}

