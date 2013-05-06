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
    public partial class FormCash : DevExpress.XtraEditors.XtraForm
    {
        public FormCash()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormCash_Closing);
        }
        public bool Cancel { get; set; }
        cashOP cashOP = new cashOP();
        staffOP staffOP = new staffOP();
        DataTable cashTable = new DataTable();

        private void FormCash_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private void FormCash_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        private void formLoad()
        {
            makeFillSearchers();
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;

            groupBox1.Parent = this;
            groupBox2.Parent = this;
            groupBox3.Parent = this;
            groupBox4.Parent = this;
            groupBox5.Parent = this;

            cashTable.Clear();

            dataGridView1.DataSource = cashOP.createCashTable();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            dataGridView2.DataSource = staffOP.createStaffTable() ;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                groupBox5.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                groupBox5.Visible = false;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                groupBox5.Visible = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
	        {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count>1)
            {
                if (dataGridView2.CurrentRow.Selected)
                {
                    if (dataGridView2.SelectedRows.Count > 0)
                    {
                        if (control.integerControl(textBox1.Text))
                        {
                            if (textBox1.Text != String.Empty)
                            {
                                staffOP.staffPay(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value), System.DateTime.Now, Convert.ToInt32(textBox1.Text));
                            }
                            else
                            {
                                errorProvider1.SetError(textBox1, "Değer Giriniz");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(textBox1, "Sayı Giriniz");
                        }
                    }
                }

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (control.integerControl(textBox3.Text))
            {
                if (textBox1.Text!=string.Empty)
                {
                    
                }
                else
                {
                    errorProvider1.SetError(textBox3, "Değer Giriniz");
                }
            }
            else
            {
                errorProvider1.SetError(textBox3, "Sayı Giriniz");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (control.integerControl(textBox10.Text))
            {
                
            }
            else
            {
                errorProvider1.SetError(textBox10, "Sayı Giriniz");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
        }
        public void makeFillSearchers()
        {
            textBox2.Text = "Ad'a Göre";
            textBox12.Text = "İşlem'e Göre";
            textBox11.Text = "Tutar'a Göre";
            dateTimePicker1.Value = System.DateTime.Now;
            dateTimePicker2.Value = System.DateTime.Now;
        }
        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox2.Text = "";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = cashOP.cashListByVariable(textBox2.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            DataTable table = cashOP.cashListByVariable(textBox12.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            DataTable table = cashOP.cashListByVariable(textBox11.Text, 3);
            dataGridView1.DataSource = table;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = cashOP.cashListByDate(dateTimePicker1.Value, dateTimePicker2.Value,2);
            dataGridView1.DataSource = table;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = cashOP.cashListByDate(dateTimePicker1.Value, dateTimePicker2.Value, 2);
            dataGridView1.DataSource = table;
        }
    }
}
