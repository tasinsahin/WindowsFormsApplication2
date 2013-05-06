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

            // Event handlers to open mdi childs from each other
            this.formMain.button1.Click += button1_Click;
            this.formMain.button2.Click += button2_Click;
            this.formMain.button3.Click += button3_Click;
            this.formMain.button4.Click += button4_Click;
            this.formMain.button5.Click += button5_Click;
            this.formSell.button16.Click += button16_Click;
            this.formProduct.btnOk.Click += btnOk_Click;
            this.formCharge.button1.Click+=buttonTakeMoney_Click;
            this.formStok.button2.Click += stockUpdate_Click;
            this.formStok.button3.Click += stockUpdate_Click;
            this.formSell.button16.Click += sellButton_Click;
            this.formBuy.button16.Click += buyButton_Click;
            this.formBank.button3.Click += bankButton_Click;
            this.formBank.button6.Click += bankButton_Click;
            this.formCustomer.btnOk.Click += customerButton_Click;
            this.formCompany.btnDelete.Click += companyButton_Click;
            this.formCompany.btnOk.Click += companyButton_Click;
            this.formCharge.button1.Click += chargePayButton_Click;
            this.formDepth.button1.Click += deptPayButton_Click;
            this.formService.button12.Click += serviceButton_Click;
            this.formEntry.button2.Click += girisButton_Click;
            this.formOrder.button2.Click += orderButton_Click;
            this.formEntry.button3.Click += formEntryCancel_Click;
            this.formCustomer.button1.Click += customerShowMap_Click;
            this.formCompany.button1.Click += companyShowMap_Click;
            this.formStaff.button1.Click += staffShowMap_Click;
            this.formEntry.FormClosing += formEntry_FormClosing;

        }

        void formEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.formEntry.isClosing)
            {
                this.Close();
            }
        }

        private void staffShowMap_Click(object sender, EventArgs e)
        {
            staffID = this.formStaff.haritadaÇalışanGöster;
            this.formMap.haritadaÇalışanGöster=staffID;
            this.formMap.haritadaFirmaGöster = 0;
            this.formMap.haritadaMüşteriGöster = 0;
            mapForm();
        }

        private void companyShowMap_Click(object sender, EventArgs e)
        {
            companyID =this.formCompany.haritadaFirmaGöster ;
            this.formMap.haritadaFirmaGöster=companyID;
            this.formMap.haritadaÇalışanGöster = 0;
            this.formMap.haritadaMüşteriGöster = 0;
            mapForm();
        }

        private void customerShowMap_Click(object sender, EventArgs e)
        {
            custoemrID = this.formCustomer.haritadaMüşteriGöster;
            this.formMap.haritadaMüşteriGöster=custoemrID;
            this.formMap.haritadaFirmaGöster = 0;
            this.formMap.haritadaÇalışanGöster = 0;
            mapForm();
        }

        private void formEntryCancel_Click(object sender, EventArgs e)
        {
            if (this.formEntry.cancel)
            {
                this.Close();
            }
            else
            {

            }
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            this.formMain.formLoad();
            this.formCharge.formLoad();
        }

        private void girisButton_Click(object sender, EventArgs e)
        {
            if (this.formEntry.pass)
            {
                this.formLoad();
            }
            else
            {

            }
        }

        private void serviceButton_Click(object sender, EventArgs e)
        {
            this.formMain.formLoad();
            this.formCharge.formLoad();
        }

        private void chargePayButton_Click(object sender, EventArgs e)
        {
            this.formMain.formLoad();
        }

        private void deptPayButton_Click(object sender, EventArgs e)
        {
            this.formMain.formLoad();
        }

        private void companyButton_Click(object sender, EventArgs e)
        {
            this.formBuy.formLoad();
            this.formMain.formLoad();
            this.frmtelephony.formLoad();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            this.formService.formLoad();
            this.formSell.formLoad();
            this.formOrder.formLoad();
            this.formMain.formLoad();
            this.frmtelephony.formLoad();
        }

        private void bankButton_Click(object sender, EventArgs e)
        {
            this.formCheque.formLoad();
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            this.formDepth.formLoad();
            this.formStok.formLoad();
            this.formMain.formLoad();
            this.formStore.formLoad();
        }

        private void sellButton_Click(object sender, EventArgs e)
        {
            this.formCharge.formLoad();
            this.formStok.formLoad();
            this.formMain.formLoad();
            this.formStore.formLoad();
        }

        private void stockUpdate_Click(object sender, EventArgs e)
        {
            this.formSell.formLoad();
            this.formBuy.formLoad();
            this.formMain.formLoad();
        }

        private void buttonTakeMoney_Click(object sender, EventArgs e)
        {
            this.formMain.FormMain_Load(sender,e);
        }

        void btnOk_Click(object sender, EventArgs e) // ürün eklendi
        {
            this.formMain.FormMain_Load(sender, e);
            this.formStok.FormStok_Load(sender, e);
        }

        void button16_Click(object sender, EventArgs e) // satış yapıldı
        {
            this.formStok.FormStok_Load(sender,e);
        }                        

          // events to call open mdi child forms
        void button1_Click(object sender, EventArgs e)
        {
            ChargeForm();
        }
        void button2_Click(object sender, EventArgs e)
        {
            DepthForm();
        }
        void button3_Click(object sender, EventArgs e)
        {
            ServiceForm();
        }
        void button5_Click(object sender, EventArgs e)
        {
            productForm();
        }
        void button4_Click(object sender, EventArgs e)
        {
            CallForm();
        }

        // closing event before closing mdi child forms
        private void FormFrame_Closing(object sender, CancelEventArgs e)
        {
            barCode.Close();
            formCompany.Close();
            formCustomer.Close();
            formProduct.Close();
            formMain.Close();
            formStaff.Close();
            formService.Close();
            formCheque.Close();
            formOrder.Close();
            formContact.Close();
            frmtelephony.Close();
            formCash.Close();
            formStok.Close();
            formBuy.Close();
            e.Cancel = false;
        }

        public FormMain formMain = new FormMain();
        public FormBuy formBuy = new FormBuy();
        public FormCustomer formCustomer = new FormCustomer();
        public FormCompany formCompany = new FormCompany();
        public FormProduct formProduct = new FormProduct();
        public FormStaff formStaff = new FormStaff();
        public FormService formService = new FormService();
        public FormCheque formCheque = new FormCheque();
        public FormOrder formOrder = new FormOrder();
        public FormContact formContact = new FormContact();
        public frmTelephony frmtelephony = new frmTelephony();
        public FormCash formCash = new FormCash();
        public barCode barCode = new barCode();
        public FormStok formStok = new FormStok();
        public FormCharge formCharge = new FormCharge();
        public FormDepth formDepth = new FormDepth();
        public FormSell formSell = new FormSell();
        public FormBank formBank = new FormBank();
        public FormStore formStore = new FormStore();
        public FormMap formMap = new FormMap();
        public FormEntry formEntry = new FormEntry();

        public int custoemrID=0;
        public int companyID=0;
        public int staffID=0;

        public string LoginName = String.Empty;
                

        public  void Form1_Load(object sender, EventArgs e) 
        {
            formEntry.Show();
            this.Hide();
        }

        public void formLoad()
        {
            this.Show();
            // Create a BarManager that will display a bar of commands at the top of the main form.
            BarManager barManager = new BarManager();
            barManager.Form = this;
            barManager.AllowCustomization = false;

            // Create a bar with a New button.
            barManager.BeginUpdate();
            Bar bar = new Bar(barManager, "My Bar");
            bar.DockStyle = BarDockStyle.Top;

            barManager.MainMenu = bar;

            // Create Event Handlers of Bar Menu Items
            BarItem barItem0 = new BarButtonItem(barManager, "Anasayfa  ");
            barItem0.ItemClick += new ItemClickEventHandler(barItem0_ItemClick);
            bar.ItemLinks.Add(barItem0);
            BarItem barItem = new BarButtonItem(barManager, "Müşteri  ");
            barItem.ItemClick += new ItemClickEventHandler(barItem_ItemClick);
            bar.ItemLinks.Add(barItem);
            BarItem barItem1 = new BarButtonItem(barManager, "Firma  ");
            barItem1.ItemClick += new ItemClickEventHandler(barItem1_ItemClick);
            bar.ItemLinks.Add(barItem1);
            BarItem barItem3 = new BarButtonItem(barManager, "Çalışan  ");
            barItem3.ItemClick += new ItemClickEventHandler(barItem3_ItemClick);
            bar.ItemLinks.Add(barItem3);
            BarItem barItem2 = new BarButtonItem(barManager, "Ürün  ");
            barItem2.ItemClick += new ItemClickEventHandler(barItem2_ItemClick);
            bar.ItemLinks.Add(barItem2);
            BarItem barItem4 = new BarButtonItem(barManager, "Servis ");
            barItem4.ItemClick += new ItemClickEventHandler(barItem4_ItemClick);
            bar.ItemLinks.Add(barItem4);
            BarItem barItem8 = new BarButtonItem(barManager, "Sipariş ");
            barItem8.ItemClick += new ItemClickEventHandler(barItem8_ItemClick);
            bar.ItemLinks.Add(barItem8);
            BarItem barItem6 = new BarButtonItem(barManager, "Alış    ");
            barItem6.ItemClick += new ItemClickEventHandler(barItem6_ItemClick);
            bar.ItemLinks.Add(barItem6);
            BarItem barItem19 = new BarButtonItem(barManager, "Satış     ");
            barItem19.ItemClick += new ItemClickEventHandler(barItem19_ItemClick);
            bar.ItemLinks.Add(barItem19);
            BarItem barItem18 = new BarButtonItem(barManager, "Alacak");
            barItem18.ItemClick += new ItemClickEventHandler(barItem18_ItemClick);
            bar.ItemLinks.Add(barItem18);
            BarItem barItem20 = new BarButtonItem(barManager, "Verecek");
            barItem20.ItemClick += new ItemClickEventHandler(barItem20_ItemClick);
            bar.ItemLinks.Add(barItem20);
            BarItem barItem16 = new BarButtonItem(barManager, "Stok ");
            barItem16.ItemClick += new ItemClickEventHandler(barItem16_ItemClick);
            bar.ItemLinks.Add(barItem16);
            BarItem barItem14 = new BarButtonItem(barManager, "Arama | Mesaj ");
            barItem14.ItemClick += new ItemClickEventHandler(barItem14_ItemClick);
            bar.ItemLinks.Add(barItem14);
            BarItem barItem17 = new BarButtonItem(barManager, " Banka ");
            barItem17.ItemClick += new ItemClickEventHandler(barItem17_ItemClick);
            bar.ItemLinks.Add(barItem17);
            BarItem barItem9 = new BarButtonItem(barManager, "Çek  ");
            barItem9.ItemClick += new ItemClickEventHandler(barItem9_ItemClick);
            bar.ItemLinks.Add(barItem9);
            BarItem barItem13 = new BarButtonItem(barManager, "Barkod ");
            barItem13.ItemClick += new ItemClickEventHandler(barItem13_ItemClick);
            bar.ItemLinks.Add(barItem13);
            BarItem barItem12 = new BarButtonItem(barManager, "Kasa ");
            barItem12.ItemClick += new ItemClickEventHandler(barItem12_ItemClick);
            bar.ItemLinks.Add(barItem12);
            BarItem barItem22 = new BarButtonItem(barManager, "Depo ");
            barItem22.ItemClick += new ItemClickEventHandler(barItem22_ItemClick);
            bar.ItemLinks.Add(barItem22);
            BarItem barItem21 = new BarButtonItem(barManager, "Harita ");
            barItem21.ItemClick += new ItemClickEventHandler(barItem21_ItemClick);
            bar.ItemLinks.Add(barItem21);
            BarItem barItem11 = new BarButtonItem(barManager, "İletişim ");
            barItem11.ItemClick += new ItemClickEventHandler(barItem11_ItemClick);
            bar.ItemLinks.Add(barItem11);

            barManager.EndUpdate();

            // Create an XtraTabbedMdiManager that will manage MDI child windows.
            XtraTabbedMdiManager mdiManager = new XtraTabbedMdiManager();
            mdiManager.MdiParent = this;

            MainForm(); // açılışta mainform gelsin diye
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
        private void barItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            storeForm();
        }

        private void storeForm()
        {
            formStore.Focus();
            formStore.Text = "Depo | ";
            formStore.MdiParent = this;
            formStore.Show();
            formStore.Focus();
        }

        private void barItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            mapForm();
        }

        private void mapForm()
        {
            this.formMap.formLoad();
            formMap.Focus();
            formMap.Text = "Harita | ";
            formMap.MdiParent = this;
            formMap.Show();
            formMap.Focus();
        }
        // Event to Open Mdi child Forms
        void barItem0_ItemClick(object sender, ItemClickEventArgs e)
        {
            MainForm();
        }
        void barItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.formCustomer.formLoad();
            formCustomer.Focus();
            formCustomer.Text = "Müşteri | ";
            formCustomer.MdiParent = this;
            formCustomer.Show();
            formCustomer.Focus();
        }
        void barItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.formCompany.formLoad();
            formCompany.Focus();
            formCompany.Text = "Firma | ";
            formCompany.MdiParent = this;
            formCompany.Show();
            formCompany.Focus();
        }
        void barItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            productForm();
        }      
        void barItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.formStaff.formLoad();
            formStaff.Focus();
            formStaff.Text = "Çalışan | ";
            formStaff.MdiParent = this;
            formStaff.Show();
            formStaff.Focus();
        }       
        void barItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            ServiceForm();
        }
        void barItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            formBuy.Focus();
            formBuy.Text = "Alış ";
            formBuy.MdiParent = this;
            formBuy.Show();
            formBuy.Focus();
        }        
        private void barItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            formSell.Focus();
            formSell.Text = "Satış ";
            formSell.MdiParent = this;
            formSell.Show();
            formSell.Focus();
        }
        void barItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            formOrder.Focus();
            formOrder.Text = "Sipariş | ";
            formOrder.MdiParent = this;
            formOrder.Show();
            formOrder.Focus();
        }
        void barItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            formCheque.Focus();
            formCheque.Text = "Çek | ";
            formCheque.MdiParent = this;
            formCheque.Show();
            formCheque.Focus();
        }
        private void barItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            formContact.Focus();
            formContact.Text = "İletişim | ";
            formContact.MdiParent = this;
            formContact.Show();
            formContact.Focus();          
        }
        private void barItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            cashForm();
        }

        private void cashForm()
        {
            formCash.Focus();
            formCash.Text = "Kasa | ";
            formCash.MdiParent = this;
            formCash.Show();
            formCash.Focus();
        }
        private void barItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            barCode.Focus();
            barCode.Text = "Barkod | ";
            barCode.MdiParent = this;
            barCode.Show();
            barCode.Focus();
        }
        private void barItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            CallForm();
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
             ChargeForm();
         }
         private void barItem20_ItemClick(object sender, ItemClickEventArgs e)
         {
             DepthForm();
         }
         private void ChargeForm()
         {
             formCharge.Focus();
             formCharge.Text = " Alacak";
             formCharge.MdiParent = this;
             formCharge.Show();
             formCharge.Focus();
         }
         private void DepthForm()
         {
             formDepth.Focus();
             formDepth.Text = "Verecek ";
             formDepth.MdiParent = this;
             formDepth.Show();
             formDepth.Focus();
         }

         private void barItem17_ItemClick(object sender, ItemClickEventArgs e)
         {
             formBank.Focus();
             formBank.Text = " Banka  ";
             formBank.MdiParent = this;
             formBank.Show();
             formBank.Focus();
         }

         private void CallForm()
         {
             frmtelephony.Focus();
             frmtelephony.Text = "Arama | Mesaj ";
             frmtelephony.MdiParent = this;
             frmtelephony.Show();
             frmtelephony.Focus();
         }
         private void ServiceForm()
         {
             formService.Focus();
             formService.Text = "Servis | ";
             formService.MdiParent = this;
             formService.Show();
             formService.Focus();
         }
         private void productForm()
         {
             formProduct.Focus();
             formProduct.Text = "Ürün | ";
             formProduct.MdiParent = this;
             formProduct.Show();
             formProduct.Focus();
         }
         private void MainForm()
         {
             formMain.Focus();
             formMain.Text = "Anasayfa | ";
             formMain.MdiParent = this;
             formMain.Show();
             formMain.Focus();
         }
    }
}