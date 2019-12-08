using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Vadharano
{
    public partial class Form1 : Form
    {
        OleDbCommand cmd;
        OleDbConnection con;
        OleDbDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database\\LibraryManagement.accdb;Persist Security Info=False");
            con.Open();
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("select * from Extra where Roll_Number like '" + textBox1.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (textBox1.Text == "")
                {
                    textBox2.Clear();
                }
                else if (dr.Read())
                {
                    textBox2.Text = dr.GetValue(1).ToString();
                }
                else
                {
                    textBox2.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("update Extra set Student_Name='" + textBox2.Text + "' where Roll_Number like " + textBox1.Text + "", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Okay");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
