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
    public partial class Bill : Form
    {
        public string Customer;
        public string ItemName;
        public string Price;
        public string Quantity;
        public string Total;
        public Bill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("ConfirmOrder", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();

            MessageBox.Show("Bill Confirmed Successfully!");

            conn.Close();

            this.Close(); // close bill form
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bill Cancelled!");
            this.Close();
        
    }
    }
    }

