using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewleryShopproject
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void btnJewellery_Click(object sender, EventArgs e)
        {
            jewellry j = new jewellry();
            j.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customer c = new customer();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sales_and_Billing b = new Sales_and_Billing();
            b.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            r.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close(); // close current form
        }
    }
    }

