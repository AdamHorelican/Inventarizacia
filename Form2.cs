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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        public void Display()
        {
            Dbitem.DisplayAndSearch("SELECT id, meno, názov, miesto, kusy FROM inventarizacia", dataGridView1);
        }
        private void Form2_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Dbitem.DisplayAndSearch("SELECT id, meno, názov, miesto, kusy FROM inventarizacia WHERE miesto like '%" + textBox1.Text.Trim() + "%' or názov like '%" + textBox1.Text.Trim() + "%' or meno like '%" + textBox1.Text.Trim() + "%' ", dataGridView1);
        }
    }
}
