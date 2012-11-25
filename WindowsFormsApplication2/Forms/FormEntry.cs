using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class FormEntry : DevExpress.XtraEditors.XtraForm
    {
        public FormEntry()
        {
            InitializeComponent();
        }

        private void FormEntry_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool CorrectPassword = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=193.140.200.25;Database=MasisTakipVT;User ID=cet311;Password=cet311;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select LoginName, Password from userdb";
            cmd.CommandTimeout = 30;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;


            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string dbLoginName = (string)dr["LoginName"];
                string dbPassword = dr.GetString(1);
                if ((dbLoginName == txtName.Text) && dbPassword == txtPassword.Text)
                {
                    CorrectPassword = true;
                    break;
                }
            }

            dr.Close();
            dr.Dispose();
            conn.Close();
            conn.Dispose();

            if (CorrectPassword)
            {
                ((FormFrame)(this.Owner)).LoginName = txtName.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı/Şifre Hatası");
                txtName.Text = "";
                txtPassword.Text = "";
                txtName.Focus();

            }
        }

    /*    private void Control()
        {
            string user=txtName.Text.ToString();
            string pass=txtPassword.Text.ToString();
            foreach (userInfo item in MasisData.userInfos)
	        {
	    	 if (user==item.userName && pass==item.password)
	            {
                  //  this.Hide();
                   //  formFrame.Show(); 
	            }
             else if (user==item.userName && pass!=item.password)
                {
                    label1.Text = "Merhaba" + item.userName + "Hatalı şifre girdiniz";
                }
             else if (user!=item.userName)
                {
                    label1.Text = "Hatalı Kullanıcı Adı";
                }
	        }            
        } */

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.ToString()==textBox5.Text.ToString())
            {
                //addUserInfo();
            }
        }

       /* private void addUserInfo()
        {
            
            userInfo userInfo = new userInfo();
            userInfoOP userInfOP = new userInfoOP();
            bool existing=userInfOP.existingUserNameControl(textBox3.Text.ToString());
            if (existing)
            {
                label2.Text = "Bu Kullanıcı Adı Sistemde Mevcut !";
            }
            else if (!existing)
            {
                userInfo.userName = textBox3.Text.ToString();
                userInfo.password = textBox4.Text.ToString();
                MasisData.userInfos.Add(userInfo);
                groupBox2.Visible = false;
                groupBox1.Visible = true; 
            }
        } */

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }
    }
}