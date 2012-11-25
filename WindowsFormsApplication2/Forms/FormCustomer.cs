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
    public partial class FormCustomer : DevExpress.XtraEditors.XtraForm
    {
        public FormCustomer()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.Customer_Closing);
        }
        public bool Cancel { get; set; }
        public  bool newCustomer; // yeni müşteri mi, update mi? tutuyor
        public bool CustomerSelectedFromGrid;
       // cCustomer selectedCustomer = new cCustomer(); /// gridde seçili müşteriyi buraya atıcan update veya silme  için

        private void Customer_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb2.Parent = this;
            grb1.Parent = this;
          
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void open2close1(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void close2open1(object sender, EventArgs e)
        {
            newCustomer = true;
            callgroupbox3();
        }

        private void callgroupbox3()
        {

            if (newCustomer)
            {
                grb1.Visible = false;
                MakeEmptyOrFillGroupbox3();
                grb2.Visible = true;
                
            }
            else if (!newCustomer)
            {

                /////////////////////// update için formu grid den seçili olan müşteriyle doldurma fonksiyonu yazıcan
                 
                gridToCustomer();
                if (CustomerSelectedFromGrid==true)
                {
                    MakeEmptyOrFillGroupbox3();
                    grb2.Visible = true;
                    grb1.Visible = false;
                }
            }            
        }

        private void gridToCustomer() 
        {

            if (true) // selected olmasını kontro edicen , selected değilse , mesaj vericen.
            {
                MessageBox.Show("Lütfen, İşlem Yapacağınız Müşteriyi Seçiniz!");
                CustomerSelectedFromGrid = false;
            }
            // griddeki seçili olanı silme ve update işi için yukarda verilen customer ile dolduruyor
        }

        private void MakeEmptyOrFillGroupbox3()/////////////////// yeni müşteri için formun içini boşaltan fonksiyon yazıcan
        {
            if (newCustomer)
            {
                CustomerEmpty();
            }
            else if (!newCustomer)
            {
                //CustomerFill(); // update ise seçili olan müşteriyle doldur
            }
        }

        private void CustomerEmpty() /// groupboxı yeni müşteri için temizliyor
        {
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
            textBox39.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {           
            
        }

       
        private void button7_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            grb1.Visible = false;
            grb2.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            grb1.Visible = true;
            grb2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newCustomer = false;
            callgroupbox3();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            customer customer = new customer();
            customer.name = "ali";
            customerOP customerOp = new customerOP();
            customerOp.customerAdd(customer);
        }
    }
}
