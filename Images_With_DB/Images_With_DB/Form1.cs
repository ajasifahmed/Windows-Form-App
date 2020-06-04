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
using System.IO;
using Images_With_DB.Properties;

namespace Images_With_DB
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            bindComboBox();
            showData();
           
        }

        private void browse_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select image";
            ofd.Filter = "Image file (*.png;*.jpg;*.gif;*.bmp)| *.png; *.jpg; *.gif; *.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private byte[] savePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
           return ms.GetBuffer();
          
        }
        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            numericUpDown1.Value = 0;
            textBox1.Focus();
            pictureBox1.Image = Resources.index;

        }
        public void showData()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Students_Records";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv =(DataGridViewImageColumn)dataGridView1.Columns[3];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;

        }

        private void insert_Click(object sender, EventArgs e)
        {
           
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into Students_Records values(@id,@std_name,@age,@picture)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@std_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@picture", savePhoto());
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
                clear();
                showData();
            bindComboBox();
        }

        private void view_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void update_Click(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection(cs);
                string query = "update Students_Records set id=@id,std_name=@std_name,age=@age,picture=@picture where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@std_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@picture", savePhoto());
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
                clear();
            showData();
            bindComboBox();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
            pictureBox1.Image = getPhoto((byte[])dataGridView1.SelectedRows[0].Cells[3].Value);
        }

        private Image getPhoto(byte[] value)
        {
            MemoryStream ms = new MemoryStream(value);
            return Image.FromStream(ms);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from Students_Records where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id",textBox1.Text);
            con.Open();
           int a=cmd.ExecuteNonQuery();
            
            if (a > 0)
            {
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Not done");
            }
            con.Close();
            clear();
            showData();
            bindComboBox();
        }
        void bindComboBox()
        {
            comboBox1.Items.Clear();
            SqlConnection con = new SqlConnection(cs);
            string q = "select *from Students_Records";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                comboBox1.Items.Add(id);
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != null)
            {
                int id = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                SqlConnection con = new SqlConnection(cs);
                string q = "select *from Students_Records where id=@id";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                sda.SelectCommand.Parameters.AddWithValue("@id",id);
                DataTable data = new DataTable();
                sda.Fill(data);
                if (data.Rows.Count > 0)
                {
                    textBox3.Text = data.Rows[0]["std_name"].ToString();
                    numericUpDown2.Value = Convert.ToInt32(data.Rows[0]["age"].ToString());
                    MemoryStream ms = new MemoryStream((byte[])data.Rows[0]["picture"]);
                    pictureBox2.Image = new Bitmap(ms);
                    
                }
            }

        }
    }
}
