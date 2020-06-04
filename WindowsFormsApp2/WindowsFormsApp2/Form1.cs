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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Records(names,email) values(@names,@email)", con);
            cmd.Parameters.AddWithValue("@names",textBox2.Text);
            cmd.Parameters.AddWithValue("@email", textBox3.Text);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            SqlCommand cmd2 = new SqlCommand("insert into Records_2(phones) values(@phones)", con);
          
            cmd2.Parameters.AddWithValue("@phones", phone.Text);
            //cmd2.Parameters.AddWithValue("@phones",textBox5.Text);
            cmd2.ExecuteNonQuery();
            cmd2.Parameters.Clear();
            MessageBox.Show("done");
        }
    }
}
