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
    public partial class UpdateDelete : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public UpdateDelete()
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
                //dataGridView1.DataSource = null;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update Items set item_name=@item_name,item_price=@item_price,item_discount=@item_discount where item_id=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", textBox4.Text);
            cmd.Parameters.AddWithValue("@item_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@item_price", textBox2.Text);
            cmd.Parameters.AddWithValue("@item_discount", textBox3.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Not done");
            }
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
            bindGridview();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from Items where item_id=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", textBox4.Text);
            cmd.Parameters.AddWithValue("@item_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@item_price",textBox2.Text);
            cmd.Parameters.AddWithValue("@item_discount",textBox3.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Not done");
            }
            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
            bindGridview();

        }
    }
}
