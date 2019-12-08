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
    public partial class ReturnBook_Display : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr,dr1;
        DataTable dt;
        public ReturnBook_Display()
        {
            InitializeComponent();
        }

        private void ReturnBook_Display_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database\\LibraryManagement.accdb;Persist Security Info=False");
            con.Open();

            cmd = new OleDbCommand("select * from Return_Books", con);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("select * from Return_Books where Student_Name like '" + textBox1.Text + "%'", con);
                dr1 = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr1);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
