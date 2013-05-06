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
    public partial class FormStaff : DevExpress.XtraEditors.XtraForm
    {
        public FormStaff()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormStaff_Closing);
        }
        public bool Cancel { get; set; }
        public bool newStaff; // yeni müşteri mi, update mi? tutuyor
        public bool StaffSelectedFromGrid;
        staffOP staffOP = new staffOP();
        staff staff = new staff();
        int bankInfoCode;
        int billInfoCode;
        int contactInfoCode;
        DataTable staffTable = new DataTable();
        public int haritadaÇalışanGöster = 0;

        char[] girilendeger;
        bool error;

        private void FormStaff_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        public void formLoad()
        {
            makeFillSearchers();
            grb2.Visible = false;
            grb1.Visible = true;
            staffTable.Clear();
            staffTable = staffOP.createStaffTable(); // staff tablosu oluşturturyoruz staffOP classına
            dataGridView1.DataSource = staffTable;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            haritadaÇalışanGöster = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newStaff = true;
            grb1.Visible = false;
            grb2.Visible = true;
            StaffEmpty();
            textBox6.Enabled = false;
        }              
        
        private void StaffEmpty() /// groupboxı yeni müşteri için temizliyor
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
            textBox42.Text = "0";
        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = false;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            grb1.Visible = false;
            grb2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    newStaff = false;
                    grb2.Visible = true;
                    grb1.Visible = false;
                    MakeFillForm();
                    textBox6.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız", "Seçim yapmadınız");
            }
        }

        public  void MakeFillForm() // burası da doğru olmadı tam olarak, eşleşiyor mu kontrol etmek gerekiyor, ki doğru değildir
        {
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Value =Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value);
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value);
            textBox11.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox14.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox15.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox16.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBox17.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            textBox18.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            textBox19.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            textBox20.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            textBox21.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            textBox22.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            textBox23.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            textBox24.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            textBox25.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
            textBox26.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();
            textBox27.Text = dataGridView1.CurrentRow.Cells[23].Value.ToString();
            textBox28.Text = dataGridView1.CurrentRow.Cells[24].Value.ToString();
            textBox29.Text = dataGridView1.CurrentRow.Cells[25].Value.ToString();
            textBox30.Text = dataGridView1.CurrentRow.Cells[26].Value.ToString();
            textBox31.Text = dataGridView1.CurrentRow.Cells[27].Value.ToString();
            textBox32.Text = dataGridView1.CurrentRow.Cells[28].Value.ToString();
            textBox33.Text = dataGridView1.CurrentRow.Cells[29].Value.ToString();
            textBox34.Text = dataGridView1.CurrentRow.Cells[30].Value.ToString();
            textBox35.Text = dataGridView1.CurrentRow.Cells[31].Value.ToString();
            textBox36.Text = dataGridView1.CurrentRow.Cells[32].Value.ToString();
            textBox37.Text = dataGridView1.CurrentRow.Cells[33].Value.ToString();
            textBox38.Text = dataGridView1.CurrentRow.Cells[34].Value.ToString();
            textBox39.Text = dataGridView1.CurrentRow.Cells[35].Value.ToString();
            textBox42.Text = dataGridView1.CurrentRow.Cells[36].Value.ToString();

            bankInfoCode = Convert.ToInt32(dataGridView1.CurrentRow.Cells[37].Value);
            billInfoCode =Convert.ToInt32(dataGridView1.CurrentRow.Cells[38].Value);
            contactInfoCode = Convert.ToInt32(dataGridView1.CurrentRow.Cells[39].Value); 
        }      

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    DialogResult result = MessageBox.Show("Silmek istediğinize emin misiniz?", "silmek üzeresiniz", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        staffOP.staffDelete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells[37].Value),
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells[38].Value),
                            Convert.ToInt32(dataGridView1.CurrentRow.Cells[39].Value));
                        MessageBox.Show("Başarıyla gerçekleşti", "Silme işlemi");
                        formLoad();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız", "Seçim yapmadınız");
            }
        }

        private void btnOk_Click(object sender, EventArgs e) 
        {
            errorProviderControlAlert();
            if (error)
            {
                
            }
            else if (!error)
            {
                if (newStaff)
                {
                    formToStaff();
                    staffOP.staffAdd(staff);
                    MessageBox.Show("başarıyla tamamlandı", "Çalışan kaydetm");
                }
                else
                {
                    staff.code = Convert.ToInt32(textBox6.Text);
                    formToStaff();
                    staffOP.staffUpdate(staff);
                    MessageBox.Show("başarıyla tamamlandı", "çalışan güncelleme");
                }

                formLoad(); // formu baştan yüklüyor ki değişiklikler görüntülensin
            }
        }

        private void formToStaff()
        {
            staff.name = textBox7.Text.ToString();
            staff.surname = textBox8.Text.ToString();
            staff.title = textBox9.Text.ToString();
            staff.salary = Convert.ToDecimal(textBox10.Text);
            staff.startDate = dateTimePicker1.Value;
            staff.leaveDate = dateTimePicker2.Value;
            staff.billTitle = textBox11.Text.ToString();
            staff.taxDepartment = textBox12.Text.ToString();
            staff.taxNumber = Convert.ToInt32(textBox13.Text);
            staff.billAdress = textBox14.Text.ToString();
            staff.accountNumber = Convert.ToInt32(textBox15.Text);
            staff.bankName = textBox16.Text.ToString();
            staff.officeName = textBox17.Text.ToString();
            staff.officeCode = Convert.ToInt32(textBox18.Text);
            staff.tel1code = Convert.ToInt32(textBox19.Text);
            staff.tel1 = Convert.ToInt32(textBox20.Text);
            staff.tel2code = Convert.ToInt32(textBox21.Text);
            staff.tel2 = Convert.ToInt32(textBox22.Text);
            staff.tel3code = Convert.ToInt32(textBox23.Text);
            staff.tel3 = Convert.ToInt32(textBox24.Text);
            staff.tel4code = Convert.ToInt32(textBox25.Text);
            staff.tel4 = Convert.ToInt32(textBox26.Text);
            staff.tel5code = Convert.ToInt32(textBox27.Text);
            staff.tel5 = Convert.ToInt32(textBox28.Text);
            staff.tel6code = Convert.ToInt32(textBox29.Text);
            staff.tel6 = Convert.ToInt32(textBox30.Text);
            staff.addhood = textBox31.Text.ToString();
            staff.addstreet = textBox32.Text.ToString();
            staff.addstreeet = textBox33.Text.ToString();
            staff.addno = Convert.ToInt32(textBox34.Text);
            staff.addbuilding = textBox35.Text.ToString();
            staff.addfloor = Convert.ToInt32(textBox36.Text);
            staff.addnoo = Convert.ToInt32(textBox37.Text);
            staff.addtown = textBox38.Text.ToString();
            staff.addcity = textBox39.Text.ToString();
            staff.adddescrip = textBox42.Text.ToString();

            staff.contactInfoCode = contactInfoCode;
            staff.billInfoCode = billInfoCode;
            staff.bankInfoCode = bankInfoCode;
        }

        private void btnCancel1_Click(object sender, EventArgs e)
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
            string texbox = textBox10.Text.ToString();

            if (textBox10.Text != "")
            {
                string s = textBox10.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox10, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox10.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox10, "Değer giriniz");
            }
                       
            if (textBox13.Text != "")
            {
                string s = textBox13.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox13, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox13.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox13, "Değer giriniz");
            }
                      
            if (textBox15.Text != "")
            {
                string s = textBox15.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox15, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox15.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox15, "Değer giriniz");
            }
                       
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
            }
                       
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
            else if (textBox36.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox36, "Değer giriniz");
            }
                      
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
            }

                       
            if (textBox18.Text != "")
            {
                string s = textBox18.Text.ToString();
                girilendeger = s.ToCharArray(0, s.Length);
                bool sayımı = SayıMı(girilendeger);
                if (!sayımı)
                {
                    errorProvider1.SetError(textBox18, "Lütfen sayı giriniz");
                    error = true;

                }
                else
                {
                    error = false;
                }
            }
            else if (textBox18.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox18, "Değer giriniz");
            }
                       
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
            else if (textBox10.Text.ToString() == String.Empty)
            {
                errorProvider1.SetError(textBox19, "Değer giriniz");
            }
                       
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
            }
                       
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
            }
                       
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
            }
                      
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
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    haritadaÇalışanGöster = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                }                
            }
            else
            {
                MessageBox.Show("Seçim Yapınız","Çalışan Seçimi");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox1.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox2.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox3.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox4.Text, 12);
            dataGridView1.DataSource = table;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox5.Text, 27);
            dataGridView1.DataSource = table;
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox41.Text, 34);
            dataGridView1.DataSource = table;
        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox40.Text, 31);
            dataGridView1.DataSource = table;
        }
    }
}
