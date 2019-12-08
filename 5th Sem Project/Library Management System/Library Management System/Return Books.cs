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
    public partial class Return_Book : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public Return_Book()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Issue_Return_Book_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database\\LibraryManagement.accdb;Persist Security Info=False");
            con.Open();
            comboBox1.Items.Clear();
            panel1.Enabled = false;
            groupBox1.Hide();
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            dateTimePicker3.Enabled = false;
            cmd = new OleDbCommand("select Book_Id from Issue_Books", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetValue(0).ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("select * from Issue_Books where Book_Id=" + int.Parse(comboBox1.SelectedItem.ToString()) + "", con);
                dr = cmd.ExecuteReader();
                if (comboBox1.SelectedIndex == -1)
                {
                    textBox2.Clear();
                    textBox7.Clear();
                    textBox5.Clear();
                    textBox4.Clear();
                    textBox3.Clear();
                    textBox6.Clear();
                    textBox1.Clear();
                }
                else if (dr.Read())
                {
                    textBox2.Text = dr.GetValue(0).ToString();
                    textBox7.Text = dr.GetValue(3).ToString();
                    textBox4.Text = dr.GetValue(4).ToString();
                    textBox5.Text = dr.GetValue(5).ToString();
                    textBox3.Text = dr.GetValue(2).ToString();
                    textBox6.Text = dr.GetValue(1).ToString();
                    dateTimePicker1.Text = dr.GetValue(6).ToString();
                    dateTimePicker3.Text = dr.GetValue(7).ToString();
                    groupBox1.Show();
                }
                else
                {
                    textBox2.Clear();
                    textBox7.Clear();
                    textBox5.Clear();
                    textBox4.Clear();
                    textBox3.Clear();
                    textBox6.Clear();
                    textBox1.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("delete from Issue_Books where Book_Id=" + int.Parse(comboBox1.Text) + "", con);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("insert into Return_Books values('" + textBox2.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + textBox7.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker3.Text + "','" + dateTimePicker2.Text + "','" + textBox1.Text + "')", con);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("Book Return Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Book Not Return", "Unsuccess", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReturnBook_Display rd = new ReturnBook_Display();
            this.Hide();
            rd.Show();
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
