using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewleryShopproject
{
    public partial class ForgetForm : Form
    {
        public ForgetForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnRecover_Click(object sender, EventArgs e)
        {

            // 🔴 Validation
            if (txtUsername.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Please enter Username and Email");
                return;
            }

            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("RecoverPassword", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // ✅ Parameters (MUST match SQL procedure)
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string password = dr["Password"].ToString();
                MessageBox.Show("Your Password is: " + password);
            }
            else
            {
                MessageBox.Show("Invalid Username or Email");
            }

            dr.Close();
            conn.Close();
        }
    }
}

