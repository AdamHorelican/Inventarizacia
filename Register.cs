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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Invetarizácia
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            textBox1.Text = textBox2.Text = string.Empty;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim().Length < 3)
            {
                MessageBox.Show("Meno nie je vyplnené.");
                return;
            }
            else if (textBox2.Text.Trim().Length < 2)
            {
                MessageBox.Show("Heslo nie je vyplnené.");
                return;
            }
            else
            {

                string sql = $"INSERT INTO login(meno, heslo) VALUES ('{textBox1.Text}', '{textBox2.Text}')";
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
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
