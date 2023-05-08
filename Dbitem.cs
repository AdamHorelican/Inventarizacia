using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invetarizácia
{
    internal class Dbitem
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=invent.vybrat.eu;port=3306;username=c52invent;password=sR9#GsjMRf;database=c52invent";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex) 
            {
                MessageBox.Show("MySql Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;

        }
        public static void AddItem(Item std)
        {
            string sql = "INSERT INTO inventarizacia VALUES (NULL, @ItemMeno, @ItemNazov, @ItemMiesto, @ItemKusy, NULL)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text; //
            cmd.Parameters.Add("@ItemMeno", MySqlDbType.VarChar).Value = std.Meno;
            cmd.Parameters.Add("@ItemNazov", MySqlDbType.VarChar).Value = std.Nazov;
            cmd.Parameters.Add("@ItemMiesto", MySqlDbType.VarChar).Value = std.Miesto;
            cmd.Parameters.Add("@ItemKusy", MySqlDbType.VarChar).Value = std.Kusy;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Item not added. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void UpdateItem(Item std, string id)
        {
            string sql = "UPDATE inventarizacia SET meno = @ItemMeno, názov = @ItemNazov, miesto = @Miesto, kusy = @ItemKusy WHERE id = @ItemId";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text; //
            cmd.Parameters.Add("@ItemMeno", MySqlDbType.VarChar).Value = std.Meno;
            cmd.Parameters.Add("@ItemNazov", MySqlDbType.VarChar).Value = std.Nazov;
            cmd.Parameters.Add("@ItemMiesto", MySqlDbType.VarChar).Value = std.Miesto;
            cmd.Parameters.Add("@ItemKusy", MySqlDbType.VarChar).Value = std.Kusy;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Item not updated. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DeleteItem(string id)
        {
            string sql = "DELETE FROM inventarizacia WHERE id = @ItemId";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@StudentId", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Item not deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            con.Close();
        }

    }
}
