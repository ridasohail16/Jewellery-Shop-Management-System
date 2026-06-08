using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewleryShopproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Signupform signup = new Signupform();
            signup.Show();
            this.Hide(); // hides login form
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UserLogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Role", comboRole.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())   // ✅ better than HasRows
            {
                string role = dr["Role"].ToString();

                MessageBox.Show("Login Successful!");

                if (role == "Admin")
                {
                    DashboardForm a = new DashboardForm();
                    a.Show();
                }
                else
                {
                    CustomerDashboard c = new CustomerDashboard();
                    c.Show();
                }

                this.Hide(); // hide login form
            }
            else
            {
                MessageBox.Show("Invalid Login");
            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ForgetForm f = new ForgetForm();
            f.Show();
        }
    }
}

