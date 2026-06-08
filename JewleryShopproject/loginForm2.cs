using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewleryShopproject
{
    public partial class Signupform : Form
    {
        public Signupform()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("AddUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Convert DOB
            int date = Convert.ToInt32(comboDate.Text);
            int month = Convert.ToInt32(comboMonth.Text);
            int year = Convert.ToInt32(comboYear.Text);

            DateTime dob = new DateTime(year, month, date);

            // Parameters
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Gender", comboGender.Text);
            cmd.Parameters.AddWithValue("@DOB", dob);
            cmd.Parameters.AddWithValue("@Role", comboRole.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

            // Execute INSERT (no reader needed)
            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Signup Successful!");

                string role = comboRole.Text; // ✅ take role from input

                if (role == "Admin")
                {
                    DashboardForm admin = new DashboardForm();
                    admin.Show();
                }
                else if (role == "Customer")
                {
                    CustomerDashboard customer = new CustomerDashboard();
                    customer.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Signup Failed!");
            }

            conn.Close();
        }
        private void btnbacktologin_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1(); // your login form
            login.Show();
            this.Hide();
        }
    }
    }
