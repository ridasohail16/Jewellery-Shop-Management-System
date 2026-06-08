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
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
     
            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();

            string query = "INSERT INTO Checkout ( Phone, Address ) " +
                           "VALUES ( @Phone, @Address)";

            SqlCommand cmd = new SqlCommand(query, conn);

           
            cmd.Parameters.AddWithValue("@Phone", txtPhoneno.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
          
        

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Order Confirmed");

            this.Close();
        }
    }
    }
    
