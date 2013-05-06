namespace WindowsFormsApplication2
{
    partial class FormMap
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
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboGoogle = new System.Windows.Forms.ComboBox();
            this.wbrMap = new System.Windows.Forms.WebBrowser();
            this.btnGoogle = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button10
            // 
            this.button10.ForeColor = System.Drawing.Color.Black;
            this.button10.Location = new System.Drawing.Point(1155, 16);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(82, 25);
            this.button10.TabIndex = 8;
            this.button10.Text = "Vazgeç";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboGoogle);
            this.groupBox1.Controls.Add(this.wbrMap);
            this.groupBox1.Controls.Add(this.btnGoogle);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1247, 644);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Harita";
            // 
            // cboGoogle
            // 
            this.cboGoogle.FormattingEnabled = true;
            this.cboGoogle.Items.AddRange(new object[] {
            "Harita",
            "Uydu",
            "Arazi"});
            this.cboGoogle.Location = new System.Drawing.Point(961, 18);
            this.cboGoogle.Name = "cboGoogle";
            this.cboGoogle.Size = new System.Drawing.Size(73, 21);
            this.cboGoogle.TabIndex = 16;
            // 
            // wbrMap
            // 
            this.wbrMap.Location = new System.Drawing.Point(7, 56);
            this.wbrMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrMap.Name = "wbrMap";
            this.wbrMap.Size = new System.Drawing.Size(1230, 568);
            this.wbrMap.TabIndex = 15;
            // 
            // btnGoogle
            // 
            this.btnGoogle.ForeColor = System.Drawing.Color.Black;
            this.btnGoogle.Location = new System.Drawing.Point(1050, 18);
            this.btnGoogle.Name = "btnGoogle";
            this.btnGoogle.Size = new System.Drawing.Size(84, 24);
            this.btnGoogle.TabIndex = 14;
            this.btnGoogle.Text = "Göster";
            this.btnGoogle.UseVisualStyleBackColor = true;
            this.btnGoogle.Click += new System.EventHandler(this.btnGoogle_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(396, 19);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(559, 21);
            this.txtAddress.TabIndex = 12;
            this.txtAddress.Enter += new System.EventHandler(this.txtAddress_Enter);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(66, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 21);
            this.textBox1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Adresi :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Aranan :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(251, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(89, 21);
            this.textBox2.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Kayıt Türü :";
            // 
            // FormMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 670);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMap";
            this.Text = "FormMap";
            this.Load += new System.EventHandler(this.FormMap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGoogle;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser wbrMap;
        private System.Windows.Forms.ComboBox cboGoogle;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
    }
}