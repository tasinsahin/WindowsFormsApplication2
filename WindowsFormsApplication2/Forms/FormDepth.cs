using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class FormDepth : DevExpress.XtraEditors.XtraForm
    {
        public FormDepth()
        {
            InitializeComponent();

            this.Closing += new CancelEventHandler(this.FormDepth_Closing);
        }

        deptOP deptOP = new deptOP();
        companyOP companyOP = new companyOP();
        DataTable deptTable = new DataTable();

        private void FormDepth_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide(); 
        }

        private void FormDepth_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        public void formLoad()
        {
            makeFillSearchers();
            deptTable.Clear();            
            deptTable = deptOP.createDeptTable();
            dataGridView2.DataSource = deptTable;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isInteger = control.integerControl(textBox1.Text);
            if (isInteger)
            {
                if (dataGridView2.Rows.Count > 1)
                {
                    if (dataGridView2.CurrentRow.Selected)
                    {
                        if (textBox1.Text.Length > 0)
                        {
                            if (Convert.ToInt32(textBox1.Text) != 0)
                            {
                                // customer id sini al
                                companyOP.companyPay(Convert.ToInt32(dataGridView2.CurrentRow.Cells["Kodu"].Value), System.DateTime.Now, Convert.ToInt32(textBox1.Text));
                                MessageBox.Show("Başarıyla yapıldı", "Ödeme İşlemi");
                                formLoad();
                            }
                            else
                            {
                                errorProvider1.SetError(textBox1, "Sıfırdan büyük miktar giriniz");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(textBox1, "Miktar giriniz");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("seçim yapınız", "Seçim yapmadınız");
                }
            }
            else
            {
                errorProvider1.SetError(textBox1, "Sayı Giriniz");
            }
        }
        public void makeFillSearchers()
        {
            textBox13.Text = "Kodu'na Göre";
            textBox12.Text = "Ad'ına Göre";
            textBox11.Text = "Sorumlu'ya Göre";
            textBox10.Text = "Tutar'a Göre";
        }
        private void textBox13_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox13.Text = "";
        }

        private void textBox12_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox12.Text = "";
        }

        private void textBox11_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox11.Text = "";
        }

        private void textBox10_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox10.Text = "";
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            DataTable table = deptOP.deptListByVariable(textBox13.Text,0);
            dataGridView2.DataSource = table;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            DataTable table = deptOP.deptListByVariable(textBox12.Text, 1);
            dataGridView2.DataSource = table;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            DataTable table = deptOP.deptListByVariable(textBox11.Text, 2);
            dataGridView2.DataSource = table;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            DataTable table = deptOP.deptListByVariable(textBox10.Text, 3);
            dataGridView2.DataSource = table;
        }
    }
}
