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
using System.Web;

namespace WindowsFormsApplication2
{
    public partial class FormMap : DevExpress.XtraEditors.XtraForm
    {
        public FormMap()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormMap_Closing);
        }
        public int haritadaMüşteriGöster = 0;
        public int haritadaFirmaGöster = 0;
        public int haritadaÇalışanGöster = 0;
        mapOP mapOP = new mapOP();
        private void FormMap_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormMap_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        public void formLoad()
        {
            cboGoogle.SelectedIndex = 0;
            if (haritadaÇalışanGöster != 0)
            {
                txtAddress.Text = mapOP.createTableStaffAdress(haritadaÇalışanGöster);
                textBox1.Text = mapOP.createTableStaffName(haritadaÇalışanGöster);
                textBox2.Text = "Çalışan";
            }
            else if (haritadaFirmaGöster != 0)
            {
                txtAddress.Text = mapOP.createTableCompanyAdress(haritadaFirmaGöster);
                textBox1.Text = mapOP.createTableCompanyName(haritadaFirmaGöster);
                textBox2.Text = "Firma";
            }
            else if (haritadaMüşteriGöster != 0)
            {
                txtAddress.Text = mapOP.createTableCustomerAdress(haritadaMüşteriGöster);
                textBox1.Text = mapOP.createTableCustomerName(haritadaMüşteriGöster);
                textBox2.Text = "Müşteri";
            }
            haritadaMüşteriGöster = 0;
            haritadaFirmaGöster = 0;
            haritadaÇalışanGöster = 0;

            googleIT();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGoogle_Click(object sender, EventArgs e)
        {
            googleIT();

        }

        public  void googleIT()
        {
            // The basic map URL without the address information.
            const string url_base =
                "http://maps.google.com/maps?f=q&hl=en&geocode=&" +
                "time=&date=&ttype=&q=@ADDR@&ie=UTF8&t=@TYPE@";

            // URL encode the street address.
            string addr = txtAddress.Text;
            addr = HttpUtility.UrlEncode(txtAddress.Text, System.Text.Encoding.UTF8);

            // Insert the encoded address into the base URL.
            string url = url_base.Replace("@ADDR@", addr);

            // Insert the proper type.
            switch (cboGoogle.Text)
            {
                case "Harita":
                    url = url.Replace("@TYPE@", "m");
                    break;
                case "Uydu":
                    url = url.Replace("@TYPE@", "h");
                    break;
                case "Arazi":
                    url = url.Replace("@TYPE@", "p");
                    break;
            }

            // Display the URL in the WebBrowser control.
            wbrMap.Navigate(url);
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {

        }
    }
}
