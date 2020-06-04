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

namespace AutoComplete
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString; 
        public Form1()
        {
            InitializeComponent();
        }
        void autoComplete()
        {
            
            SqlConnection con = new SqlConnection(cs);
            string query = "select *from Employ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                coll.Add(dr.GetString(1));
            }
            //string[] hobies = { "Eating", "Playing", "Sleeping", "Watching", "Video Games", "Walking" };
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteCustomSource=coll;
            con.Close();

        }
        void showCombo()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select *from Employ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string names = dr.GetString(1);
                comboBox1.Items.Add(names);
            }
            
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            autoComplete();
            showCombo();
        }
    }
}
