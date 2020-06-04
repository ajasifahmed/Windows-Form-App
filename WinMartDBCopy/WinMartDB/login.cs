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
    public partial class login : Form
    {
        public static string user = "";
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public login()
        {
            InitializeComponent();
            loadCredentials();
        }
        void saveCredentials()
        {
            if (checkBox2.Checked == true)
            {
                Properties.Settings.Default.username = textBox1.Text;
                Properties.Settings.Default.password = textBox2.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.username = "";
                Properties.Settings.Default.password = "";
                Properties.Settings.Default.Save();
            }
        }
        void loadCredentials()
        {
            if (Properties.Settings.Default.username != string.Empty)
            {
                textBox1.Text = Properties.Settings.Default.username;
                textBox2.Text = Properties.Settings.Default.password;
                checkBox2.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from SignupTable where eamil=@eamil and password=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@eamil", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                   // MessageBox.Show("Login Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    user = textBox1.Text;
                    this.Hide();
                    Form1 f1 = new Form1();
                    f1.Show();

                }
                else
                {
                    MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Please fill the both filed", "Empty", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
           saveCredentials();
            textBox1.Clear(); textBox2.Clear();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            switch (check)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup su = new Signup();
            this.Hide();
            su.ShowDialog();
        }
    }
}
