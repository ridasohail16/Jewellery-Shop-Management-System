using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewleryShopproject
{
    internal class ConnectionFile
    {
        public static SqlConnection GetConnection()
        {
            string con = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=jewelleryshop;Integrated Security=True;TrustServerCertificate=True";
            return new SqlConnection(con);

            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=jewelleryshop;Integrated Security=True;TrustServerCertificate=True");

            conn.Open();
            MessageBox.Show("Connected Successfully!");
            conn.Close();
        }
    }
}


