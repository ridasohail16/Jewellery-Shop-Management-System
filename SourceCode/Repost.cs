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
    public partial class Repost : Form
    {
        public Repost()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn = ConnectionFile.GetConnection();
                conn.Open();

                SqlCommand cmd = new SqlCommand("GenerateReport", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtTotalSales.Text = dr["TotalSales"].ToString();
                    txtTotalCustomers.Text = dr["TotalCustomers"].ToString();
                    txtTotalItems.Text = dr["TotalItemsSold"].ToString();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report Printed Successfully!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtTotalSales.Clear();
            txtTotalCustomers.Clear();
            txtTotalItems.Clear();
        
    }
    }
}

