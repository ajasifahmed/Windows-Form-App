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

namespace BINDING_ONE_COMBO_BOX_WITH_ANOTHER_COMBO_BOX
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        DataRow dr;
        public Form1()
        {
            InitializeComponent();
            bindCombobox();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void bindCombobox()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select *from Countries where";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data_tb = new DataTable();
            sda.Fill(data_tb);
            dr = data_tb.NewRow();
            dr.ItemArray = new object[] { 0, "--select country--" };
            data_tb.Rows.InsertAt(dr, 0);
            comboBox1.DisplayMember = "country";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = data_tb;
        }
    }

}
