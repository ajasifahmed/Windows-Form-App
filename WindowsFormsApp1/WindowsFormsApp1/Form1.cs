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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DataRow dr;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            bindComboBox();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          // bindComboBox();

        }
        void bindComboBox()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select *from Countries";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable data = new DataTable();
            sda.Fill(data);

            dr = data.NewRow();
            dr.ItemArray = new object[] { 0, "--Select the country name--" };
            data.Rows.InsertAt(dr, 0);
            comboBox1.DisplayMember = "country";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = data;
        }
        void bindComboBox2(int country_id)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select *from Cities where id=@cid";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            sda.SelectCommand.Parameters.AddWithValue("@cid", country_id);

            DataTable data = new DataTable();
            sda.Fill(data);

            dr = data.NewRow();
            dr.ItemArray = new object[] { 0, "--Select the citiy name--" };
            data.Rows.InsertAt(dr, 0);
            comboBox2.DisplayMember = "city";
            comboBox2.ValueMember = "id";
            comboBox2.DataSource = data;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString()!=null)
            {
                int countryid = int.Parse(comboBox1.SelectedValue.ToString());
                bindComboBox2(countryid);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand("pr_CheckedItems");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nam", textBox1.Text);
            cmd.Parameters.AddWithValue("@cricket",checkBox1.Checked);
            cmd.Parameters.AddWithValue("@cricket", checkBox1.Checked);
            cmd.Parameters.AddWithValue("@football", checkBox3.Checked);
            con.Open();
            int a=cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("DONE");
            }
            else
            {
                MessageBox.Show("NOT DONE   ");
            }
            con.Close();
            textBox1.Clear();
            //comboBox1.SelectedItem = null;
            //comboBox2.SelectedItem = null;
            //comboBox2.SelectedItem = null;
            textBox1.Focus();

        }
    }
}
