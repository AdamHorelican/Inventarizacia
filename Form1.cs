using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invetarizácia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Display()
        {
            Dbitem.DisplayAndSearch("SELECT id, meno, názov, miesto, kusy FROM inventarizacia", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_item form = new form_item(this);
            form.ShowDialog();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Dbitem.DisplayAndSearch("SELECT id, meno, názov, miesto, kusy FROM inventarizacia WHERE miesto like '%" + textBox1.Text.Trim() + "%' or názov like '%" + textBox1.Text.Trim() + "%' or meno like '%" + textBox1.Text.Trim() + "%' ", dataGridView1);
        }





        // 160, 113, 255
    }
}
