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
    public partial class jewellry : Form
    {
        public jewellry()
        {
            InitializeComponent();
        }

        private void panelInput_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("JewelleryAdd", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Quantity safe conversion
            int quantity;
            if (!int.TryParse(comboQuantity.Text, out quantity))
            {
                MessageBox.Show("Select valid quantity!");
                return;
            }

            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
            cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@Weight", Convert.ToDecimal( txtWeight.Text));

            cmd.ExecuteNonQuery();

            MessageBox.Show("Jewellery Added Successfully!");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UpdateJewellery", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@JewelleryId", Convert.ToInt32(txtId.Text));
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
            cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
            cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(comboQuantity.Text));
            cmd.Parameters.AddWithValue("@Weight", Convert.ToDecimal(txtWeight.Text));

            cmd.ExecuteNonQuery();

            MessageBox.Show("Updated Successfully!");
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DeleteJewellery", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@JewelleryId", Convert.ToInt32(txtId.Text));

            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted Successfully!");
            conn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();

            comboQuantity.SelectedIndex = -1;
            txtWeight.Clear();
            txtCategory.Clear();


            txtName.Focus();
        }
    }
}

