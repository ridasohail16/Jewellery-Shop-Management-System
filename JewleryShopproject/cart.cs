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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace JewleryShopproject
{

    public partial class cart : Form
    {
        public cart()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {


            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();

            string query = "SELECT TOP 1 * FROM Cart"; // only one record

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txtJewellery.Text = reader["JewelleryName"].ToString();
                txtItem.Text = reader["Item"].ToString();
                txtQuantity.Text = reader["Quantity"].ToString();
                txtPrice.Text = reader["Price"].ToString();
                txtTotal.Text = reader["Total"].ToString();
            }

            conn.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
        
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Your order is confirmed");
        }
    }
}