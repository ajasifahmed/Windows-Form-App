using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ShopingMartApp
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            getItems();
        }
        void getItems()
        {
            SqlConnection con = new SqlConnection(cs);
            string q = "select *from Items";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string items = dr.GetString(1);
                comboBox1.Items.Add(items);
            }
            con.Close();
        }
        void getPrice()
        {

        }
    }
}
