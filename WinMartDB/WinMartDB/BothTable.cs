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
    public partial class BothTable : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public BothTable()
        {
            InitializeComponent();
            binGridView();
        }
        /*create proc sp_BothTableSearch
@invoice_id int
as
begin
select A.invoice_id,A.username,A.[datetime],B.item_name,B.unit_price,B.discount,B.quantity,B.subtotal,B.subtotal,B.tax,B.totalcost,A.finalcost from Order_Master as A
inner join Order_Details as B
on A.invoice_id=B.invoice_id
where A.invoice_id=@invoice_id
end
*/
        void binGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "pr_Both_Table";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }
        void SearchByInvoiceId()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "sp_BothTableSearch";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@invoice_id", textBox1.Text);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.Columns[10].Visible = false;
            try { textBox2.Text = dataGridView1.Rows[0].Cells[10].Value.ToString(); }
            catch { }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchByInvoiceId();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchByInvoiceId();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "pr_BothTableSearchByDate";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@datetime1", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@datetime2", dateTimePicker2.Value);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
            }
        }

        private void All_Click(object sender, EventArgs e)
        {
            binGridView();
            textBox1.Clear();textBox2.Clear();
        }
    }
}
