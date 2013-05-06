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
        // Universal modem hizmet sa�lay�c�s�
        private string sUniModem = "Universal Modem Driver";
        bool �sCall;
        personOP personOP = new personOP();
        int timer;
        Timer Timer = new Timer();// call duration � tutmak i�in timer tan�ml�yoruz
        call call = new call(); // yap�lan aramalar� tutmak i�in call tan�ml�yoruz
        message message = new message(); // g�nderilen mesajlar� tutmak i�in message tan�ml�yoruz
        callOP callOp = new callOP();
        messageOP messageOP = new messageOP();
        DataTable calltable = new DataTable();
        DataTable messagetable = new DataTable();
        

        public frmTelephony()
        { 
            InitializeComponent();

            // Form �zerindeki kontrollerin baz�lar�n� se�ilemez konuma getir.
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

            // TAPIClass nesnesini olu�tur.
            TAPI = new TAPIClass("TAPISample");
        }

        public bool Cancel { get; set; }


        // TAPI olaylar�ndan gelen mesajlar� txbCallStatus metin kutusuna yazar.
        public void ShowStatusMsg(string msg)
        {
            if (msg != String.Empty)
            {
                txbCallStatus.Text += msg;
            }
        }//ShowStatusMsg

        // TAPIClass s�n�f�ndaki metodlarla doldurulan hat koleksiyonu<> kontrol
        // edilerek, bulunan hatlar cbxLines bile�enine aktar�l�yor.
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

            Timer.Tick += timer_Tick; // timer tick eventi yarat�yoruz
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox5.Visible = true;
            GrbCall.Visible = false;
            GrbCon.Visible = false;
            GrbMsg.Visible = false;
            GrbTl.Visible = false;
            // TAPIClass s�n�f�ndaki frmMain de�i�keni i�ine,
            // formumuz referans edilerek atan�yor.
            TAPIClass.formMain = this;

            // ListLine koleksiyonu i�indeki elemanlar�n say�s� s�f�rdan b�y�k m�?
            if (TAPI.ListLine.Count > 0)
            {
                // ListLine<> nesnesi i�indeki hatlar aras�nda gezinmek
                // i�in foreach d�ng�s�n� kullan�yoruz.
                foreach (LineClass cl in TAPI.ListLine)
                {
                    // Okunan hat adlar� i�erisinde "sUniModem" string de�i�keni varsa?
                    if (cl.ProviderInfo.IndexOf(sUniModem) >= 0)
                    {
                        // Hat adlar�n� combobox i�ine doldur.
                        cbxLines.Items.Add(cl.LineName);
                    }//if
                }//foreach

                // Combobox bile�enindeki ilk eleman� se�.
                cbxLines.SelectedIndex = 0;
            }//if
        }

        // Form kapat�lmadan �nceki FormClosing olay�.
        private void frmTelephony_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TAPI s�n�f�n� sonland�r.
            TAPI.Dispose();
            e.Cancel = true;
            this.Hide();
        }//FormClosing

        // "Telefon no. �evir" d��mesine bas�l�nca, telefon numaras� �evrilir.
        private void btnDial_Click(object sender, EventArgs e)
        {
            callMake();
        }

        private void callMake()
        {
            txbCallStatus.Clear();          // ��eri�ini temizliyoruz

            // Metin kutusuna telefon numaras� girilmi� mi?
            if (txbPhoneNumber.Text.Length != 0)
            {
                // Arama-�a�r�ya ait handle ge�erli mi?
                if (TAPI.hCall == IntPtr.Zero)
                {
                    btnDial.Enabled = false;        // Kullan�ma kapal�

                    // Telefonla arama yapan OpenLineDevice metodunu �a��r ve
                    // metottan d�nen de�eri kontrol et. 
                    if (TAPI.OpenLineDevice(cbxLines.Text, txbPhoneNumber.Text))
                    {
                        // Telefonla arama ba�ar�l�. btnHangup kullan�ma a��k.
                        btnHangup.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Telefon aramas� yap�lamad�.");
                    }//if
                }
                else
                {
                    MessageBox.Show("Yeni arama yapmadan �nce telefonu kapat�n.");
                }//if hCall
            }
            else
            {
                MessageBox.Show("Telefon numaras�n� giriniz.");
            }//if Text.Len
        }//btnDial_Click

        // "Telefonu kapat" d��mesine bas�l�nca, yap�lan aramay� iptal eder.
        private void btnHangup_Click(object sender, EventArgs e)
        {
            Timer.Stop(); // timer � durdurduk
            saveCall();
            btnHangup.Enabled = false;      // Kullan�ma kapal�

            // DropCall metodunu �a��r ve d�nen de�eri kontrol et.
            if (TAPI.DropCall(TAPI.hCall))
            {
                // Telefonu kapatma ba�ar�l�.
                txbPhoneNumber_TextChanged(sender, e);
            }
            else
            {
                MessageBox.Show("Telefon kapat�lamad�.");
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

        // "�evirme �zellikleri" d��mesine bas�l�nca, bir hatla ilgili
        // telefon ve modem se�enekleri penceresini a�ar.
        private void btnDialProps_Click(object sender, EventArgs e)
        {
            // Se�ili bir hat i�in telefon ve modem se�enekleri penceresini a�ar.
            if (!TAPI.DialingPropertiesDialog(cbxLines.Text))
            {
                MessageBox.Show("Telefon ve modem se�enekleri diyalogu a��l�rken hata olu�tu.");
            }//if

        }//btnDialProps_Click

        // "Hat ayarlar�" d��mesine bas�l�nca, hatt�n ayarlar penceresini a�ar.
        private void btnLineConfigDlg_Click(object sender, EventArgs e)
        {
            // Se�ili bir hat i�in ayarlar penceresini a�ar.
            if (!TAPI.LineDeviceConfigDialog(this.Handle, cbxLines.Text))
            {
                MessageBox.Show("Hat ayarlar� diyalogu a��l�rken hata olu�tu.");
            }//if

        }//btnLineConfigDlg_Click

        // "Konum" d��mesine bas�l�nca, y�r�rl�kte olan kay�tl� �lke ve �ehir kodunu verir.
        private void btnLocationInfo_Click(object sender, EventArgs e)
        {
            // Kay�tl� durumdaki �lke ve �ehir kodunu verir.
            MessageBox.Show("�lke - �ehir kodu: " +
                "+" + TAPI.CountryCode + " (" + TAPI.CityCode + ")");
        }//btnLocationInfo_Click

        // "��k��" d��mesine bas�l�nca, uygulamadan ��k�l�r.
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();     // Uygulamay� sonland�r
        }//btnClose_Click

        private void cbxLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hat ad�n� al�yoruz.
            string sLineName = cbxLines.Text;

            // Hat ad�  bo�sa kontrol et.
            if (sLineName != String.Empty)
            {
                // Bir LineClass nesnesi olu�turuyoruz.
                // Hatt�n �zelliklerine eri�mek i�in GetLineByName metodunu �a��r�yoruz.
                LineClass lnc = TAPI.GetLineByName(sLineName);

                // lnc nesnesinin �zelliklerini kullanarak, hat bilgilerini
                // metin kutusuna yazd�r.
                txbLineInfo.Text = lnc.GetLineInfo();

                // Form �zerindeki baz� buttonlar� kullan�ma a�.
                btnDialProps.Enabled = true;
                btnLineConfigDlg.Enabled = true;
                btnLocationInfo.Enabled = true;
            }//if

        }//cbxLines_SelectedIndexChanged

        private void txbPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            // txbPhoneNumber metin kutusuna giri� yap�l�rsa,
            // "Telefon no. �evir" d��mesini se�ilir konuma getir.
            btnDial.Enabled = (0 < txbPhoneNumber.Text.Length) &&
                (txbPhoneNumber.Text.Trim() != String.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Timer.Start();   // timer� ba�lat�yoruz          
            timer = 0; // timer tickledik�e sayaca��m�z syac� s�f�rl�yoruz
            txbPhoneNumber.Text = Convert.ToString(dataGridView1.CurrentCell.Value)+Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex-1].Value);
            �sCall = true;
            GrbCall.Visible = true;
            GrbCon.Visible = true;
            GrbMsg.Visible = false;
            GrbTl.Visible = false;
            callMake();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer++; // her tick de timer sayac�n� artt�r�yoruz, toplam saniyeyi tutucaz
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    �sCall = false; // buradan birden �ok ki�iye mesaj g�nderme i�i 
                    GrbCall.Visible = false; // oldu�u zaman, listeye atmak i�in kullan�can
                    GrbCon.Visible = false;
                    GrbMsg.Visible = true;
                    GrbTl.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("se�im yap�n�z","Se�im yapmad�n�z");
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
            textBox1.Text = "Kod'a G�re";
            textBox2.Text = "Ad'a G�re";
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