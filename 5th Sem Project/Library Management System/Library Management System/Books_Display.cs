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
    public partial class Books_Display : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr,dr1;
        DataTable dt;
        public Books_Display()
        {
            InitializeComponent();
        }

        public void display()
        {
            cmd = new OleDbCommand("select * from ManageBooks", con);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void Books_Display_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database\\LibraryManagement.accdb;Persist Security Info=False");
            con.Open();
            display();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("select * from ManageBooks where Book_id like'" + textBox1.Text + "%'", con);
                dr1 = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr1);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                if (e.ColumnIndex == 0)
                {
                    cmd = new OleDbCommand("delete from ManageBooks where Book_id=" + id + "", con);
                    cmd.ExecuteNonQuery();
                    display();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
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
