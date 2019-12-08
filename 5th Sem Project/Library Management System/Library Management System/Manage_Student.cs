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
    public partial class Manage_Student : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public Manage_Student()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (studentName.Text == "" || rollNo.Text == "" || address.Text == "" || email.Text == "" || phoneNo.Text == "" || cource.Text == "" || admissionYear.Text == "")
                {
                    MessageBox.Show("Please Enter Value Into The Field", "Blank Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    studentName.Focus();
                }
                else
                {
                    cmd = new OleDbCommand("insert into New_Student values('" + rollNo.Text + "','" + studentName.Text + "','" + dateTimePicker1.Text + "','" + address.Text + "','" + email.Text + "','" + phoneNo.Text + "','" + cource.Text + "','" + admissionYear.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    studentName.Clear();
                    rollNo.Clear();
                    address.Clear();
                    email.Clear();
                    phoneNo.Clear();
                    cource.Clear();
                    admissionYear.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Manage_Student_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database\\LibraryManagement.accdb;Persist Security Info=False");
            con.Open();
        }

        private void bgtnaddnew_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
        }

        private void btneditdetalis_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("select * from New_Student where Roll_Number like '" + textBox2.Text + "'", con);
                dr=cmd.ExecuteReader();
                if (textBox2.Text == "")
                {
                    textBox1.Clear();
                    richTextBox1.Clear();
                    textBox6.Clear();
                    textBox5.Clear();
                    textBox4.Clear();
                    textBox3.Clear();
                    textBox2.Focus();
                }
                else if (dr.Read())
                {
                    textBox1.Text = dr.GetValue(1).ToString();
                    dateTimePicker2.Text = dr.GetValue(2).ToString();
                    richTextBox1.Text = dr.GetValue(3).ToString();
                    textBox6.Text = dr.GetValue(4).ToString();
                    textBox5.Text = dr.GetValue(5).ToString();
                    textBox4.Text = dr.GetValue(6).ToString();
                    textBox3.Text = dr.GetValue(7).ToString();
                }
                else
                {
                    textBox1.Clear();
                    richTextBox1.Clear();
                    textBox6.Clear();
                    textBox5.Clear();
                    textBox4.Clear();
                    textBox3.Clear();
                    textBox2.Focus();
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
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter Roll Number", "Blank Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                }
                else
                {
                    cmd = new OleDbCommand("update New_Student set Student_Name='" + textBox1.Text + "',Date_Of_Birth='" + dateTimePicker2.Text + "',Address='" + richTextBox1.Text + "',Email='" + textBox6.Text + "',Phone_Number='" + textBox5.Text + "',Course='" + textBox4.Text + "',Admition_Year='" + textBox3.Text + "' where Roll_Number=" + textBox2.Text + "", con);
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("Record Update Successfully.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        textBox2.Clear();
                        textBox2.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student_Display sd = new Student_Display();
            this.Hide();
            sd.Show();
        }

        private void rollNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
