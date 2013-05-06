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
        DataTable chequeTable = new DataTable();
        DataTable bankTable = new DataTable();
        cheque cheque = new cheque();
        chequeOP chequeOP = new chequeOP();
        bankOwnOP bankOwnOP = new bankOwnOP();
        customerOP customerOP = new customerOP();
        companyOP companyOP = new companyOP();
        DataTable customerTable = new DataTable();
        DataTable companyTable = new DataTable();

        int customerID;
        int companyID;
        int BankID;
        bool error1;
        bool error2;
        bool error3;
        bool error4;
        private void FormCheque_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormCheque_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        public void formLoad()
        {
            makeFillSearchers();
            MakeFillSearchers2();
            MakeFillSearchers3();
            MakeFillSearchers4();

            chequeTable.Clear();
            bankTable.Clear();
            customerTable.Clear();
            companyTable.Clear();

            customerTable = customerOP.createCustomerTable();
            companyTable = companyOP.CreateCompanyTable();
            chequeTable = chequeOP.createChequeTable();
            bankTable = bankOwnOP.createbankOwnTable();

            dataGridView4.DataSource = customerTable;
            dataGridView3.DataSource = companyTable;
            dataGridView2.DataSource = bankTable;
            dataGridView1.DataSource = chequeTable;

            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox1.Visible = true;

            groupBox1.Parent = this;
            groupBox2.Parent = this;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView3.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView4.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newChequeInfo = true;
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            MakeEmptyForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    if (true)
                    {
                        newChequeInfo = false;
                        groupBox1.Visible = false;
                        groupBox2.Visible = true;
                        cheque.code = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                        cheque.companyCustomer = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value);
                        MakeFillForm();
                    }
                                     
                }
                else
                {
                    MessageBox.Show("Lütfen seçim yapınız", "Seçim yapmadınız");
                }
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız","Seçim yapmadınız");
            }
        }

        private void MakeEmptyForm() // form yeni için temizleniyor
        {
        }

        private void MakeFillForm() // griddeki seçili olan la doldurulack form
        {
            bool alınanVerilen= Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value);
            if (alınanVerilen)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else if (!alınanVerilen)
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            textBox5.Text=dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox7.Text = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value).ToString();
            textBox8.Text= dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker3.Value=Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value);
            dateTimePicker4.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    DialogResult result = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Silmek üzeresiniz", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        chequeOP.chequeDelete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value));
                        MessageBox.Show("Başarıyla sildiniz", "Silme");
                        formLoad();

                    }
                }
                else
                {
                    MessageBox.Show("Seçim yapınız", "Seçim yapmadınız");

                }
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız", "Seçim yapmadınız");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
            groupBox4.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            controll();
            if (error1 || error2 ||error3 || error4 )
            {
                
            }
            else if (!error1 &&!error2 &&!error3 &&!error4  )
            {
                if (newChequeInfo)
                {
                    if (cheque.alınanVerilen)
                    {
                        if (control.integerControl(textBox7.Text))
                        {
                            alınancheque();
                            chequeOP.chequeAdd(cheque);
                            MessageBox.Show("Başarıyla kaydettiniz", "Kayıt işlemi");
                            groupBox2.Visible = false;
                            groupBox1.Visible = true;
                            formLoad();
                        }
                        else
                        {
                            errorProvider1.SetError(textBox7, "Sayı Giriniz");
                        }
                    }
                    else
                    {
                        if (control.integerControl(textBox7.Text))
                        {
                            verilencheque();
                            chequeOP.chequeAdd(cheque);
                            MessageBox.Show("Başarıyla kaydettiniz", "Kayıt işlemi");
                            groupBox2.Visible = false;
                            groupBox1.Visible = true;
                            formLoad();
                        }
                        else
                        {
                            errorProvider1.SetError(textBox7, "Sayı Giriniz");
                        }
                    }
                }
                else if (!newChequeInfo)
                {
                    if (cheque.alınanVerilen)
                    {
                        if (control.integerControl(textBox7.Text))
                        {
                            alınancheque();
                            chequeOP.chequeUpdate(cheque);
                            MessageBox.Show("Başarıyla güncellediniz", "güncelleme işlemi");
                            groupBox2.Visible = false;
                            groupBox1.Visible = true;
                            formLoad();
                        }
                        else
                        {
                            errorProvider1.SetError(textBox7, "Sayı Giriniz");
                        }
                    }
                    else
                    {
                        if (control.integerControl(textBox7.Text))
                        {
                            verilencheque();
                            chequeOP.chequeUpdate(cheque);
                            MessageBox.Show("Başarıyla güncellediniz", "güncelleme işlemi");
                            groupBox2.Visible = false;
                            groupBox1.Visible = true;
                            formLoad();
                        }
                        else
                        {
                            errorProvider1.SetError(textBox7, "Sayı Giriniz");
                        }
                    }
                }
            }
        }

        public void controll()
        {

            if (!(radioButton1.Checked || radioButton2.Checked))
            {
                errorProvider1.SetError(radioButton2, "seçim yapmalısınız");
                error1 = true;
            }
            else
            {
                error1 = false;
            }
            if (textBox5.Text == String.Empty)
            {
                errorProvider1.SetError(textBox5, "boş geçemezsiniz");
                error2 = true;
            }
            else
            {
                error2 = false;
            }
            if (textBox8.Text == String.Empty)
            {
                errorProvider1.SetError(textBox8, "boş geçemezsiniz");
                error3 = true;
            }
            else
            {
                error3 = false;
            }
            if (textBox7.Text == String.Empty)
            {
                errorProvider1.SetError(textBox7, "boş geçemezsiniz");
                error4 = true;
            }
            else
            {
                error4= false;
            }
        }

        private void verilencheque()
        {
            cheque.bankName = textBox5.Text.ToString();
            cheque.money = Convert.ToDecimal(textBox7.Text);
            cheque.companyCustomer = companyID;
            cheque.TakeDate = Convert.ToDateTime(dateTimePicker3.Value);
            cheque.returnDate = Convert.ToDateTime(dateTimePicker4.Value);
            cheque.ownerr = textBox8.Text.ToString();
        }

        private void alınancheque()
        {
            cheque.money = Convert.ToDecimal(textBox7.Text);
            cheque.bankName = textBox5.Text.ToString();
            cheque.companyCustomer = customerID;
            cheque.TakeDate = Convert.ToDateTime(dateTimePicker3.Value);
            cheque.returnDate = Convert.ToDateTime(dateTimePicker4.Value);
            cheque.ownerr = textBox8.Text.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox4.Visible = true;
                groupBox5.Visible = true;
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                groupBox6.Visible = false;
                cheque.alınanVerilen = false;
                textBox5.Enabled = false;
            }
            else
            {
                groupBox4.Visible = false;
                groupBox6.Visible = true;
                groupBox5.Visible = false;
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                cheque.alınanVerilen = true;
                textBox5.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (dataGridView2.Rows.Count > 1)
            {
                if ( dataGridView2.CurrentRow.Selected)
                {
                     textBox5.Text = "";
                     textBox5.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                     cheque.bankName = Convert.ToString(dataGridView2.CurrentRow.Cells[2].Value);
                     groupBox4.Visible = false;
                }
                else
                {
                    MessageBox.Show("Lütfen seçim yapınız", "Seçim yapmadınız");
                }

            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız","Seçim yapmadınız");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox4.Visible = false;
                groupBox6.Visible = true;
                groupBox5.Visible = false;
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                cheque.alınanVerilen = true;
                textBox5.Enabled = true;
            }
            else
            {
                groupBox4.Visible = true;
                groupBox5.Visible = true;
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                groupBox6.Visible = false;
                cheque.alınanVerilen = false;
                textBox5.Enabled = false;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count>1)
            {
                if (dataGridView3.CurrentRow.Selected)
                {
                    textBox8.Text = "";
                    companyID = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                    textBox8.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                    groupBox5.Visible = false;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView4.Rows.Count>1)
            {
                if (dataGridView4.CurrentRow.Selected)
                {
                    textBox8.Text = "";
                    customerID = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
                    textBox8.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView4.CurrentRow.Cells[2].Value.ToString();
                    groupBox6.Visible = false;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = false;
        }

        #region cheque
        public void makeFillSearchers()
        {
            textBox1.Text = "Kod'a Göre";
            textBox2.Text = "Müşteri Kod'a Göre";
            textBox3.Text = "Taraf'a Göre";
            textBox6.Text = "Banka'ya Göre";
            textBox4.Text = "Tutar'a Göre";
            dateTimePicker1.Value = System.DateTime.Now;
            dateTimePicker2.Value = System.DateTime.Now;
            checkBox1.Checked = false;
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

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox6.Text = "";
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox4.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table = chequeOP.chequeListByVariable(textBox1.Text,0);
            dataGridView1.DataSource = table;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = chequeOP.chequeListByVariable(textBox2.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = chequeOP.chequeListByVariable(textBox3.Text,2 );
            dataGridView1.DataSource = table;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DataTable table = chequeOP.chequeListByVariable(textBox6.Text, 3);
            dataGridView1.DataSource = table;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = chequeOP.chequeListByVariable(textBox4.Text, 4);
            dataGridView1.DataSource = table;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = chequeOP.chequeListByDate(dateTimePicker1.Value,dateTimePicker2.Value, 5);
            dataGridView1.DataSource = table;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = chequeOP.chequeListByDate(dateTimePicker1.Value,dateTimePicker2.Value, 5);
            dataGridView1.DataSource = table;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                DataTable table = chequeOP.chequeListByChecked(true,7);
                dataGridView1.DataSource = table;
            }
            else if (!checkBox1.Checked)
            {
                DataTable table = chequeOP.chequeListByChecked(false,7);
                dataGridView1.DataSource = table;
            }
        }
        #endregion
        #region CompanySelect

        public void MakeFillSearchers2()
        {
            textBox9.Text = "Kod'a Göre";
            textBox10.Text = "Ad'a Göre";
            textBox11.Text = "Soyad'a Göre";
            textBox12.Text = "Banka'ya Göre";
            textBox13.Text = "Semt'e Göre";
            textBox14.Text = "Mahalle'ye Göre";
            textBox28.Text = "Apartman'a Göre";
        }
        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers2();
            textBox9.Text = "";
        }

        private void textBox10_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers2();
            textBox10.Text = "";
        }

        private void textBox11_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers2();
            textBox11.Text = "";
        }

        private void textBox12_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers2();
            textBox12.Text = "";
        }

        private void textBox13_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers2();
            textBox13.Text = "";
        }

        private void textBox14_Click(object sender, EventArgs e)
        {
            MakeFillSearchers2();
            textBox14.Text = "";
        }
        private void textBox28_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers2();
            textBox28.Text = "";
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

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox13.Text, 25);
            dataGridView3.DataSource = table;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox14.Text, 29);
            dataGridView3.DataSource = table;
        }
        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            DataTable table = companyOP.companyListByVariable(textBox28.Text, 32);
            dataGridView3.DataSource = table;
        }
#endregion
        #region bankSelect
        public void MakeFillSearchers3()
        {
            textBox20.Text = "Kod'a Göre";
            textBox19.Text = "Hesap Numarası'na Göre";
            textBox18.Text = "Banka Adı'na Göre";
            textBox17.Text = "Ofis Adı'na Göre";
            textBox16.Text = "Ofis Kodu'na Göre";
            textBox15.Text = "Para Türü'ne Göre";
            textBox29.Text = "Tutar'a Göre";
        }
        private void textBox20_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers3();
            textBox20.Text = "";
        }

        private void textBox19_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers3();
            textBox19.Text = "";

        }

        private void textBox18_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers3();
            textBox8.Text = "";

        }

        private void textBox17_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers3();
            textBox7.Text = "";

        }

        private void textBox16_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers3();
            textBox16.Text = "";

        }

        private void textBox15_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers3();
            textBox15.Text = "";

        }
        private void textBox29_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers3();
            textBox29.Text = "";
        }
        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            DataTable table=bankOwnOP.callListByVariable(textBox20.Text,0);
            dataGridView2.DataSource=table;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            DataTable table = bankOwnOP.callListByVariable(textBox19.Text, 1);
            dataGridView2.DataSource = table;
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            DataTable table = bankOwnOP.callListByVariable(textBox18.Text, 2);
            dataGridView2.DataSource = table;
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            DataTable table = bankOwnOP.callListByVariable(textBox17.Text, 3);
            dataGridView2.DataSource = table;
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            DataTable table = bankOwnOP.callListByVariable(textBox16.Text, 4);
            dataGridView2.DataSource = table;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            DataTable table = bankOwnOP.callListByVariable(textBox15.Text, 5);
            dataGridView2.DataSource = table;
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            DataTable table = bankOwnOP.callListByVariable(textBox29.Text, 6);
            dataGridView2.DataSource = table;
        }
        #endregion
        #region CustomerSelect
        public void MakeFillSearchers4()
        {
            textBox21.Text = "Kod'a Göre";
            textBox22.Text = "Ad'a Göre";
            textBox23.Text = "Soyad'a Göre";
            textBox24.Text = "Banka'ya Göre";
            textBox25.Text = "Semt'e Göre";
            textBox26.Text = "Mahalle'ye Göre";
            textBox27.Text = "Apartman'a Göre";
        }
        private void textBox21_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers4();
            textBox21.Text = "";
        }

        private void textBox22_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers4();
            textBox22.Text = "";
        }

        private void textBox23_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers4();
            textBox23.Text = "";
        }

        private void textBox24_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers4();
            textBox24.Text = "";
        }

        private void textBox25_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers4();
            textBox25.Text = "";
        }
        private void textBox26_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers4();
            textBox26.Text = "";
        }
        private void textBox27_MouseClick(object sender, MouseEventArgs e)
        {
            MakeFillSearchers4();
            textBox27.Text = "";
        }
        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox21.Text, 0);
            dataGridView4.DataSource = table;
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox22.Text, 1);
            dataGridView4.DataSource = table;
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox23.Text, 2);
            dataGridView4.DataSource = table;
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox24.Text, 3);
            dataGridView4.DataSource = table;
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox25.Text, 24);
            dataGridView4.DataSource = table;
        }
        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox25.Text, 31);
            dataGridView4.DataSource = table;
        }
        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox27.Text, 28);
            dataGridView4.DataSource = table;
        }
        #endregion
    }
}
