using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Library_Management_System
{
    public partial class Book : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public Book()
        {
            InitializeComponent();
        }

        private void Book_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database\\LibraryManagement.accdb;Persist Security Info=False");
            con.Open();

            groupBox1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("select * from ManageBooks where Book_id like'" + textBox1.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (textBox1.Text == "")
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox13.Clear();
                    textBox12.Clear();
                    textBox14.Clear();
                    richTextBox2.Clear();
                    textBox6.Clear();
                    richTextBox1.Clear();
                }
                else if (dr.Read())
                {
                    textBox2.Text = dr.GetValue(0).ToString();
                    textBox3.Text = dr.GetValue(1).ToString();
                    richTextBox2.Text = dr.GetValue(2).ToString();
                    textBox6.Text = dr.GetValue(3).ToString();
                    richTextBox1.Text = dr.GetValue(4).ToString();
                    textBox9.Text = dr.GetValue(5).ToString();
                    textBox10.Text = dr.GetValue(6).ToString();
                    textBox4.Text = dr.GetValue(7).ToString();
                    textBox13.Text = dr.GetValue(8).ToString();
                    textBox12.Text = dr.GetValue(9).ToString();
                    textBox14.Text = dr.GetValue(10).ToString();
                }
                else
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox13.Clear();
                    textBox12.Clear();
                    textBox14.Clear();
                    richTextBox2.Clear();
                    textBox6.Clear();
                    richTextBox1.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
