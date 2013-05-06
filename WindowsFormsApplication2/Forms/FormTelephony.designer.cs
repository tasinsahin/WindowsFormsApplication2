namespace WindowsFormsApplication2
{
    partial class frmTelephony
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GrbCon = new System.Windows.Forms.GroupBox();
            this.txbLineInfo = new System.Windows.Forms.TextBox();
            this.btnLocationInfo = new System.Windows.Forms.Button();
            this.btnLineConfigDlg = new System.Windows.Forms.Button();
            this.btnDialProps = new System.Windows.Forms.Button();
            this.cbxLines = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GrbCall = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbPhoneNumber = new System.Windows.Forms.TextBox();
            this.btnHangup = new System.Windows.Forms.Button();
            this.txbCallStatus = new System.Windows.Forms.TextBox();
            this.btnDial = new System.Windows.Forms.Button();
            this.GrbTl = new System.Windows.Forms.GroupBox();
            this.GrbMsg = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.GrbCon.SuspendLayout();
            this.GrbCall.SuspendLayout();
            this.GrbMsg.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // GrbCon
            // 
            this.GrbCon.Controls.Add(this.txbLineInfo);
            this.GrbCon.Controls.Add(this.btnLocationInfo);
            this.GrbCon.Controls.Add(this.btnLineConfigDlg);
            this.GrbCon.Controls.Add(this.btnDialProps);
            this.GrbCon.Controls.Add(this.cbxLines);
            this.GrbCon.Controls.Add(this.label1);
            this.GrbCon.Location = new System.Drawing.Point(32, 435);
            this.GrbCon.Name = "GrbCon";
            this.GrbCon.Size = new System.Drawing.Size(501, 243);
            this.GrbCon.TabIndex = 0;
            this.GrbCon.TabStop = false;
            this.GrbCon.Text = "Hatlar";
            // 
            // txbLineInfo
            // 
            this.txbLineInfo.BackColor = System.Drawing.Color.DarkGray;
            this.txbLineInfo.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txbLineInfo.Location = new System.Drawing.Point(8, 49);
            this.txbLineInfo.Multiline = true;
            this.txbLineInfo.Name = "txbLineInfo";
            this.txbLineInfo.Size = new System.Drawing.Size(480, 156);
            this.txbLineInfo.TabIndex = 1;
            // 
            // btnLocationInfo
            // 
            this.btnLocationInfo.ForeColor = System.Drawing.Color.Black;
            this.btnLocationInfo.Location = new System.Drawing.Point(390, 212);
            this.btnLocationInfo.Name = "btnLocationInfo";
            this.btnLocationInfo.Size = new System.Drawing.Size(98, 25);
            this.btnLocationInfo.TabIndex = 4;
            this.btnLocationInfo.Text = "Konum";
            this.btnLocationInfo.UseVisualStyleBackColor = true;
            this.btnLocationInfo.Click += new System.EventHandler(this.btnLocationInfo_Click);
            // 
            // btnLineConfigDlg
            // 
            this.btnLineConfigDlg.ForeColor = System.Drawing.Color.Black;
            this.btnLineConfigDlg.Location = new System.Drawing.Point(286, 212);
            this.btnLineConfigDlg.Name = "btnLineConfigDlg";
            this.btnLineConfigDlg.Size = new System.Drawing.Size(98, 25);
            this.btnLineConfigDlg.TabIndex = 3;
            this.btnLineConfigDlg.Text = "Hat ayarlarý";
            this.btnLineConfigDlg.UseVisualStyleBackColor = true;
            this.btnLineConfigDlg.Click += new System.EventHandler(this.btnLineConfigDlg_Click);
            // 
            // btnDialProps
            // 
            this.btnDialProps.ForeColor = System.Drawing.Color.Black;
            this.btnDialProps.Location = new System.Drawing.Point(182, 212);
            this.btnDialProps.Name = "btnDialProps";
            this.btnDialProps.Size = new System.Drawing.Size(98, 25);
            this.btnDialProps.TabIndex = 2;
            this.btnDialProps.Text = "Çevirme özellikleri";
            this.btnDialProps.UseVisualStyleBackColor = true;
            this.btnDialProps.Click += new System.EventHandler(this.btnDialProps_Click);
            // 
            // cbxLines
            // 
            this.cbxLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLines.FormattingEnabled = true;
            this.cbxLines.Location = new System.Drawing.Point(79, 22);
            this.cbxLines.Name = "cbxLines";
            this.cbxLines.Size = new System.Drawing.Size(385, 21);
            this.cbxLines.TabIndex = 0;
            this.cbxLines.SelectedIndexChanged += new System.EventHandler(this.cbxLines_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Hat seçiniz:";
            // 
            // GrbCall
            // 
            this.GrbCall.Controls.Add(this.label2);
            this.GrbCall.Controls.Add(this.txbPhoneNumber);
            this.GrbCall.Controls.Add(this.btnHangup);
            this.GrbCall.Controls.Add(this.txbCallStatus);
            this.GrbCall.Controls.Add(this.btnDial);
            this.GrbCall.Location = new System.Drawing.Point(576, 432);
            this.GrbCall.Name = "GrbCall";
            this.GrbCall.Size = new System.Drawing.Size(696, 243);
            this.GrbCall.TabIndex = 1;
            this.GrbCall.TabStop = false;
            this.GrbCall.Text = "Telefon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(556, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Aranýlan Numara";
            // 
            // txbPhoneNumber
            // 
            this.txbPhoneNumber.Enabled = false;
            this.txbPhoneNumber.Location = new System.Drawing.Point(559, 49);
            this.txbPhoneNumber.Name = "txbPhoneNumber";
            this.txbPhoneNumber.Size = new System.Drawing.Size(98, 21);
            this.txbPhoneNumber.TabIndex = 0;
            this.txbPhoneNumber.TextChanged += new System.EventHandler(this.txbPhoneNumber_TextChanged);
            // 
            // btnHangup
            // 
            this.btnHangup.ForeColor = System.Drawing.Color.Black;
            this.btnHangup.Location = new System.Drawing.Point(559, 163);
            this.btnHangup.Name = "btnHangup";
            this.btnHangup.Size = new System.Drawing.Size(98, 57);
            this.btnHangup.TabIndex = 2;
            this.btnHangup.Text = "Telefonu kapat";
            this.btnHangup.UseVisualStyleBackColor = true;
            this.btnHangup.Click += new System.EventHandler(this.btnHangup_Click);
            // 
            // txbCallStatus
            // 
            this.txbCallStatus.BackColor = System.Drawing.Color.DarkGray;
            this.txbCallStatus.ForeColor = System.Drawing.Color.Black;
            this.txbCallStatus.Location = new System.Drawing.Point(12, 25);
            this.txbCallStatus.Multiline = true;
            this.txbCallStatus.Name = "txbCallStatus";
            this.txbCallStatus.Size = new System.Drawing.Size(518, 197);
            this.txbCallStatus.TabIndex = 3;
            // 
            // btnDial
            // 
            this.btnDial.ForeColor = System.Drawing.Color.Black;
            this.btnDial.Location = new System.Drawing.Point(558, 87);
            this.btnDial.Name = "btnDial";
            this.btnDial.Size = new System.Drawing.Size(98, 57);
            this.btnDial.TabIndex = 1;
            this.btnDial.Text = "Tekrar Çevir";
            this.btnDial.UseVisualStyleBackColor = true;
            this.btnDial.Click += new System.EventHandler(this.btnDial_Click);
            // 
            // GrbTl
            // 
            this.GrbTl.Location = new System.Drawing.Point(32, 435);
            this.GrbTl.Name = "GrbTl";
            this.GrbTl.Size = new System.Drawing.Size(516, 280);
            this.GrbTl.TabIndex = 16;
            this.GrbTl.TabStop = false;
            this.GrbTl.Text = "Telefon Ayarlarý";
            // 
            // GrbMsg
            // 
            this.GrbMsg.Controls.Add(this.label5);
            this.GrbMsg.Controls.Add(this.label4);
            this.GrbMsg.Controls.Add(this.textBox10);
            this.GrbMsg.Controls.Add(this.textBox9);
            this.GrbMsg.Controls.Add(this.button6);
            this.GrbMsg.Controls.Add(this.button5);
            this.GrbMsg.Controls.Add(this.label3);
            this.GrbMsg.Controls.Add(this.listBox1);
            this.GrbMsg.Location = new System.Drawing.Point(555, 435);
            this.GrbMsg.Name = "GrbMsg";
            this.GrbMsg.Size = new System.Drawing.Size(717, 280);
            this.GrbMsg.TabIndex = 0;
            this.GrbMsg.TabStop = false;
            this.GrbMsg.Text = "Mesaj Gönder";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ýçerik :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Baþlýk :";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(379, 27);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(317, 21);
            this.textBox10.TabIndex = 5;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(379, 78);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(317, 153);
            this.textBox9.TabIndex = 4;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(65, 246);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(112, 27);
            this.button6.TabIndex = 3;
            this.button6.Text = "Çýkar";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(458, 244);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 27);
            this.button5.TabIndex = 2;
            this.button5.Text = "Gönder";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mesaj gönderilecek Kiþi Listesi";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(18, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(215, 199);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.button8);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.dataGridView1);
            this.groupBox5.Location = new System.Drawing.Point(12, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1239, 414);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Kiþi Listesi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Aranan :";
            // 
            // button8
            // 
            this.button8.ForeColor = System.Drawing.Color.Black;
            this.button8.Location = new System.Drawing.Point(1136, 342);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(82, 66);
            this.button8.TabIndex = 29;
            this.button8.Text = "Vazgeç";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(1136, 260);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 66);
            this.button4.TabIndex = 28;
            this.button4.Text = "Mesaj Dökümü";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(1136, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 66);
            this.button3.TabIndex = 27;
            this.button3.Text = "Arama Dökümü";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(1136, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 66);
            this.button2.TabIndex = 26;
            this.button2.Text = "Mesaj Gönder  / Ekle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(1136, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 66);
            this.button1.TabIndex = 25;
            this.button1.Text = "Arama Yap    / Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(244, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 18;
            this.textBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox2_MouseClick);
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 17;
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridView1.Location = new System.Drawing.Point(18, 41);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(1071, 343);
            this.dataGridView1.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Location = new System.Drawing.Point(61, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(999, 398);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button7
            // 
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(861, 138);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(86, 69);
            this.button7.TabIndex = 29;
            this.button7.Text = "Geri Dön";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView2.Location = new System.Drawing.Point(53, 73);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(732, 241);
            this.dataGridView2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.dataGridView3);
            this.groupBox2.Location = new System.Drawing.Point(180, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(926, 398);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // button9
            // 
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Location = new System.Drawing.Point(809, 121);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(86, 69);
            this.button9.TabIndex = 29;
            this.button9.Text = "Geri Dön";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // dataGridView3
            // 
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black;
            this.dataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView3.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView3.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView3.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView3.Location = new System.Drawing.Point(53, 73);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(664, 241);
            this.dataGridView3.TabIndex = 0;
            // 
            // frmTelephony
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 774);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GrbMsg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GrbCall);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.GrbTl);
            this.Controls.Add(this.GrbCon);
            this.MaximizeBox = false;
            this.Name = "frmTelephony";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TAPI - Telefonu kullanma";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTelephony_FormClosing);
            this.Load += new System.EventHandler(this.frmTelephony_Load);
            this.GrbCon.ResumeLayout(false);
            this.GrbCon.PerformLayout();
            this.GrbCall.ResumeLayout(false);
            this.GrbCall.PerformLayout();
            this.GrbMsg.ResumeLayout(false);
            this.GrbMsg.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrbCon;
        private System.Windows.Forms.TextBox txbLineInfo;
        private System.Windows.Forms.Button btnLocationInfo;
        private System.Windows.Forms.Button btnLineConfigDlg;
        private System.Windows.Forms.Button btnDialProps;
        private System.Windows.Forms.ComboBox cbxLines;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GrbCall;
        private System.Windows.Forms.TextBox txbPhoneNumber;
        private System.Windows.Forms.Button btnHangup;
        private System.Windows.Forms.TextBox txbCallStatus;
        private System.Windows.Forms.Button btnDial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GrbTl;
        private System.Windows.Forms.GroupBox GrbMsg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label6;
    }
}

