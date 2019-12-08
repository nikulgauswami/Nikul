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
    public partial class Categories : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        DataTable dt;
        public Categories()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select Any Field", "Blank Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox1.DroppedDown = true;
                }
                else if (textBox1.Text == "")
                {
                    cmd = new OleDbCommand("select * from ManageBooks", con);
                    dr = cmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        cmd = new OleDbCommand("select * from ManageBooks where Book_Id=" + int.Parse(textBox1.Text) + "", con);
                        dr = cmd.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        cmd = new OleDbCommand("select * from ManageBooks where ISBN_Number like '" + textBox1.Text + "%'", con);
                        dr = cmd.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        cmd = new OleDbCommand("select * from ManageBooks where Author like '" + textBox1.Text + "%'", con);
                        dr = cmd.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        cmd = new OleDbCommand("select * from ManageBooks where Title like '" + textBox1.Text + "%'", con);
                        dr = cmd.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                    }
                    else if (comboBox1.SelectedIndex == 4)
                    {
                        cmd = new OleDbCommand("select * from ManageBooks where Publisher like '" + textBox1.Text + "%'", con);
                        dr = cmd.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                    }
                    else if (comboBox1.SelectedIndex == 5)
                    {
                        cmd = new OleDbCommand("select * from ManageBooks where Book_Language like '" + textBox1.Text + "%'", con);
                        dr = cmd.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                    }
                    else if (comboBox1.SelectedIndex == 6)
                    {
                        cmd = new OleDbCommand("select * from ManageBooks where Description like '" + textBox1.Text + "%'", con);
                        dr = cmd.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database\\LibraryManagement.accdb;Persist Security Info=False");
            con.Open();

            cmd = new OleDbCommand("select * from ManageBooks", con);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
    }
}
