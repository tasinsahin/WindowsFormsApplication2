using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraBars;
using System.Reflection.Emit;

namespace WindowsFormsApplication2
{
    public partial class FormEntry : DevExpress.XtraEditors.XtraForm
    {
        public FormEntry()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormEntry_Closing);
        }

        private void FormEntry_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }
        public bool isClosing = true;

        user user = new user();
        userOP userOP = new userOP();
        DataTable table = new DataTable();
        public bool pass=false;
        public bool cancel = false;
        private void FormEntry_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            this.Size = MinimumSize;
            makeFill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            table.Clear();
            user.userName = txtName.Text.ToString();
            user.passwordd = txtPassword.Text.ToString();
            table=userOP.userControl(user);
            if (table.Rows.Count > 0)
            {
                isClosing = false;
                this.Close();
                pass = true;
            }
            else
            {
                MessageBox.Show("Lütfen tekrar deneyin", "hatalı giriş");
                pass = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            this.Size = MaximumSize;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.ToString()==textBox5.Text.ToString())
            {
                if (textBox6.Text == "1234")
                {
                    user.name = textBox1.Text.ToString();
                    user.surname = textBox2.Text.ToString();
                    user.userName = textBox3.Text.ToString();
                    user.passwordd = textBox4.Text.ToString();
                    userOP.UserAdd(user);
                    label2.Text = "Kullanıcı kaydı başarılı";
                    groupBox2.Visible = false;
                    groupBox1.Visible = true;
                    txtName.Text = user.userName;
                    this.Size = MinimumSize;
                }
                else
                {
                    label2.Text = "Onaylama kodunu yanlış girdiniz";
                }
            }
            else
            {
                label2.Text = "Şifre uyuşmazlığı";
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            cancel = true;
            isClosing = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
            this.Size = MinimumSize;
        }
        public void makeFill()
        {
            txtName.Text = "Kullanıcı Adı";
            txtPassword.Text = "Şifre";
            textBox1.Text = "Adı";
            textBox2.Text = "Soyadı";
            textBox3.Text = "Kullanıcı Adı";
            textBox4.Text = "Şifre";
            textBox5.Text = "Şifre";
            textBox6.Text = "Onaylama Kodu";
        }
        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            txtName.Text = "";
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            txtPassword.Text = "";
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }


        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            textBox5.Text = "";
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            textBox6.Text = "";
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            makeFill();
        }
    }
}