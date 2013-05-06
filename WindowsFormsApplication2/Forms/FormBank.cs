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
    public partial class FormBank : DevExpress.XtraEditors.XtraForm
    {
        public FormBank()
        {
            InitializeComponent();

            this.Closing += new CancelEventHandler(this.Bank_Closing);
        }

        bankOwn bankOwn = new bankOwn();
        bankOwnOP bankOwnOP = new bankOwnOP();
        bool newBank;

        DataTable table = new DataTable();

        private void Bank_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormBank_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        private void formLoad()
        {
            makeFillSearchers();
            table.Clear();
            table = bankOwnOP.createbankOwnTable();
            dataGridView1.DataSource = table;
            groupBox2.Visible = false;
            groupBox1.Visible = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            textBox7.Enabled = false;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("TL");
            comboBox1.Items.Add("$");
            comboBox1.Items.Add("€");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            clearForm();
            newBank = true;
            groupBox2.Text = "Banka Ekle";
        }



        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    if (dataGridView1.CurrentRow.Index != -1)
                    {
                        groupBox1.Visible = false;
                        groupBox2.Visible = true;
                        fillform();
                        newBank = false;
                        bankOwn.bankInfoCode = Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value);
                        groupBox2.Text = "Banka Düzenle";
                    }
                }
            }
        }

        private void clearForm()
        {
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            comboBox1.Text = "";
            textBox14.Text = "";

        }
        private void fillform()
        {
            textBox7.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox8.Text=dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox9.Text=dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox10.Text=dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox11.Text=dataGridView1.CurrentRow.Cells[4].Value.ToString();

            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox14.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Selected)
            {
                if (dataGridView1.Rows.Count>1)
                {
                    DialogResult result= MessageBox.Show("silmek istiyor musunuz?","banka silme işlemi",MessageBoxButtons.YesNo);
                    if (result==DialogResult.Yes)
                    {
                        bankOwnOP.banOwnDelete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value));
                        MessageBox.Show("başarıyla tamamlandı", "Banka silme işlemi");
                        formLoad();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seçim yapınız","Seçim yapmadınız");
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (newBank)
            {
                formtobank();
                bankOwnOP.bankOwnAdd(bankOwn);
                MessageBox.Show("Banka kaydı başarılı","Banka Kaydı");
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                formLoad();
            }
            else
            {
                formtobank();
                bankOwn.code = Convert.ToInt32(textBox7.Text);
                bankOwnOP.bankOwnUpdate(bankOwn);
                MessageBox.Show("banka güncellemesi başarılı", "Banka güncellemesi");
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                formLoad();
            }
        }

        private void formtobank() // formdan bankaya
        {
            bankOwn.accountNumber = Convert.ToInt32(textBox8.Text);
            bankOwn.bankName = textBox9.Text.ToString();
            bankOwn.officeName = textBox10.Text.ToString();
            bankOwn.officeCode = Convert.ToInt32(textBox11.Text);
            bankOwn.money = comboBox1.Text.ToString();
            bankOwn.total = Convert.ToDecimal(textBox14.Text);
            
        }

        public void makeFillSearchers()
        {
            textBox1.Text = "Kod'a Göre";
            textBox2.Text = "Hesap Numarası'na Göre";
            textBox3.Text = "Banka Adı'na Göre";
            textBox4.Text = "Ofis Adı'na Göre";
            textBox5.Text = "Ofis Kodu'na Göre";
            textBox6.Text = "Para Türü'ne Göre";
            textBox12.Text = "Tutar'a Göre";
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

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox6.Text = "";
        }

        private void textBox12_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox12.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table = bankOwnOP.callListByVariable(textBox1.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = bankOwnOP.callListByVariable(textBox2.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = bankOwnOP.callListByVariable(textBox3.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = bankOwnOP.callListByVariable(textBox4.Text, 3);
            dataGridView1.DataSource = table;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable table = bankOwnOP.callListByVariable(textBox5.Text, 4);
            dataGridView1.DataSource = table;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DataTable table = bankOwnOP.callListByVariable(textBox6.Text, 5);
            dataGridView1.DataSource = table;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            DataTable table = bankOwnOP.callListByVariable(textBox7.Text, 6);
            dataGridView1.DataSource = table;
        }
    }
}
