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


namespace WinMartDB
{
    public partial class view : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public view()
        {
            InitializeComponent();
            bindGridview();
        }
        void bindGridview()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from  Items";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows.Count > 0)
            {
                dataGridView1.DataSource = data;
            }
            else
            {
                MessageBox.Show("Not");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateDelete ud = new UpdateDelete();
            ud.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateDelete ud = new UpdateDelete();
            ud.ShowDialog();
        }

        private void view_Activated(object sender, EventArgs e)
        {
            bindGridview();
        }
    }
}
