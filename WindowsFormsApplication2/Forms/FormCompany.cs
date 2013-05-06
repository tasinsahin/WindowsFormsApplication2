using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlClient;
using System.Data.Sql;


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
        public bool neW; // yeni firma mı, update mi? tutuyor

        companyOP companyOP = new companyOP();
        DataTable companytable = new DataTable();
        int bankInfoCode;
        int billInfoCode;
        int contactInfoCode;
        char[] girilendeger;
        bool error;
        public int haritadaFirmaGöster = 0;
        private void Company_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            formLoad(); 
        }

        public void formLoad()
        {
            makeFillSearchers();
            grb2.Visible = false;
            grb1.Parent = this;
            grb2.Parent = this;
            companytable.Clear();
            companytable  = companyOP.CreateCompanyTable();         // company datatable hazırlıyor 
            dataGridView1.DataSource = companytable;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            haritadaFirmaGöster = 0;
        }

        public void CompanyEmpty() /// groupboxı yeni müşteri için temizliyor
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


        private void button9_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
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
            neW = false;
        }

        private void BtnCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            grb1.Visible = true;
            grb2.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           grb1.Hide();
           grb2.Show();
           CompanyEmpty();
           neW = true;
           textBox6.Enabled = false;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            errorProviderControlAlert();
            if (error)
            {

            }
            else if(!error)
            {
                if (neW)
                {
                    company company = formToObject();
                    companyOP.companyAdd(company);
                    MessageBox.Show("kaydınız başarıyla alındı");
                }
                else
                {
                    company company = formToObject();
                    company.code = Convert.ToInt32(textBox6.Text);
                    companyOP.companyUpdate(company);

                }

                grb2.Hide();
                grb1.Show();

                formLoad(); // formu baştan yüklüyor ki, değişiklikler görüntülensin
            }
        }

        private company formToObject()
        {
            company company = new company();

            company.name = textBox7.Text.ToString();
            company.statemen = textBox8.Text.ToString();
            company.responsible = textBox9.Text.ToString();
            company.title = textBox10.Text.ToString();
            company.accountNumber = Convert.ToInt32(textBox11.Text);
            company.bankName  = textBox12.Text.ToString();
            company.officeName  = textBox13.Text.ToString();
            company.officeCode =Convert.ToInt32(textBox14.Text);
            company.billTitle = textBox15.Text.ToString();
            company.taxDepartment = textBox16.Text.ToString();
            company.taxNumber = Convert.ToInt32(textBox17.Text);
            company.billAdress = textBox18.Text.ToString();

            company.tel1code = Convert.ToInt32(textBox19.Text);
            company.tel1 = Convert.ToInt32(textBox20.Text);
            company.tel2code = Convert.ToInt32(textBox21.Text);
            company.tel2 = Convert.ToInt32(textBox22.Text);
            company.tel3code = Convert.ToInt32(textBox23.Text);
            company.tel3 = Convert.ToInt32(textBox24.Text);
            company.tel4code = Convert.ToInt32(textBox25.Text);
            company.tel4 = Convert.ToInt32(textBox26.Text);
            company.tel5code = Convert.ToInt32(textBox27.Text);
            company.tel5 = Convert.ToInt32(textBox28.Text);
            company.tel6code = Convert.ToInt32(textBox29.Text);
            company.tel6 = Convert.ToInt32(textBox30.Text);

            company.addhood=textBox31.Text.ToString();
            company.addstreet=textBox32.Text. ToString();
            company.addstreeet=textBox33.Text.ToString();
            company.addno=Convert.ToInt32(textBox34.Text);
            company.addbuilding= textBox35.Text.ToString();
            company.addfloor=Convert.ToInt32(textBox36.Text);
            company.addnoo=Convert.ToInt32(textBox37.Text);
            company.addtown=textBox38.Text.ToString();
            company.addcity=textBox39.Text.ToString();
            company.adddescrip = textBox42.Text.ToString();

            company.billInfoCode = billInfoCode;
            company.bankInfoCode = bankInfoCode;
            company.contactInfoCode = contactInfoCode;

            return company;
        }

        public void objectToForm()
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

            textBox19.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            textBox20.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            textBox21.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            textBox22.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            textBox23.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            textBox24.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            textBox25.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            textBox26.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            textBox27.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();
            textBox28.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
            textBox29.Text = dataGridView1.CurrentRow.Cells[24].Value.ToString();
            textBox30.Text = dataGridView1.CurrentRow.Cells[23].Value.ToString();

            textBox31.Text = dataGridView1.CurrentRow.Cells[25].Value.ToString();
            textBox32.Text = dataGridView1.CurrentRow.Cells[26].Value.ToString();
            textBox33.Text = dataGridView1.CurrentRow.Cells[27].Value.ToString();
            textBox34.Text = dataGridView1.CurrentRow.Cells[28].Value.ToString();
            textBox35.Text = dataGridView1.CurrentRow.Cells[29].Value.ToString();
            textBox36.Text = dataGridView1.CurrentRow.Cells[30].Value.ToString();
            textBox37.Text = dataGridView1.CurrentRow.Cells[31].Value.ToString();
            textBox38.Text = dataGridView1.CurrentRow.Cells[32].Value.ToString();
            textBox39.Text = dataGridView1.CurrentRow.Cells[33].Value.ToString();
            textBox42.Text = dataGridView1.CurrentRow.Cells[34].Value.ToString();

            billInfoCode =Convert.ToInt32(dataGridView1.CurrentRow.Cells[35].Value);
            contactInfoCode = Convert.ToInt32(dataGridView1.CurrentRow.Cells[36].Value);
            bankInfoCode = Convert.ToInt32(dataGridView1.CurrentRow.Cells[37].Value);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    neW = false;
                    objectToForm();
                    grb1.Visible = false;
                    grb2.Visible = true;
                    textBox6.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Lütfen firma seçiniz", "Seçim Yapmadınız");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    DialogResult result = MessageBox.Show("Silmek istediğinize emin misiniz?", "Silmek üzeresiniz", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        companyOP.companyDelete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells[35].Value),
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells[36].Value),
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells[37].Value));
                        MessageBox.Show("Silme işlemi başarıyla tamamlandı", "Silme işlemi");
                        formLoad();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Seçim yapnız", "Seçim yapmadınız");
            }
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            grb1.Visible = true;
            grb2.Visible = false;
        }

        private void BtnCancel1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        public bool SayıMı(char[] girdi)
        {
            for (int i = 0; i < girdi.Length; i++)
            {
                if (girdi[i] > 57 || girdi[i] < 48)
                {
                    return false;
                }
            }
            return true;
        }


        public void errorProviderControlAlert()
        {

            kontrol_17();

            kontrol_16();

            kontrol_15();

            kontrol_14();

            kontrol_13();

            kontrol_12();

            kontrol_11();

            kontrol_10();

            kontrol_9();

            kontrol_8();

            kontrol_7();

            kontrol_6();

            kontrol_5();

            kontrol_4();

            kontrol_3();

            kontrol_2();

            kontrol_1();

        }

        private void kontrol_17()
        {
            string texbox = textBox10.Text.ToString();

            if (textBox14.Text != "")
            {
                string s = textBox14.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox14, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox14.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox14, "Değer giriniz");
            }
        }

        private void kontrol_16()
        {
            if (textBox17.Text != "")
            {
                string s = textBox17.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox17, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox17.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox17, "Değer giriniz");
            }
        }

        private void kontrol_15()
        {
            if (textBox19.Text != "")
            {
                string s = textBox19.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox19, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox19.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox19, "Değer giriniz");
            }
        }

        private void kontrol_14()
        {
            if (textBox20.Text != "")
            {
                string s = textBox20.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox20, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }

            else if (textBox20.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox20, "Değer giriniz");
            }
        }

        private void kontrol_13()
        {
            if (textBox21.Text != "")
            {
                string s = textBox21.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox21, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox21.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox21, "Değer giriniz");
            }
        }

        private void kontrol_12()
        {
            if (textBox22.Text != "")
            {
                string s = textBox22.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox22, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox22.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox22, "Değer giriniz");
            }
        }

        private void kontrol_11()
        {
            if (textBox23.Text != "")
            {
                string s = textBox23.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox23, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox23.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox23, "Değer giriniz");
            }
        }

        private void kontrol_10()
        {
            if (textBox24.Text != "")
            {
                string s = textBox24.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox24, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox24.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox24, "Değer giriniz");
            }
        }

        private void kontrol_9()
        {
            if (textBox25.Text != "")
            {
                string s = textBox25.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox25, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox25.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox25, "Değer giriniz");
            }
        }

        private void kontrol_8()
        {
            if (textBox26.Text != "")
            {
                string s = textBox26.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox26, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox26.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox26, "Değer giriniz");
            }
        }

        private void kontrol_7()
        {
            if (textBox27.Text != "")
            {
                string s = textBox27.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox27, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox27.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox27, "Değer giriniz");
                error = true;
            }
        }

        private void kontrol_6()
        {
            if (textBox28.Text != "")
            {
                string s = textBox28.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox28, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox28.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox28, "Değer giriniz");
                error = true;
            }
        }

        private void kontrol_5()
        {
            if (textBox29.Text != "")
            {
                string s = textBox29.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox29, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox29.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox29, "Değer giriniz");
                error = true;
            }
        }

        private void kontrol_4()
        {
            if (textBox30.Text != "")
            {
                string s = textBox30.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox30, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox30.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox30, "Değer giriniz");
                error = true;
            }
        }

        private void kontrol_3()
        {
            if (textBox34.Text != "")
            {
                string s = textBox34.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox34, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox34.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox34, "Değer giriniz");
                error = true;
            }
        }

        private void kontrol_2()
        {
            if (textBox36.Text != "")
            {
                string s = textBox36.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox36, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }

            if (textBox36.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox36, "Değer giriniz");
                error = true;
            }
        }

        private void kontrol_1()
        {
            if (textBox37.Text != "")
            {
                string s = textBox37.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox37, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox37.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox37, "Değer giriniz");
                error = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    haritadaFirmaGöster = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                }
            }
            else
            {
                MessageBox.Show("Seçim yapınız","Firma Seçimi");
            }
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

        private void textBox40_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox40.Text = "";
        }

        private void textBox41_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox41.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox1.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox2.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox3.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox4.Text, 6);
            dataGridView1.DataSource = table;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox5.Text, 25);
            dataGridView1.DataSource = table;
        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox40.Text, 29);
            dataGridView1.DataSource = table;
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox41.Text, 32);
            dataGridView1.DataSource = table;
        }
    }
}
