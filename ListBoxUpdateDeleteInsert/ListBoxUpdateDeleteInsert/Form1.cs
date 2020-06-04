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
namespace ListBoxUpdateDeleteInsert
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;   
        public Form1()
        {
            InitializeComponent();
        }
        void showListedItems()
        {
            listBox1.Items.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Sports";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                string name = dr.GetString(0);
                listBox1.Items.Add(name);
            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showListedItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)==false)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into Sports values(@s_name)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("s_name", textBox1.Text);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("done");
                    showListedItems();
                    textBox1.Clear();
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("not done");
                }
                con.Close();
                listBox1.Sorted = true;
            }
            else
            {
                MessageBox.Show("Sports field can't be empty", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "update Sports set s_name=@s_name where s_name=@s_name1";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("s_name", textBox1.Text);
                cmd.Parameters.AddWithValue("s_name1", listBox1.SelectedItem);

                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("done");
                    showListedItems();
                    textBox1.Clear();
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("not done");
                }
                con.Close();
                listBox1.Sorted = true;
            }
            catch
            {
              MessageBox.Show("Please select one of the filed", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox1.Focus();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "delete from Sports where s_name=@s_name";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("s_name", listBox1.SelectedItem);

                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("done");

                    showListedItems();
                    textBox1.Clear();
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("not done");
                }
                con.Close();
                listBox1.Sorted = true;
            }
            catch
            {
                MessageBox.Show("Please select one of the filed", "",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                textBox1.Focus();
            }
        }
    }
}
