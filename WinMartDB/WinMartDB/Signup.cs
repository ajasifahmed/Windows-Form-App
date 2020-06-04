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
    public partial class Signup : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Signup()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            switch (check)
            {
                case true:
                    passwordtextBox.UseSystemPasswordChar = false;
                    confirmtextBox.UseSystemPasswordChar = false;
                    break;
                default:
                    passwordtextBox.UseSystemPasswordChar = true;
                    confirmtextBox.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void insertbutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into SignupTable values(@username,@surename,@gender,@age,@address,@eamil,@password)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", nametextbox.Text);
            cmd.Parameters.AddWithValue("@surename", surenametextbox.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@age", numericUpDown1.Value.ToString());
            cmd.Parameters.AddWithValue("@address", addresstextBox.Text);
            cmd.Parameters.AddWithValue("@eamil", emailtextBox.Text);
            cmd.Parameters.AddWithValue("@password", passwordtextBox.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Inserted");
                MessageBox.Show("user id " + emailtextBox.Text + "\n \n" + "Password " + passwordtextBox.Text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                login l = new login();
                l.ShowDialog();
            }
            else
            {
                MessageBox.Show("Not Done");
            }
            con.Close();
        }

        private void confirmtextBox_Leave(object sender, EventArgs e)
        {
            if (confirmtextBox.Text != passwordtextBox.Text)
            {
                confirmtextBox.Focus();
                errorProvider1.SetError(this.confirmtextBox, "passwrod does not match");
            }
            else { errorProvider1.Clear(); }
        }
    }
}
