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
    public partial class Sales_and_Billing : Form
    {

        public Sales_and_Billing()
        {
            InitializeComponent();
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();

            string query = "INSERT INTO BillsMade VALUES ('" +
                           txtCustomer.Text + "','" +
                           txtItem.Text + "'," +
                           txtQuantity.Text + "," +
                           txtPrice.Text + "," +
                           txtTotal.Text + ")";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Customer " + txtCustomer.Text + " bill has been generated!");
        }
            
    
        private void ClearFields()
        {
            txtCustomer.Clear();
            txtItem.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            txtTotal.Clear();
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            int qty;
            decimal price;

            if (int.TryParse(txtQuantity.Text, out qty) &&
                decimal.TryParse(txtPrice.Text, out price))
            {
                txtTotal.Text = (qty * price).ToString();
            }
            else
            {
                txtTotal.Clear();
            }

        }
    }
}
        
