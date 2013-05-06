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
        int bankInfoCode;
        int billInfoCode;
        int contactCode;

        public bool Cancel { get; set; }
        public  bool newCustomer; // yeni müşteri mi, update mi? tutuyor
        public bool CustomerSelectedFromGrid;
        customerOP customerOP = new customerOP();
        customer customer = new customer();
        DataTable customertable = new DataTable();
        public int haritadaMüşteriGöster=0;
        bool errorInteger=false;
        bool errorEmpty = true;

        bool error1 = false;
        bool error2 = false;
        bool error3 = false;
        bool error4 = false;
        bool error5 = false;
        bool error6 = false;
        bool error7 = false;
        bool error8 = false;
        bool error9 = false;
        bool error10 = false;
        bool error11 = false;
        bool error12 = false;
        bool error13 = false;
        bool error14 = false;
        bool error15 = false;
        bool error16 = false;
        bool error17 = false;
        bool error18 = false;

        private void Customer_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        
        private void Form2_Load(object sender, EventArgs e)
        {
            formLoad();
          
        }

        public  void formLoad()
        {
            makeFillSearchers();
            haritadaMüşteriGöster = 0;
            grb2.Visible = false;
            grb2.Parent = this;
            grb1.Parent = this;
            customertable.Clear();
            customertable = customerOP.createCustomerTable();
            dataGridView1.DataSource = customertable;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            haritadaMüşteriGöster = 0;
        }

        public  void MakeEmptyForm()
        {
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "0";
            textBox13.Text = "0";
            textBox14.Text = "0";
            textBox15.Text = "0";
            textBox16.Text = "0";
            textBox17.Text = "0";
            textBox18.Text = "0";
            textBox19.Text = "0";
            textBox20.Text = "0";
            textBox21.Text = "0";
            textBox22.Text = "0";
            textBox23.Text = "0";
            textBox24.Text = "0";
            textBox25.Text = "0";
            textBox26.Text = "0";
            textBox27.Text = "0";
            textBox28.Text = "0";
            textBox29.Text = "0";
            textBox30.Text = "0";
            textBox31.Text = "0";
            textBox32.Text = "0";
            textBox33.Text = "0";
            textBox34.Text = "0";
            textBox35.Text = "0";
            textBox36.Text = "0";
            textBox37.Text = "0";
            textBox38.Text = "0";
            textBox39.Text = "0"; 
        }
       


        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    newCustomer = false;
                    grb1.Visible = false;
                    grb2.Visible = true;
                    MakeFillForm();
                    textBox6.Enabled = false;
                    grb2.Text = "Müşteri Düzenle";
                }
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız", "Seçim Yapmadınız");
            }

        }

        public  void MakeFillForm() 
        {
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox14.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox15.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox16.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox17.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox18.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBox19.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            textBox20.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            textBox21.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            textBox22.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            textBox23.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            textBox24.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            textBox25.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            textBox26.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            textBox27.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
            textBox28.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();
            textBox29.Text = dataGridView1.CurrentRow.Cells[23].Value.ToString();
            textBox30.Text = dataGridView1.CurrentRow.Cells[24].Value.ToString();
            textBox31.Text = dataGridView1.CurrentRow.Cells[25].Value.ToString();
            textBox32.Text = dataGridView1.CurrentRow.Cells[26].Value.ToString();
            textBox33.Text = dataGridView1.CurrentRow.Cells[27].Value.ToString();
            textBox34.Text = dataGridView1.CurrentRow.Cells[28].Value.ToString();
            textBox35.Text = dataGridView1.CurrentRow.Cells[29].Value.ToString();
            textBox36.Text = dataGridView1.CurrentRow.Cells[30].Value.ToString();
            textBox37.Text = dataGridView1.CurrentRow.Cells[31].Value.ToString();
            textBox38.Text = dataGridView1.CurrentRow.Cells[32].Value.ToString();
            textBox39.Text = dataGridView1.CurrentRow.Cells[33].Value.ToString();

            bankInfoCode=Convert.ToInt32(dataGridView1.CurrentRow.Cells[34].Value);
            contactCode = Convert.ToInt32(dataGridView1.CurrentRow.Cells[35].Value);
            billInfoCode = Convert.ToInt32(dataGridView1.CurrentRow.Cells[36].Value);
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            makeEmptyControl();
            makeIntegerControl();
            if (!error1 && !error2 && !error3 && !error4 && !error5 && !error6 && !error7 && !error8 && !error9 && !error10 && !error11 && !error12 && !error13 && !error14 && !error15 && !error16 && !error17 && !error18)
            {
                if (!errorInteger) // sayıysa hepsi  devam ediyor
                {
                    if (newCustomer)
                    {
                        customer customer1 = tocustomer();
                        customerOP.customerAdd(customer1);
                        MessageBox.Show("Başarılı", "Yeni müşteri kaydı");
                    }
                    else
                    {
                        customer customer1 = tocustomer();
                        customer.code = Convert.ToInt32(textBox6.Text);
                        customerOP.customerUpdate(customer1);
                        MessageBox.Show("başarılı", "Müşteri güncellemesi");
                    }

                    formLoad(); // formu baştan yüklüyor ki değişiklikler görüntülensin
                    grb1.Visible = true;
                    grb2.Visible = false;
                }
                else
                {
                    MessageBox.Show("","errorinteger");
                }
            }
            else
            {
                MessageBox.Show("","errorEmpty");
            }
        }

        private void makeEmptyControl()
        {
            if (textBox10.Text==String.Empty)
            {
                errorProvider1.SetError(textBox10, "Sayı Giriniz");
                error1 = true;
            }
            if (textBox13.Text == String.Empty)
            {
                errorProvider1.SetError(textBox13, "Sayı Giriniz");
                error2 = true;
            }
            if (textBox16.Text == String.Empty)
            {
                errorProvider1.SetError(textBox16, "Sayı Giriniz");
                error3 = true;
            }
            if (textBox18.Text == String.Empty)
            {
                errorProvider1.SetError(textBox18, "Sayı Giriniz");
                error4 = true;
            }
            if (textBox19.Text == String.Empty)
            {
                errorProvider1.SetError(textBox19, "Sayı Giriniz");
                error5 = true;
            }
            if (textBox20.Text == String.Empty)
            {
                errorProvider1.SetError(textBox20, "Sayı Giriniz");
                error6 = true;
            }
            if (textBox21.Text == String.Empty)
            {
                errorProvider1.SetError(textBox21, "Sayı Giriniz");
                error7 = true;
            }
            if (textBox22.Text == String.Empty)
            {
                errorProvider1.SetError(textBox22, "Sayı Giriniz");
                error8 = true;
            }
            if (textBox23.Text == String.Empty)
            {
                errorProvider1.SetError(textBox23, "Sayı Giriniz");
                error9 = true;
            }
            if (textBox24.Text == String.Empty)
            {
                errorProvider1.SetError(textBox24, "Sayı Giriniz");
                error10 = true;
            }
            if (textBox25.Text == String.Empty)
            {
                errorProvider1.SetError(textBox25, "Sayı Giriniz");
                error11 = true;
            }
            if (textBox26.Text == String.Empty)
            {
                errorProvider1.SetError(textBox26, "Sayı Giriniz");
                error12 = true;
            }
            if (textBox27.Text == String.Empty)
            {
                errorProvider1.SetError(textBox27, "Sayı Giriniz");
                error13 = true;
            }
            if (textBox28.Text == String.Empty)
            {
                errorProvider1.SetError(textBox28, "Sayı Giriniz");
                error14 = true;
            }
            if (textBox29.Text == String.Empty)
            {
                errorProvider1.SetError(textBox29, "Sayı Giriniz");
                error15 = true;
            }
            if (textBox33.Text == String.Empty)
            {
                errorProvider1.SetError(textBox33, "Sayı Giriniz");
                error16 = true;
            }
            if (textBox35.Text == String.Empty)
            {
                errorProvider1.SetError(textBox35, "Sayı Giriniz");
                error17 = true;
            }
            if (textBox36.Text == String.Empty)
            {
                errorProvider1.SetError(textBox36, "Sayı Giriniz");
                error18 = true;
            }
        }

        private void makeIntegerControl()
        {
            bool isInteger1 = control.integerControl(textBox10.Text);
            bool isInteger2 = control.integerControl(textBox13.Text);
            bool isInteger3 = control.integerControl(textBox16.Text);
            bool isInteger4 = control.integerControl(textBox18.Text);
            bool isInteger5 = control.integerControl(textBox19.Text);
            bool isInteger6 = control.integerControl(textBox20.Text);
            bool isInteger7 = control.integerControl(textBox21.Text);
            bool isInteger8 = control.integerControl(textBox22.Text);
            bool isInteger9 = control.integerControl(textBox23.Text);
            bool isInteger10 = control.integerControl(textBox24.Text);
            bool isInteger11 = control.integerControl(textBox25.Text);
            bool isInteger12 = control.integerControl(textBox26.Text);
            bool isInteger13 = control.integerControl(textBox27.Text);
            bool isInteger14 = control.integerControl(textBox28.Text);
            bool isInteger15 = control.integerControl(textBox29.Text);
            bool isInteger16 = control.integerControl(textBox33.Text);
            bool isInteger17 = control.integerControl(textBox35.Text);
            bool isInteger18 = control.integerControl(textBox36.Text);

            errorInteger = false;
            
            if (!isInteger1)
            {
                errorProvider1.SetError(textBox10, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger2)
            {
                errorProvider1.SetError(textBox13, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger3)
            {
                errorProvider1.SetError(textBox16, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger4)
            {
                errorProvider1.SetError(textBox18, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger5)
            {
                errorProvider1.SetError(textBox19, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger6)
            {
                errorProvider1.SetError(textBox20, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger7)
            {
                errorProvider1.SetError(textBox21, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger8)
            {
                errorProvider1.SetError(textBox22, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger9)
            {
                errorProvider1.SetError(textBox23, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger10)
            {
                errorProvider1.SetError(textBox24, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger11)
            {
                errorProvider1.SetError(textBox25, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger12)
            {
                errorProvider1.SetError(textBox26, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger13)
            {
                errorProvider1.SetError(textBox27, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger14)
            {
                errorProvider1.SetError(textBox28, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger15)
            {
                errorProvider1.SetError(textBox29, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger16)
            {
                errorProvider1.SetError(textBox33, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger17)
            {
                errorProvider1.SetError(textBox35, "Sayı Giriniz");
                errorInteger = true;
            }
            if (!isInteger18)
            {
                errorProvider1.SetError(textBox36, "Sayı Giriniz");
                errorInteger = true;
            }
        } ///// sayı mı diye kontrol ediyor, değilse errorprovider yapıyor

        private  customer tocustomer() 
        {

            customer.name = textBox7.Text.ToString();
            customer.surname = textBox8.Text.ToString();
            customer.title = textBox9.Text.ToString();
            customer.accountNumber =Convert.ToInt32(textBox10.Text);
            customer.bankName = textBox11.Text.ToString();
            customer.officeName = textBox12.Text.ToString();
            customer.officeCode = Convert.ToInt32(textBox13.Text);
            customer.billTitle = textBox14.Text.ToString(); // biltitle
            customer.taxDepartment = textBox15.Text.ToString(); // depart
            customer.taxNumber =Convert.ToInt32(textBox16.Text); // tax number
            customer.billAdress = textBox17.Text.ToString(); // bill adres
            customer.tel1code = Convert.ToInt32(textBox18.Text);
            customer.tel1 = Convert.ToInt32(textBox19.Text);
            customer.tel2code = Convert.ToInt32(textBox20.Text);
            customer.tel2 = Convert.ToInt32(textBox21.Text);
            customer.tel3code = Convert.ToInt32(textBox22.Text);
            customer.tel3 = Convert.ToInt32(textBox23.Text);
            customer.tel4code = Convert.ToInt32(textBox24.Text);
            customer.tel4 = Convert.ToInt32(textBox25.Text);
            customer.tel5code = Convert.ToInt32(textBox26.Text);
            customer.tel5 = Convert.ToInt32(textBox27.Text);
            customer.tel6code = Convert.ToInt32(textBox28.Text);
            customer.tel6 = Convert.ToInt32(textBox29.Text);
            customer.addhood = textBox30.Text.ToString();
            customer.addstreet = textBox31.Text.ToString();
            customer.addstreeet = textBox32.Text.ToString();
            customer.addno = Convert.ToInt32(textBox33.Text);
            customer.addbuilding = textBox34.Text.ToString();
            customer.addfloor = Convert.ToInt32(textBox35.Text);
            customer.addnoo = Convert.ToInt32(textBox36.Text);
            customer.addtown = textBox37.Text.ToString();
            customer.addcity = textBox38.Text.ToString();
            customer.adddescrip = textBox39.Text.ToString();

            customer.bankInfoCode=bankInfoCode;
            customer.billInfoCode=billInfoCode;
            customer.contactInfoCode=contactCode;

            return customer;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    DialogResult result = MessageBox.Show("Silmek istediğinize emin misiniz?", "Silmek üzeresiniz", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        customerOP.customerDelete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells[34].Value),
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells[35].Value),
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells[36].Value));

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grb1.Visible = false;
            grb2.Visible = true;
            newCustomer = true;
            MakeEmptyForm();
            textBox6.Enabled = false;
            grb2.Text = "Müşteri Kayıt";
        }

        private void btnCancel2_Click_1(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    haritadaMüşteriGöster = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                }
            }
            else
            {
                MessageBox.Show("Müşteri Seçiniz","Müşteri Seçimi");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           DataTable table= customerOP.customerListByVariable(textBox1.Text, 0);
           dataGridView1.DataSource = table;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox2.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox3.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox4.Text, 5);
            dataGridView1.DataSource = table;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox5.Text, 24);
            dataGridView1.DataSource = table;
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox41.Text, 31);
            dataGridView1.DataSource = table;
        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox40.Text, 28);
            dataGridView1.DataSource = table;
        }
        private void makeFillSearchers()
        {
            textBox1.Text = "Kod'a Göre";
            textBox2.Text = "Ad'a Göre";
            textBox3.Text = "Soyad'a Göre";
            textBox4.Text = "Banka'ya Göre";
            textBox5.Text = "Semt'e Göre";
            textBox41.Text = "Mahalle'ye Göre";
            textBox40.Text = "Apartman'a Göre";
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

        private void textBox41_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox41.Text = "";
        }

        private void textBox40_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox40.Text = "";
        }
    }
}
