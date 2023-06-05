﻿using System;
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
        form_item form;
        public Form1()
        {
            InitializeComponent();
            form = new form_item(this);
        }

        public void Display()
        {
            Dbitem.DisplayAndSearch("SELECT id, meno, názov, miesto, kusy FROM inventarizacia", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.ShowDialog();
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
            if(e.ColumnIndex == 0)
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





        // 160, 113, 255
    }
}
