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

namespace CRUD
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "insert into Employ values(@id,@e_name,@gender,@age,@designation,@salary)";
            SqlCommand cmd = new SqlCommand(query, con);

            //string query2 = "select * from Employ where id=@id";
            //SqlCommand cmd2 = new SqlCommand(query2, con);
            //cmd2.Parameters.AddWithValue("@id", textBox1.Text);
            //con.Open();

            // SqlDataReader dr=cmd2.ExecuteReader();
            //if (dr.HasRows == true)
            //{
            //    MessageBox.Show("ID " +textBox1.Text+" is already taked","error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Hand);
            //    con.Close();
            //}
            //  else
            // {

            // con.Close();
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@e_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@designation", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@salary", textBox4.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Done");
                showData();
            }
            else
            {
                MessageBox.Show("Not done");
            }
            con.Close();
            clearAll();
            //  }
        }
        void showData()
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "select * from Employ";

            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from Employ where id=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@e_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@designation", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@salary", textBox4.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Done");
                showData();
            }
            else
            {
                MessageBox.Show("Not done");
            }
            con.Close();
            clearAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        void clearAll()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            numericUpDown1.Value = 0;

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query2 = "select * from Employ where id=@id";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@id", textBox1.Text);
            con.Open();

            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.HasRows == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1,"This ID is already taked");
                con.Close();
            }
            else
            {
                errorProvider1.Clear();
                con.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (Char.IsDigit(ch) == true || ch == 8)
            {
                e.Handled = false;
            }
            //else if (ch==8)
            //{
            //    e.Handled = false;
            //}
            else
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "insert into Employ values(@id,@e_name,@salary,@gender,@age,@designation)";
            SqlCommand cmd = new SqlCommand(query, con);

            string query2 = "select * from Employ where id=@id";

            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@id", textBox1.Text);
            con.Open();

            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.HasRows == true)
            {
                MessageBox.Show("ID " + textBox1.Text + " is already taken", "error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                con.Close();
            }
            else
            {

                con.Close();
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@e_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@salary", textBox4.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@designation", comboBox2.SelectedItem);


                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Done");
                    showData();
                }
                else
                {
                    MessageBox.Show("Not done");
                }
                con.Close();
                clearAll();
            }
        }
    }
}
