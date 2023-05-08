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
    public partial class form_item : Form
    {
        private readonly Form1 _parent;
        public form_item(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void Clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length < 3)
            {
                MessageBox.Show("Meno nie je vyplnené.");
                return;
            }
            if (textBox1.Text.Trim().Length < 2)
            {
                MessageBox.Show("Názov nie je vyplnený.");
                return;
            }
            if (textBox1.Text.Trim().Length < 1)
            {
                MessageBox.Show("Miesto nie je vyplnené.");
                return;
            }
            if (textBox1.Text.Trim().Length < 1)
            {
                MessageBox.Show("Kusy nie sú vyplnené.");
                return;
            }
            if(button1.Text == "Uložiť")
            {
                Item std = new Item(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim());
                Dbitem.AddItem(std);
                Clear();
            }
            _parent.Display();
        }
    }
}
