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
    public partial class FormCheque : DevExpress.XtraEditors.XtraForm
    {
        public FormCheque()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormCheque_Closing);
        }
        public bool Cancel { get; set; }
        public bool newChequeInfo; // yeni müşteri mi, update mi? tutuyor
        public bool ChequeInfoSelectedFromGrid;
        //cChequeInfo selectedChequeInfo = new cChequeInfo(); /// gridde seçili müşteriyi buraya atıcan update veya silme  için

        private void FormCheque_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormCheque_Load(object sender, EventArgs e)
        {
            //DataTable table = toDatatable.toDb<cChequeInfo>(MasisData.chequeInfos);
            //dataGridView1.DataSource = table;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {            
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newChequeInfo = true;
            callgroupbox3();
        }
        private void callgroupbox3()
        {

            if (newChequeInfo)
            {
                groupBox3.Visible = false;
                groupBox1.Visible = false;
                MakeEmptyOrFillGroupbox3();
                groupBox2.Visible = true;
                ////////////////////// burada müşteri listesinden bi sonraki müşteri için id çekicen
                // textBox6.Text=Convert.ToString(MasisData.Customers.newCustomerID());
                textBox6.Enabled = false;

            }
            else if (!newChequeInfo)
            {

                /////////////////////// update için formu grid den seçili olan müşteriyle doldurma fonksiyonu yazıcan

                gridToChequeInfo();
                if (ChequeInfoSelectedFromGrid == true)
                {
                    MakeEmptyOrFillGroupbox3();
                    groupBox1.Visible = true;
                    textBox6.Enabled = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                }
            }
        }
        private void gridToChequeInfo()
        {

            if (true) // selected olmasını kontro edicen , selected değilse , mesaj vericen.
            {
                MessageBox.Show("Lütfen, İşlem Yapacağınız Firmayı Seçiniz!");
                ChequeInfoSelectedFromGrid = false;
            }
            // griddeki seçili olanı silme ve update işi için yukarda verilen company ile dolduruyor
        }
        private void MakeEmptyOrFillGroupbox3()/////////////////// yeni müşteri için formun içini boşaltan fonksiyon yazıcan
        {
            if (newChequeInfo)
            {
                ChequeInfoEmpty();
            }
            else if (!newChequeInfo)
            {
            }
        }
        private void ChequeInfoEmpty() /// groupboxı yeni müşteri için temizliyor
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void ChequeInfoFill()
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
   
        }
    }
}
