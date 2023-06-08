using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invetarizácia
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            
        }
        public string TextBox1Value
        {
            get { return textBox1.Text; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT meno, heslo FROM login WHERE meno = @Meno AND heslo = @Heslo";
            MySqlConnection con = Dbitem.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);

            string zadaneMeno = textBox1.Text;
            string zadaneHeslo = textBox2.Text;
           

            cmd.Parameters.AddWithValue("@Meno", zadaneMeno);
            cmd.Parameters.AddWithValue("@Heslo", zadaneHeslo);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string menoVDB = reader.GetString(reader.GetOrdinal("meno"));
                        string hesloVDB = reader.GetString(reader.GetOrdinal("heslo"));

                        if (zadaneMeno == menoVDB && zadaneHeslo == hesloVDB)
                        {
                            if (zadaneMeno == "admin" && zadaneHeslo == "admin")
                            {
                                Console.WriteLine("Meno sa zhoduje!");
                                this.Hide();
                                Register form = new Register();
                                form.ShowDialog();
                                this.Show();
                            }
                            else
                            {
                                Console.WriteLine("Meno sa zhoduje!");
                                this.Hide();
                                Form1 form1 = new Form1();
                                form1.TextBox1Value = textBox1.Text; // Prenesie hodnotu textBox1 do Form1
                                form1.Show();
                                

                            }
                        }
                        else
                        {
                            Console.WriteLine("Meno sa nezhoduje!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Meno nebolo nájdené v databáze!");
                }
            }

            con.Close();
        }

      
    }
}
