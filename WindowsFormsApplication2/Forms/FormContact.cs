using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApplication2
{
    public partial class FormContact : DevExpress.XtraEditors.XtraForm
    {
        public FormContact()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormContact_Closing);
        }
        public bool Cancel { get; set; }
        private void FormContact_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormContact_Load(object sender, EventArgs e)
        {

        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.tasinsahin.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add("tasinsahin@gmail.com");
                message.Subject = textBox4.Text.ToString();
                message.From = new System.Net.Mail.MailAddress("tasinsahin@gmail.com");
                message.Body = textBox5.Text.ToString() + " " + textBox3.Text.ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("tasinsahin@gmail.com", "1989_youtube");
                client.Port = 587;

                client.Send(message);

                MessageBox.Show("Mesajınız Gönderildi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu : " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
