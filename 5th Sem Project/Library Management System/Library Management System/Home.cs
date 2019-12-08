using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnbook_Click(object sender, EventArgs e)
        {
            Categories ct = new Categories();
            ct.Show();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            AboutUs au = new AboutUs();
            au.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Book bk = new Book();
            bk.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are You Want To Sure The Exit Application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                //Do Nothing
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Categories ct = new Categories();
            ct.Show();
        }

        private void btnbook_Click_1(object sender, EventArgs e)
        {
            Book bk = new Book();
            bk.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Manage_Student ms = new Manage_Student();
            ms.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Manage_Books mb = new Manage_Books();
            mb.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Return_Book rb = new Return_Book();
            rb.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Issue_Details  id = new Issue_Details();
            id.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Return_Book rb = new Return_Book();
            rb.Show();
        }

        private void btnstaff_Click(object sender, EventArgs e)
        {
            Manage_Books mb = new Manage_Books();
            mb.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Manage_Student ms = new Manage_Student();
            ms.Show();
        }
    }
}
