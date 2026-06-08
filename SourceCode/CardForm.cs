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
    public partial class CardForm : Form
    {
        public CardForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
      
            if (txtCardNumber.Text == "" || txtCardHolder.Text == "")
            {
                MessageBox.Show("Please fill all card details");
                return;
            }

            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();

            string query = "INSERT INTO CardPayment ( CardNumber, CardHolderName) " +
                           "VALUES (@CardNumber, @CardHolderName)";

            SqlCommand cmd = new SqlCommand(query, conn);

           
            cmd.Parameters.AddWithValue("@CardNumber", txtCardNumber.Text);
            cmd.Parameters.AddWithValue("@CardHolderName", txtCardHolder.Text);
           

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Card Payment Successful!");

            this.Close();
        }
    }
    
}
