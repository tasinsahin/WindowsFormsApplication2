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
    public partial class FormCompany : DevExpress.XtraEditors.XtraForm
    {
        public FormCompany()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.Company_Closing);
        }
        public bool Cancel { get; set; }
        public bool newChequeInfo; // yeni müşteri mi, update mi? tutuyor
        public bool CompanySelectedFromGrid;
      //  cCompany selectedCompany = new cCompany(); /// gridde seçili müşteriyi buraya atıcan update veya silme  için

        private void Company_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
          
            grb2.Visible = false;
             grb1.Parent = this;
             grb2.Parent = this;
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void open2close1(object sender, EventArgs e)
        {
            grb1.Visible = false;
            grb2.Visible = true;
        }

        private void close2open1(object sender, EventArgs e)
        {
            newChequeInfo = true;
            callgroupbox3();
        }

        private void callgroupbox3()
        {

            if (newChequeInfo)
            {
                grb1.Visible = false;
                MakeEmptyOrFillGroupbox3();
                grb2.Visible = true;
                ////////////////////// burada müşteri listesinden bi sonraki müşteri için id çekicen
                // textBox6.Text=Convert.ToString(MasisData.Customers.newCustomerID());
                textBox6.Enabled = false;

            }
            else if (!newChequeInfo)
            {

                /////////////////////// update için formu grid den seçili olan müşteriyle doldurma fonksiyonu yazıcan

                gridToCompany();
                if (CompanySelectedFromGrid == true)
                {
                    MakeEmptyOrFillGroupbox3();
                    grb1.Visible = true;
                    textBox6.Enabled = false;
                    grb2.Visible = false;
                }
            }


        }
        private void gridToCompany()
        {

            if (true) // selected olmasını kontro edicen , selected değilse , mesaj vericen.
            {
                MessageBox.Show("Lütfen, İşlem Yapacağınız Firmayı Seçiniz!");
                CompanySelectedFromGrid = false;
            }
            // griddeki seçili olanı silme ve update işi için yukarda verilen company ile dolduruyor
        }

        private void MakeEmptyOrFillGroupbox3()/////////////////// yeni müşteri için formun içini boşaltan fonksiyon yazıcan
        {
            if (newChequeInfo)
            {
                CompanyEmpty();
            }
            else if (!newChequeInfo)
            {
               // CompanyFill(selectedCompany); // update ise seçili olan müşteriyle doldur
            }
        }
        private void CompanyEmpty() /// groupboxı yeni müşteri için temizliyor
        {
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
            textBox39.Text = "";
        }


        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            newChequeInfo = true;
            callgroupbox3();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
           
   
        }
       

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            grb1.Visible = true;
            grb2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newChequeInfo = false;
            callgroupbox3();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            grb1.Visible = true;
            grb2.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
