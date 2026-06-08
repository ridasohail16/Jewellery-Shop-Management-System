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
    public partial class customerJewellery : Form
    {
        public customerJewellery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        
            try
            {
                SqlConnection conn = ConnectionFile.GetConnection();
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                "SELECT Price FROM Jewellery WHERE Name=@j AND Category=@i", conn);

                cmd.Parameters.AddWithValue("@j", txtJewellery.Text);
                cmd.Parameters.AddWithValue("@i", txtItem.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtPrice.Text = dr["Price"].ToString();
                }
                else
                {
                    txtPrice.Clear();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int price, qty;

            if (int.TryParse(txtPrice.Text, out price) &&
                int.TryParse(txtQuantity.Text, out qty))
            {
                txtTotal.Text = (price * qty).ToString();
            }
            else
            {
                txtTotal.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
      
            try
            {
                SqlConnection conn = ConnectionFile.GetConnection();
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Cart (JewelleryName, Item, Quantity, Price, Total) " +
                "VALUES (@j,@i,@q,@p,@t)", conn);

                cmd.Parameters.AddWithValue("@j", txtJewellery.Text);
                cmd.Parameters.AddWithValue("@i", txtItem.Text);
                cmd.Parameters.AddWithValue("@q", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@p", txtPrice.Text);
                cmd.Parameters.AddWithValue("@t", txtTotal.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Added to Cart!");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
      
            try
            {
                SqlConnection conn = ConnectionFile.GetConnection();
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Cart", conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cart Cleared!");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            cart v = new cart();
            v.Show();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
       
          
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
   
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            txtJewellery.Clear();
            txtItem.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtTotal.Clear();
        }
    }
    }
    
    

 

