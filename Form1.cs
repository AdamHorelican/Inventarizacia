using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Invetarizácia
{
    public partial class Form1 : Form
    {
        form_item form;
        public Form1()
        {
            InitializeComponent();
            form = new form_item(this);
        }
        public string TextBox1Value { get; set; }
        public void Display()
        {
            Dbitem.DisplayAndSearch("SELECT id, meno, názov, miesto, kusy FROM inventarizacia", dataGridView1);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_item formItem = new form_item(this);
            formItem.TextBox1Value = textBox1.Text; // Prenesie hodnotu textBox1 z Form1 do form_item
            formItem.ShowDialog();
            this.Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Dbitem.DisplayAndSearch("SELECT id, meno, názov, miesto, kusy FROM inventarizacia WHERE miesto like '%" + textBox1.Text.Trim() + "%' or názov like '%" + textBox1.Text.Trim() + "%' or meno like '%" + textBox1.Text.Trim() + "%' ", dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string selectedName = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            string targetName = TextBox1Value;
            if (selectedName == targetName)
                {
                    if (e.ColumnIndex == 0)
                    {
                        form.Clear();
                        form.id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        form.meno = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        form.nazov = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        form.miesto = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        form.kusy = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        form.UpdateInfo();
                        form.ShowDialog();
                        return;
                    }

                    if (e.ColumnIndex == 1)
                    {
                        if (MessageBox.Show("Naozaj chcete vymazať tento údaj?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Dbitem.DeleteItem(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                            Display();
                        }
                        return;
                    }
                }
                else
                {
                MessageBox.Show("Tieto údaje nemôžete zmeniť ani vymazať, pretože Vám nepatria!!!");
                }
        }





        // 160, 113, 255
    }
}
