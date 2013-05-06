using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication2
{
    public partial class barCode : DevExpress.XtraEditors.XtraForm
    {
        PrintDocument doc = new PrintDocument();
        Ean13Barcode2005.Ean13 barcode = new Ean13Barcode2005.Ean13();
        productOP productOP = new productOP();

        public barCode()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.barCode_Closing);
        }
        public bool Cancel { get; set; }
        private void barCode_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        


        private void barCode_Load(object sender, EventArgs e)
        {
            makeFillSearchers();
            dataGridView1.DataSource = productOP.createProductTable();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            gridToBarcode();
        }


        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(dataGridView1.CurrentRow.Cells[1].Value.ToString(), new System.Drawing.Font(new FontFamily("Arial"), 10, FontStyle.Bold), Brushes.Black, new PointF(425, 135));
            e.Graphics.DrawString(dataGridView1.CurrentRow.Cells[4].Value.ToString(), new System.Drawing.Font(new FontFamily("Arial"), 10, FontStyle.Bold), Brushes.Black, new PointF(425, 150));
            e.Graphics.DrawString(dataGridView1.CurrentRow.Cells[3].Value.ToString()+" TL", new System.Drawing.Font(new FontFamily("Arial"), 10, FontStyle.Bold), Brushes.Black, new PointF(425, 165));

            //Burası önemli aşağıdaki kod barkodu yazan kod
            barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32(yatayText.Text), Convert.ToInt32(dikeyText.Text))));

        }


        private void button4_Click(object sender, EventArgs e)
        {
            // for (int i = 0; i < 10; i++)
            {
                barcode.ProductCode = "00" + Convert.ToString(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));//+i);
                doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
                //printPreview1.Document = doc;
                //printPreview1.PrintPreviewControl.Zoom = 1.0;
                //printPreview1.ShowDialog();
                doc.Print();
            }
        }        

        private void barcodeChange(object sender, EventArgs e)
        {
            gridToBarcode();
        }

        private void gridToBarcode()
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        if (dataGridView1.CurrentRow.Index != dataGridView1.Rows.Count - 1)
                        {
                            //bu kod barkodun ilk 2 hanesi -ülke kodu
                            barcode.CountryCode = "90";

                            //Bu kod üretici-imalatçı numarası -bu kısımın legal illegal gibi durumları da var
                            barcode.ManufacturerCode = "10001";

                            //Bu kod öğrenci -ID si 
                            barcode.ProductCode = "00" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value).ToString();

                            //Bu kısım boş geçilsede birşey değişmiyor EAN-13 te zaten 12 veri okuyorsunuz ,bu sayı  barkodun sonunda oluyor.
                            barcode.ChecksumDigit = "5";

                            picture1.Image = barcode.CreateBitmap();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gridToBarcode();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void makeFillSearchers()
        {
            textBox1.Text = "Kod'a Göre";
            textBox2.Text = "Ad'a Göre";
            textBox3.Text = "Grup'a Göre";
            textBox4.Text = "Fiyat'a Göre";
            textBox5.Text = "Marka'ya Göre";
            textBox6.Text = "İskonto'ya Göre";
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

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox3.Text = "";
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox4.Text = "";
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox5.Text = "";
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox6.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox1.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox2.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox3.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox4.Text, 3);
            dataGridView1.DataSource = table;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox5.Text, 4);
            dataGridView1.DataSource = table;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DataTable table = productOP.productListByVariable(textBox6.Text, 5);
            dataGridView1.DataSource = table;
        }        
    }
}
