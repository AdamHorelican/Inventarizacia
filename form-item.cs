using MySql.Data.MySqlClient;
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
            else if (textBox2.Text.Trim().Length < 2)
            {
                MessageBox.Show("Názov nie je vyplnený.");
                return;
            }
            else if (textBox3.Text.Trim().Length < 1)
            {
                MessageBox.Show("Miesto nie je vyplnené.");
                return;
            }
            else if (textBox4.Text.Trim().Length < 1)
            {
                MessageBox.Show("Kusy nie sú vyplnené.");
                return;
            }
            else
            {
                string sql = $"INSERT INTO inventarizacia(id, meno, názov, miesto, kusy) VALUES (NULL, '{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}')";
                MySqlConnection con = Dbitem.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = System.Data.CommandType.Text;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Item not added. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                Clear();
            }
            _parent.Display();
        }
    }
}
