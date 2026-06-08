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
    public partial class PaymentThrough : Form
    {
        public PaymentThrough()
        {
            InitializeComponent();
        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionFile.GetConnection();
            conn.Open();



            Form nextForm = null;

            switch (cmbPaymentMethod.SelectedItem.ToString())
            {
                case "Cash":
                    MessageBox.Show("Your Order is Dispatched");
                    break;

                case "Card":
                    nextForm = new CardForm();
                    break;

                case "Online":
                    nextForm = new OnlineForm();
                    break;
            }

            if (nextForm != null)
            {
                nextForm.Show();
            }
        }
    }
    }

