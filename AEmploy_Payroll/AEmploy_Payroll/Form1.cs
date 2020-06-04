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

namespace AEmploy_Payroll
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            showData();
        }
        public void showData()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select *from Payroll";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable data=new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }
        public void clearAll()
        {
            id.Clear();
             name.Clear();
             designation.Clear();
            basicpay.Clear();
           incometax.Clear();
             conveyance.Clear();
           madical.Clear();
             house.Clear();
            gross.Clear();
             netsalary.Clear();
        }

        private void id_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id.Text) == true)
            {
                errorProvider1.SetError(this.id, "must be field");
                id.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }

        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text) == true)
            {
                errorProvider2.SetError(this.name, "must be field");
                name.Focus();
            }
            else
            {
                errorProvider2.Clear();
            }
            
        }

        private void designation_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(designation.Text) == true)
            {
                errorProvider3.SetError(this.designation, "must be field");
                designation.Focus();
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void basicpay_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(basicpay.Text) == true)
            {
                errorProvider4.SetError(this.basicpay, "must be field");
                //basicpay.Focus();
            }
            else
            {
                errorProvider4.Clear();
            }

        }

        private void basicpay_TextChanged(object sender, EventArgs e)
        {
            int ca, ma, hr;
            int basic_pay =0;

            if(string.IsNullOrEmpty(basicpay.Text)==true)
            {
                errorProvider4.SetError(this.basicpay, "must be field");
                basicpay.Focus();
            }
            else
            {
                errorProvider4.Clear();
                basic_pay= Convert.ToInt32(basicpay.Text);
            }

            if (basic_pay >=40000)
            {
                ca = (int)(basic_pay * 0.40);
                conveyance.Text = ca.ToString();

                ma = (int)(basic_pay * 0.30);
                madical.Text = ma.ToString();

                hr = (int)(basic_pay * 0.20);
                house.Text = hr.ToString();
                int gross_pay = ca + ma + hr + basic_pay;
                gross.Text =(ca + ma + hr+basic_pay).ToString();

                if (gross_pay >= 60000)
                {
                    int it = (int)(gross_pay * 0.030);
                    incometax.Text = it.ToString();
                    netsalary.Text = (gross_pay - it).ToString();
                }
                else if (gross_pay>=50000)
                {
                    int it = (int)(gross_pay * 0.020);
                    incometax.Text = it.ToString();
                    netsalary.Text = (gross_pay - it).ToString();
                }
            }
            else if (basic_pay >= 30000)
            {
                ca = (int)(basic_pay * 0.35);
                conveyance.Text = ca.ToString();

                ma = (int)(basic_pay * 0.25);
                madical.Text = ma.ToString();

                hr = (int)(basic_pay * 0.15);
                house.Text = hr.ToString();
                int gross_pay = ca + ma + hr + basic_pay;
                gross.Text = (ca + ma + hr + basic_pay).ToString();

                if (gross_pay >= 60000)
                {
                    int it = (int)(gross_pay * 0.030);
                    incometax.Text = it.ToString();
                    netsalary.Text = (gross_pay - it).ToString();
                }
                else if (gross_pay >= 50000)
                {
                    int it = (int)(gross_pay * 0.020);
                    incometax.Text = it.ToString();
                    netsalary.Text = (gross_pay - it).ToString();
                }
            }
            else
            {
                if (basic_pay < 30000)
                {
                    ca = 3000;
                    conveyance.Text = ca.ToString();

                    ma =2000;
                    madical.Text = ma.ToString();

                    hr =1000;
                    house.Text = hr.ToString();

                    int gross_pay = ca + ma + hr + basic_pay;
                    gross.Text = (ca + ma + hr + basic_pay).ToString();

                    int z = 0;
                    incometax.Text =z.ToString();
                    netsalary.Text = gross_pay.ToString();
      
                }
            }
            
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (Char.IsDigit(ch)||ch==8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
           
        }

        private void insertb_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into Payroll values(@id,@name,@designation,@basicpay,@incometax,@conveyance,@medical,@houserent,@grosspay,@netsalary)";
            SqlCommand cmd = new SqlCommand(query, con);
            string query2 = "select * from Payroll where id=@id";

            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@id", id.Text);
            con.Open();

            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.HasRows == true)
            {
                MessageBox.Show("ID " + id.Text + " is already taken", "error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
                con.Close();
            }
            else
            {
                con.Close();

                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@designation", designation.Text);
                cmd.Parameters.AddWithValue("@basicpay", basicpay.Text);
                cmd.Parameters.AddWithValue("@incometax", incometax.Text);
                cmd.Parameters.AddWithValue("@conveyance", conveyance.Text);
                cmd.Parameters.AddWithValue("@medical", madical.Text);
                cmd.Parameters.AddWithValue("@houserent", house.Text);
                cmd.Parameters.AddWithValue("@grosspay", gross.Text);
                cmd.Parameters.AddWithValue("@netsalary", netsalary.Text);
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
                clearAll();
                showData();
                totalEmploys();
                totalSalary();
                
            }
        }

        private void resetb_Click(object sender, EventArgs e)
        {
            clearAll();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            totalEmploys();
            
        }
        void totalEmploys()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select count(id) from Payroll";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int a = Convert.ToInt32((cmd.ExecuteScalar()));
            textBox1.Text = a.ToString();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            totalSalary();
        }

        void totalSalary()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select sum(netsalary) from Payroll";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int a = Convert.ToInt32((cmd.ExecuteScalar()));
            textBox2.Text = a.ToString();
            con.Close();
        }
    }
}
