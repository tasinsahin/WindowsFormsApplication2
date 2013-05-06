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
    public partial class frmTelephony : DevExpress.XtraEditors.XtraForm
    {
        // TAPIClass nesnesi
        private TAPIClass TAPI;
        // Universal modem hizmet saðlayýcýsý
        private string sUniModem = "Universal Modem Driver";
        bool ýsCall;
        personOP personOP = new personOP();
        int timer;
        Timer Timer = new Timer();// call duration ý tutmak için timer tanýmlýyoruz
        call call = new call(); // yapýlan aramalarý tutmak için call tanýmlýyoruz
        message message = new message(); // gönderilen mesajlarý tutmak için message tanýmlýyoruz
        callOP callOp = new callOP();
        messageOP messageOP = new messageOP();
        DataTable calltable = new DataTable();
        DataTable messagetable = new DataTable();
        

        public frmTelephony()
        { 
            InitializeComponent();

            // Form üzerindeki kontrollerin bazýlarýný seçilemez konuma getir.
            btnDialProps.Enabled = false;
            btnLineConfigDlg.Enabled = false;
            btnLocationInfo.Enabled = false;
            btnDial.Enabled = false;
            btnHangup.Enabled = false;
            txbLineInfo.ReadOnly = true;
            txbCallStatus.ReadOnly = true;
            DataTable PersonTable = personOP.createPersonTable();
            dataGridView1.DataSource = PersonTable;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            // TAPIClass nesnesini oluþtur.
            TAPI = new TAPIClass("TAPISample");
        }

        public bool Cancel { get; set; }


        // TAPI olaylarýndan gelen mesajlarý txbCallStatus metin kutusuna yazar.
        public void ShowStatusMsg(string msg)
        {
            if (msg != String.Empty)
            {
                txbCallStatus.Text += msg;
            }
        }//ShowStatusMsg

        // TAPIClass sýnýfýndaki metodlarla doldurulan hat koleksiyonu<> kontrol
        // edilerek, bulunan hatlar cbxLines bileþenine aktarýlýyor.
        private void frmTelephony_Load(object sender, EventArgs e)
        {
            formLoad();

        }//Load

        public void formLoad()
        {
            makeFillSearchers();
            groupBox1.Visible = false;

            dataGridView1.DataSource = personOP.createPersonTable();
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            dataGridView2.DataSource = callOp.createCallTable();
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;

            dataGridView3.DataSource = messageOP.createMessageTable();
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView3.ForeColor = System.Drawing.Color.Black;

            Timer.Tick += timer_Tick; // timer tick eventi yaratýyoruz
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox5.Visible = true;
            GrbCall.Visible = false;
            GrbCon.Visible = false;
            GrbMsg.Visible = false;
            GrbTl.Visible = false;
            // TAPIClass sýnýfýndaki frmMain deðiþkeni içine,
            // formumuz referans edilerek atanýyor.
            TAPIClass.formMain = this;

            // ListLine koleksiyonu içindeki elemanlarýn sayýsý sýfýrdan büyük mü?
            if (TAPI.ListLine.Count > 0)
            {
                // ListLine<> nesnesi içindeki hatlar arasýnda gezinmek
                // için foreach döngüsünü kullanýyoruz.
                foreach (LineClass cl in TAPI.ListLine)
                {
                    // Okunan hat adlarý içerisinde "sUniModem" string deðiþkeni varsa?
                    if (cl.ProviderInfo.IndexOf(sUniModem) >= 0)
                    {
                        // Hat adlarýný combobox içine doldur.
                        cbxLines.Items.Add(cl.LineName);
                    }//if
                }//foreach

                // Combobox bileþenindeki ilk elemaný seç.
                cbxLines.SelectedIndex = 0;
            }//if
        }

        // Form kapatýlmadan önceki FormClosing olayý.
        private void frmTelephony_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TAPI sýnýfýný sonlandýr.
            TAPI.Dispose();
            e.Cancel = true;
            this.Hide();
        }//FormClosing

        // "Telefon no. çevir" düðmesine basýlýnca, telefon numarasý çevrilir.
        private void btnDial_Click(object sender, EventArgs e)
        {
            callMake();
        }

        private void callMake()
        {
            txbCallStatus.Clear();          // Ýçeriðini temizliyoruz

            // Metin kutusuna telefon numarasý girilmiþ mi?
            if (txbPhoneNumber.Text.Length != 0)
            {
                // Arama-çaðrýya ait handle geçerli mi?
                if (TAPI.hCall == IntPtr.Zero)
                {
                    btnDial.Enabled = false;        // Kullanýma kapalý

                    // Telefonla arama yapan OpenLineDevice metodunu çaðýr ve
                    // metottan dönen deðeri kontrol et. 
                    if (TAPI.OpenLineDevice(cbxLines.Text, txbPhoneNumber.Text))
                    {
                        // Telefonla arama baþarýlý. btnHangup kullanýma açýk.
                        btnHangup.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Telefon aramasý yapýlamadý.");
                    }//if
                }
                else
                {
                    MessageBox.Show("Yeni arama yapmadan önce telefonu kapatýn.");
                }//if hCall
            }
            else
            {
                MessageBox.Show("Telefon numarasýný giriniz.");
            }//if Text.Len
        }//btnDial_Click

        // "Telefonu kapat" düðmesine basýlýnca, yapýlan aramayý iptal eder.
        private void btnHangup_Click(object sender, EventArgs e)
        {
            Timer.Stop(); // timer ý durdurduk
            saveCall();
            btnHangup.Enabled = false;      // Kullanýma kapalý

            // DropCall metodunu çaðýr ve dönen deðeri kontrol et.
            if (TAPI.DropCall(TAPI.hCall))
            {
                // Telefonu kapatma baþarýlý.
                txbPhoneNumber_TextChanged(sender, e);
            }
            else
            {
                MessageBox.Show("Telefon kapatýlamadý.");
            }//if
            formLoad();

        }

        private void saveCall()
        {
            call.called = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            call.phoneNumber = Convert.ToInt32(txbPhoneNumber.Text);
            call.duration = timer;
            call.dateTime = System.DateTime.Now;
            call.inout = "in";
            callOp.callAdd(call);
        }

        //btnHangup_Click

        // "Çevirme özellikleri" düðmesine basýlýnca, bir hatla ilgili
        // telefon ve modem seçenekleri penceresini açar.
        private void btnDialProps_Click(object sender, EventArgs e)
        {
            // Seçili bir hat için telefon ve modem seçenekleri penceresini açar.
            if (!TAPI.DialingPropertiesDialog(cbxLines.Text))
            {
                MessageBox.Show("Telefon ve modem seçenekleri diyalogu açýlýrken hata oluþtu.");
            }//if

        }//btnDialProps_Click

        // "Hat ayarlarý" düðmesine basýlýnca, hattýn ayarlar penceresini açar.
        private void btnLineConfigDlg_Click(object sender, EventArgs e)
        {
            // Seçili bir hat için ayarlar penceresini açar.
            if (!TAPI.LineDeviceConfigDialog(this.Handle, cbxLines.Text))
            {
                MessageBox.Show("Hat ayarlarý diyalogu açýlýrken hata oluþtu.");
            }//if

        }//btnLineConfigDlg_Click

        // "Konum" düðmesine basýlýnca, yürürlükte olan kayýtlý ülke ve þehir kodunu verir.
        private void btnLocationInfo_Click(object sender, EventArgs e)
        {
            // Kayýtlý durumdaki ülke ve þehir kodunu verir.
            MessageBox.Show("Ülke - Þehir kodu: " +
                "+" + TAPI.CountryCode + " (" + TAPI.CityCode + ")");
        }//btnLocationInfo_Click

        // "Çýkýþ" düðmesine basýlýnca, uygulamadan çýkýlýr.
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();     // Uygulamayý sonlandýr
        }//btnClose_Click

        private void cbxLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hat adýný alýyoruz.
            string sLineName = cbxLines.Text;

            // Hat adý  boþsa kontrol et.
            if (sLineName != String.Empty)
            {
                // Bir LineClass nesnesi oluþturuyoruz.
                // Hattýn özelliklerine eriþmek için GetLineByName metodunu çaðýrýyoruz.
                LineClass lnc = TAPI.GetLineByName(sLineName);

                // lnc nesnesinin özelliklerini kullanarak, hat bilgilerini
                // metin kutusuna yazdýr.
                txbLineInfo.Text = lnc.GetLineInfo();

                // Form üzerindeki bazý buttonlarý kullanýma aç.
                btnDialProps.Enabled = true;
                btnLineConfigDlg.Enabled = true;
                btnLocationInfo.Enabled = true;
            }//if

        }//cbxLines_SelectedIndexChanged

        private void txbPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            // txbPhoneNumber metin kutusuna giriþ yapýlýrsa,
            // "Telefon no. çevir" düðmesini seçilir konuma getir.
            btnDial.Enabled = (0 < txbPhoneNumber.Text.Length) &&
                (txbPhoneNumber.Text.Trim() != String.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Timer.Start();   // timerý baþlatýyoruz          
            timer = 0; // timer tickledikçe sayacaðýmýz syacý sýfýrlýyoruz
            txbPhoneNumber.Text = Convert.ToString(dataGridView1.CurrentCell.Value)+Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex-1].Value);
            ýsCall = true;
            GrbCall.Visible = true;
            GrbCon.Visible = true;
            GrbMsg.Visible = false;
            GrbTl.Visible = false;
            callMake();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer++; // her tick de timer sayacýný arttýrýyoruz, toplam saniyeyi tutucaz
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    ýsCall = false; // buradan birden çok kiþiye mesaj gönderme iþi 
                    GrbCall.Visible = false; // olduðu zaman, listeye atmak için kullanýcan
                    GrbCon.Visible = false;
                    GrbMsg.Visible = true;
                    GrbTl.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("seçim yapýnýz","Seçim yapmadýnýz");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox5.Visible = false; ;
            GrbCall.Visible = false;
            GrbCon.Visible = false;
            GrbMsg.Visible = false;
            GrbTl.Visible = false; 

        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox5.Visible = true;
            GrbCall.Visible = false;
            GrbCon.Visible = false;
            GrbMsg.Visible = false;
            GrbTl.Visible = false;    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox5.Visible = false;
            GrbCall.Visible = false;
            GrbCon.Visible = false;
            GrbMsg.Visible = false;
            GrbTl.Visible = false;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox5.Visible = true;
            GrbCall.Visible = false;
            GrbCon.Visible = false;
            GrbMsg.Visible = false;
            GrbTl.Visible = false;
        }

        #region region1
        public void makeFillSearchers()
        {
            textBox1.Text = "Kod'a Göre";
            textBox2.Text = "Ad'a Göre";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table = personOP.personListByVariable(textBox1.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = personOP.personListByVariable(textBox2.Text, 1);
            dataGridView1.DataSource = table;
        }
        #endregion


    }//class frmTelephony
}