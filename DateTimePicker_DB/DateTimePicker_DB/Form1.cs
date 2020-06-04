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
using System.Threading;
namespace DateTimePicker_DB
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            Thread th = new Thread(new ThreadStart(splashStart));
            th.Start();
            Thread.Sleep(2000);
            InitializeComponent();
            th.Abort();
            bindDataGiridView();
        }
        void splashStart()
        {
            Application.Run(new Splash());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string q = "insert into DATEANDTIME values(@id,@names,@doj,@toj,@dob)";
            SqlCommand cmd = new SqlCommand(q,con);
            cmd.Parameters.AddWithValue("@id",textBox1.Text);
            cmd.Parameters.AddWithValue("@names", textBox2.Text);
            cmd.Parameters.AddWithValue("doj",dateTimePicker1.Value.ToString("dd-MM-yyyy"));
            cmd.Parameters.AddWithValue("@toj",dateTimePicker2.Value.ToString("hh:mm:ss-tt"));
            cmd.Parameters.AddWithValue("@dob",dateTimePicker3.Value.ToString("dd-MM-yyyy hh:mm:ss-tt"));
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if(a>0)
            {
                MessageBox.Show("DONE");
            }
            else
            {
                MessageBox.Show("NOT DONE");
            }
            con.Close();
            bindDataGiridView();
            textBox1.Clear();
            textBox2.Clear();

        }
        void bindDataGiridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string q = "select *from DATEANDTIME";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            dateTimePicker1.Value = DateTime.ParseExact(dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            dateTimePicker2.Value = DateTime.ParseExact(dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), "hh:mm:ss-tt", System.Globalization.CultureInfo.InvariantCulture);
            dateTimePicker3.Value = DateTime.ParseExact(dataGridView1.SelectedRows[0].Cells[4].Value.ToString(), "dd-MM-yyyy hh:mm:ss-tt", System.Globalization.CultureInfo.InvariantCulture);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string q = "update DATEANDTIME set id=@id,names=@names,doj=@doj,toj=@toj,dob=@dob where id=@id";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@names", textBox2.Text);
            cmd.Parameters.AddWithValue("doj", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
            cmd.Parameters.AddWithValue("@toj", dateTimePicker2.Value.ToString("hh:mm:ss-tt"));
            cmd.Parameters.AddWithValue("@dob", dateTimePicker3.Value.ToString("dd-MM-yyyy hh:mm:ss-tt"));
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("DONE");
            }
            else
            {
                MessageBox.Show("NOT DONE");
            }
            con.Close();
            bindDataGiridView();
            textBox1.Clear();
            textBox2.Clear();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string q = "delete from DATEANDTIME where id=@id";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@names", textBox2.Text);
            cmd.Parameters.AddWithValue("doj", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
            cmd.Parameters.AddWithValue("@toj", dateTimePicker2.Value.ToString("hh:mm:ss-tt"));
            cmd.Parameters.AddWithValue("@dob", dateTimePicker3.Value.ToString("dd-MM-yyyy hh:mm:ss-tt"));
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("DONE");
            }
            else
            {
                MessageBox.Show("NOT DONE");
            }
            con.Close();
            bindDataGiridView();
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
