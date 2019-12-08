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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "" && txtpass.Text == "")
            {
                MessageBox.Show("Please Enter Value Into The Field", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtuser.Text == "")
                    txtuser.Focus();
                else
                    txtpass.Focus();
            }
            else if (txtuser.Text == "admin" && txtpass.Text == "admin")
            {
                Home h1 = new Home();
                this.Hide();
                h1.Show();
            }
            else
            {
                MessageBox.Show("Wrong Username And Password", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
