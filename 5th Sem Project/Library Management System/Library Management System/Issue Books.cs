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
    public partial class Issue_Details : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr,dr1,dr2;
        public Issue_Details()
        {
            InitializeComponent();
        }

        private void Issue_Details_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database\\LibraryManagement.accdb;Persist Security Info=False");
            con.Open();
            grbdetail.Hide();
            grbissue.Hide();
            grbdetail.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Enter Book Id And Student Roll Number", "BLank Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (textBox4.Text == "")
                        textBox4.Focus();
                    else
                        textBox3.Focus();
                }
                else
                {
                    cmd = new OleDbCommand("select Book_Id,ISBN_Number,Title,Author from ManageBooks where Book_Id like '" + textBox4.Text + "'", con);
                    dr = cmd.ExecuteReader();

                    cmd = new OleDbCommand("select Roll_Number,Student_Name from New_Student  where Roll_Number like '" + textBox3.Text + "'", con);
                    dr1 = cmd.ExecuteReader();

                    cmd = new OleDbCommand("select Book_Id from Issue_Books where Book_Id like '" + textBox4.Text + "'", con);
                    dr2 = cmd.ExecuteReader();

                    if (dr2.Read())
                    {
                        MessageBox.Show("Book Is Already Issue.", "Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox4.Clear();
                        textBox3.Clear();
                        textBox4.Focus();
                    }
                    else if (dr.Read() && dr1.Read())
                    {
                        grbdetail.Show();
                        grbissue.Show();
                        textBox7.Text = dr.GetValue(1).ToString();
                        textBox6.Text = dr.GetValue(2).ToString();
                        textBox5.Text = dr.GetValue(3).ToString();
                        textBox2.Text = dr1.GetValue(1).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Book Id OR Student Roll Number", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox4.Clear();
                        textBox3.Clear();
                        textBox4.Focus();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("insert into Issue_Books values('" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + dateTimePicker2.Text + "','" + dateTimePicker1.Text + "')", con);
                int res=cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("Book Issue Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox4.Clear();
                    textBox3.Clear();
                    textBox4.Focus();
                    grbdetail.Hide();
                    grbissue.Hide();
                }
                else
                {
                    MessageBox.Show("Book Not Issue", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
