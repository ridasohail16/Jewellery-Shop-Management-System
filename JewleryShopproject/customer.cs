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
using System.Xml.Linq;

namespace JewleryShopproject
{
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                txtId.Clear();
                txtName.Clear();
                txtEmail.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UpdateCustomer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Customer Updated Successfully!");
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DeleteCustomer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(txtId.Text));

            cmd.ExecuteNonQuery();

            MessageBox.Show("Customer Deleted Successfully!");
            conn.Close();
        
    }
    }
    }

