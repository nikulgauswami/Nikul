using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace Library_Management_System
{
    public partial class Manage_Books : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public Manage_Books()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void Manage_Books_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database\\LibraryManagement.accdb;Persist Security Info=False");
            con.Open();
            groupBox1.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.validateBookId(sender, e);
                cmd = new OleDbCommand("insert into ManageBooks values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + richTextBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + dateTimePicker1.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Inserted Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void validateBookId(object sender, EventArgs e)
        {
            
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd=new OleDbCommand("select * from ManageBooks where Book_Id like '"+textBox20.Text+"'",con);
                dr=cmd.ExecuteReader();
                if (textBox20.Text == "")
                {
                    textBox19.Clear();
                    textBox18.Clear();
                    textBox17.Clear();
                    richTextBox2.Clear();
                    textBox16.Clear();
                    textBox15.Clear();
                    textBox14.Clear();
                    textBox13.Clear();
                    textBox12.Clear();
                }
                else if (dr.Read())
                {
                    textBox19.Text = dr.GetValue(1).ToString();
                    textBox18.Text = dr.GetValue(2).ToString();
                    textBox17.Text = dr.GetValue(3).ToString();
                    richTextBox2.Text = dr.GetValue(4).ToString();
                    textBox16.Text = dr.GetValue(5).ToString();
                    textBox15.Text = dr.GetValue(6).ToString();
                    textBox14.Text = dr.GetValue(7).ToString();
                    textBox13.Text = dr.GetValue(8).ToString();
                    textBox12.Text = dr.GetValue(9).ToString();
                    dateTimePicker2.Text = dr.GetValue(10).ToString();
                }
                else
                {
                    textBox19.Clear();
                    textBox18.Clear();
                    textBox17.Clear();
                    richTextBox2.Clear();
                    textBox16.Clear();
                    textBox15.Clear();
                    textBox14.Clear();
                    textBox13.Clear();
                    textBox12.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox20.Text == "")
                {
                    MessageBox.Show("Enter Book Id.", "Blank Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox20.Focus();
                }
                else
                {
                    cmd = new OleDbCommand("update ManageBooks set ISBN_Number='" + textBox19.Text + "',Title='" + textBox18.Text + "',Author='" + textBox17.Text + "',Description='" + richTextBox2.Text + "',Publisher='" + textBox16.Text + "',Book_Language='" + textBox15.Text + "',Price='" + textBox14.Text + "',Book_Year='" + textBox13.Text + "',Pages='" + textBox12.Text + "',Date_Added='" + dateTimePicker2.Text + "' where Book_Id=" + textBox20.Text + "", con);
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("Record Insert Seccessfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox20.Clear();
                        textBox20.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Books_Display bd = new Books_Display();
            this.Hide();
            bd.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
