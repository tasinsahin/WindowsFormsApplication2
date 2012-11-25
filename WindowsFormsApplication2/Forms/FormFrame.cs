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
    public partial class FormFrame : DevExpress.XtraEditors.XtraForm

    {
        public FormFrame() 
        {
            InitializeComponent();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            this.WindowState = FormWindowState.Maximized;
            this.Closing += new CancelEventHandler(this.FormFrame_Closing);
            
        }
        public string LoginName = String.Empty;

        private void FormFrame_Closing(object sender, CancelEventArgs e)
        {
            this.Close();
            barCode.Close();
            formCompany.Close();
            formCustomer.Close();
            formBill.Close();
            formProduct.Close();
            formMain.Close();
            formStaff.Close();
            formService.Close();
            formSell.Close();
            formBill.Close();
            formCheque.Close();
            formOrder.Close();
            formSettings.Close();
            formContact.Close();
            frmtelephony.Close();
            formCash.Close();
            formStok.Close();
            formBuy.Close();
            
        }
        public  FormBuy formBuy = new FormBuy();
        public FormCustomer formCustomer = new FormCustomer();
        public FormCompany formCompany = new FormCompany();
        public FormProduct formProduct = new FormProduct();
        public FormMain formMain = new FormMain();
        public FormStaff formStaff = new FormStaff();
        public FormService formService = new FormService();
        public FormSell formSell = new FormSell();
        public FormBill formBill = new FormBill();
        public FormCheque formCheque = new FormCheque();
        public FormOrder formOrder = new FormOrder();
        public FormSettings formSettings = new FormSettings();
        public FormContact formContact = new FormContact();
        public frmTelephony frmtelephony = new frmTelephony();
        public FormCash formCash = new FormCash();
        public barCode barCode = new barCode();
        public FormStok formStok = new FormStok();
        public FormCharge formAlacak = new FormCharge();
        public FormDept formVerecek = new FormDept();

        

        

        public  void Form1_Load(object sender, EventArgs e) 
        {
            

            //FormLogin();
            // Create a BarManager that will display a bar of commands at the top of the main form.
            BarManager barManager = new BarManager();
            barManager.Form = this;
            barManager.AllowCustomization = false;
           
            // Create a bar with a New button.
            barManager.BeginUpdate();
            Bar bar = new Bar(barManager, "My Bar");
            bar.DockStyle = BarDockStyle.Top;
           
            barManager.MainMenu = bar;

            BarItem barItem0 = new BarButtonItem(barManager, "Anasayfa  ");
            barItem0.ItemClick += new ItemClickEventHandler(barItem0_ItemClick);
            bar.ItemLinks.Add(barItem0);
            BarItem barItem = new BarButtonItem(barManager, "Müşteri  ");
            barItem.ItemClick += new ItemClickEventHandler(barItem_ItemClick);
            bar.ItemLinks.Add(barItem);
            BarItem barItem1 = new BarButtonItem(barManager, "Firma  ");
            barItem1.ItemClick += new ItemClickEventHandler(barItem1_ItemClick);
            bar.ItemLinks.Add(barItem1);
            BarItem barItem2 = new BarButtonItem(barManager, "Ürün  ");
            barItem2.ItemClick += new ItemClickEventHandler(barItem2_ItemClick);
            bar.ItemLinks.Add(barItem2);
            BarItem barItem3 = new BarButtonItem(barManager, "Çalışan  ");
            barItem3.ItemClick += new ItemClickEventHandler(barItem3_ItemClick);
            bar.ItemLinks.Add(barItem3);
            BarItem barItem4 = new BarButtonItem(barManager, "Servis ");
            barItem4.ItemClick += new ItemClickEventHandler(barItem4_ItemClick);
            bar.ItemLinks.Add(barItem4);
            BarItem barItem8 = new BarButtonItem(barManager, "Sipariş ");
            barItem8.ItemClick += new ItemClickEventHandler(barItem8_ItemClick);
            bar.ItemLinks.Add(barItem8);
            BarItem barItem7 = new BarButtonItem(barManager, "Fatura | İrsaliye   ");
            barItem7.ItemClick += new ItemClickEventHandler(barItem7_ItemClick);
            bar.ItemLinks.Add(barItem7);
            BarItem barItem9 = new BarButtonItem(barManager, "Çek  ");
            barItem9.ItemClick += new ItemClickEventHandler(barItem9_ItemClick);
            bar.ItemLinks.Add(barItem9);
            BarItem barItem6 = new BarButtonItem(barManager, "Alış |Satış  ");
            barItem6.ItemClick += new ItemClickEventHandler(barItem6_ItemClick);
            bar.ItemLinks.Add(barItem6);
            BarItem barItem17 = new BarButtonItem(barManager, " Banka ");
            barItem17.ItemClick += new ItemClickEventHandler(barItem17_ItemClick);
            bar.ItemLinks.Add(barItem17);
            BarItem barItem18 = new BarButtonItem(barManager, "Alacak | Verecek");
            barItem18.ItemClick += new ItemClickEventHandler(barItem18_ItemClick);
            bar.ItemLinks.Add(barItem18);            
            BarItem barItem14 = new BarButtonItem(barManager, "Arama | Mesaj ");
            barItem14.ItemClick += new ItemClickEventHandler(barItem14_ItemClick);
            bar.ItemLinks.Add(barItem14);
            BarItem barItem16 = new BarButtonItem(barManager, "Stok ");
            barItem16.ItemClick += new ItemClickEventHandler(barItem16_ItemClick);
            bar.ItemLinks.Add(barItem16);
            BarItem barItem12 = new BarButtonItem(barManager, "Kasa ");
            barItem12.ItemClick += new ItemClickEventHandler(barItem12_ItemClick);
            bar.ItemLinks.Add(barItem12);
            BarItem barItem13 = new BarButtonItem(barManager, "Barkod ");
            barItem13.ItemClick += new ItemClickEventHandler(barItem13_ItemClick);
            bar.ItemLinks.Add(barItem13);
            BarItem barItem5 = new BarButtonItem(barManager, "Messenger ");
            barItem5.ItemClick += new ItemClickEventHandler(barItem5_ItemClick);
            bar.ItemLinks.Add(barItem5);
            BarItem barItem10 = new BarButtonItem(barManager, "Ayarlar ");
            barItem10.ItemClick += new ItemClickEventHandler(barItem10_ItemClick);
            bar.ItemLinks.Add(barItem10);
            BarItem barItem11 = new BarButtonItem(barManager, "İletişim ");
            barItem11.ItemClick += new ItemClickEventHandler(barItem11_ItemClick);
            bar.ItemLinks.Add(barItem11);
            


            barManager.EndUpdate();
            // Create an XtraTabbedMdiManager that will manage MDI child windows.
            XtraTabbedMdiManager mdiManager = new XtraTabbedMdiManager();
            mdiManager.MdiParent = this;          
        }

        private void FormLogin()
        {
            FormEntry Entry = new FormEntry();
            Entry.Owner = this;
            DialogResult sonuc = Entry.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                MessageBox.Show("Giriş Yaptınız, Kullanıcı Adınız :" + LoginName);
            }
            else
            {
                Application.Exit();
            }
        }






        void barItem0_ItemClick(object sender, ItemClickEventArgs e)
        {
            formMain.Focus();
            formMain.Text = "Anasayfa | ";
            formMain.MdiParent = this;
            formMain.Show();
            formMain.Focus();
        }
        void barItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            formCustomer.Focus();
            formCustomer.Text = "Müşteri | ";
            formCustomer.MdiParent = this;
            formCustomer.Show();
            formCustomer.Focus();
        }
        void barItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            formCompany.Text = "Firma | ";
            formCompany.MdiParent = this;
            formCompany.Show();
            formCompany.Focus();
        }
        void barItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            formProduct.Text = "Ürün | ";
            formProduct.MdiParent = this;
            formProduct.Show();
            formProduct.Focus();
        }       
        void barItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            formStaff.Text = "Çalışan | ";
            formStaff.MdiParent = this;
            formStaff.Show();
            formStaff.Focus();
        }       
        void barItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            formService.Text = "Servis | ";
            formService.MdiParent = this;
            formService.Show();
            formService.Focus();
        }
        void barItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
             // Create an MDI child form.
            formSell.Text = "Messenger | ";
            formSell.MdiParent = this;
            formSell.Show();
            formSell.Focus();
        }
        void barItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            formBuy.Text = "Alış | Satış";
            formBuy.MdiParent = this;
            formBuy.Show();
            formBuy.Focus();
        }
        void barItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            formBill.Text = "Fatura | İrsaliye  ";
            formBill.MdiParent = this;
            formBill.Show();
            formBill.Focus();
        }
        void barItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            formOrder.Text = "Sipariş | ";
            formOrder.MdiParent = this;
            formOrder.Show();
            formOrder.Focus();
        }
        void barItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            formCheque.Text = "Çek | ";
            formCheque.MdiParent = this;
            formCheque.Show();
            formCheque.Focus();
        }
        void barItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            formSettings.Text = "Ayarlar | ";
            formSettings.MdiParent = this;
            formSettings.Show();
            formSettings.Focus();
        }
        private void barItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            formContact.Text = "İletişim | ";
            formContact.MdiParent = this;
            formContact.Show();
            formContact.Focus();          
        }
        private void barItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            formCash.Text = "Kasa | ";
            formCash.MdiParent = this;
            formCash.Show();
            formCash.Focus();
        }
        private void barItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            barCode.Text = "Barkod | ";
            barCode.MdiParent = this;
            barCode.Show();
            barCode.Focus();
        }
        private void barItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            frmtelephony.Text = "Arama | Mesaj ";
            frmtelephony.MdiParent = this;
            frmtelephony.Show();
            frmtelephony.Focus(); 
        } 
         private void barItem16_ItemClick(object sender, ItemClickEventArgs e)
         {
             formStok.Focus();
             formStok.Text = "Stok | ";
             formStok.MdiParent = this;
             formStok.Show();
             formStok.Focus();
         }
         public  void barItem18_ItemClick(object sender, ItemClickEventArgs e)
         {
             formAlacak.Focus();
             formAlacak.Text = "Verecek | Alacak";
             formAlacak.MdiParent = this;
             formAlacak.Show();
             formAlacak.Focus();
         }

         private void barItem17_ItemClick(object sender, ItemClickEventArgs e)
         {
             formVerecek.Focus();
             formVerecek.Text = " | ";
             formVerecek.MdiParent = this;
             formVerecek.Show();
             formVerecek.Focus();
         }
    }
}