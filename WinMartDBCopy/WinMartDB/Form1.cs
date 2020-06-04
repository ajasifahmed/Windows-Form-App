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
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int price = 0;
        int S = 0;
        
        public Form1()
        {
            InitializeComponent();
            getItems();
            user.Text = login.user;
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "Sno.";
            dataGridView1.Columns[1].Name = "Item Name";
            dataGridView1.Columns[2].Name = "Unit Price";
            dataGridView1.Columns[3].Name = "Discount";
            dataGridView1.Columns[4].Name = "Quantity";
            dataGridView1.Columns[5].Name = "Sub Total";
            dataGridView1.Columns[6].Name = "Tax";
            dataGridView1.Columns[7].Name = "Total Cost";
            getInvoiceid();
        }
        void getItems()
        {
            comboBox1.Items.Clear();
            SqlConnection con = new SqlConnection(cs);
            string q = "select *from Items";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
           
            while (dr.Read())
            {
                string items = dr.GetString(1);
                comboBox1.Items.Add(items);
            }
            comboBox1.Sorted = true;
            con.Close();
        }
        void getPrice()
        {
            if (comboBox1.SelectedItem == null) { }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string q = "select item_price from Items where item_name=@item_name";
                SqlDataAdapter sda = new SqlDataAdapter(q, con);
                sda.SelectCommand.Parameters.AddWithValue("@item_name", comboBox1.SelectedItem);
                DataTable data = new DataTable();
                sda.Fill(data);
                if (data.Rows.Count > 0)
                {
                    price = Convert.ToInt32(data.Rows[0]["item_price"]);
                }
                unitprice.Text = price.ToString();
            }
          
        }
        void getDiscount()
        {
            if (comboBox1.SelectedItem == null) { }
            SqlConnection con = new SqlConnection(cs);
            string q = "select item_discount from Items where item_name=@item_name";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
            sda.SelectCommand.Parameters.AddWithValue("@item_name", comboBox1.SelectedItem);
            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows.Count > 0)
            {
                price = Convert.ToInt32(data.Rows[0]["item_discount"]);
            }
            discountperitems.Text = price.ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                addItemsToGridview((++S).ToString(), comboBox1.SelectedItem.ToString(), unitprice.Text, discountperitems.Text, quantity.Text, subtotal.Text, tax.Text, totalcost.Text);
                clearText();
                getFinal();
            }
            else { MessageBox.Show("Please select the items"); }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) { }
            else
            {
                getPrice();
                getDiscount();
                quantity.Enabled = true;
            }
        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(quantity.Text) == true) { }
            else
            {

                int q = Convert.ToInt32(quantity.Text);
                int d = Convert.ToInt32(discountperitems.Text);
                int up = Convert.ToInt32(unitprice.Text);
                int subtot = (up * q) - (d * q);
                subtotal.Text = subtot.ToString();
            }
        }

        private void subtotal_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(subtotal.Text) == true) { }
            else
            {
                int subtot = Convert.ToInt32(subtotal.Text);

                if (subtot > 1000)
                {
                    int tx = (int)(subtot * 0.1);
                    tax.Text = tx.ToString();
                }
                else if (subtot > 6000)
                {
                    int tx = (int)(subtot * 0.2);
                    tax.Text = tx.ToString();
                }
                else if (subtot > 8000)
                {
                    int tx = (int)(subtot * 0.3);
                    tax.Text = tx.ToString();
                }
                else
                {
                    int tx = (int)(subtot * 0.01);
                    tax.Text = tx.ToString();
                }
            }
           
        }

        private void tax_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tax.Text) == true) { }
            else
            {

                int subtot = Convert.ToInt32(subtotal.Text);
                int tx = Convert.ToInt32(tax.Text);
                totalcost.Text = (subtot + tx).ToString();
            }
        }
        void addItemsToGridview(string s_no,string itemname,string price,string disc,string quant,string subt,string tx,string totcost)
        {
            string[]row= { s_no, itemname, price, disc, quant, subt, tx, totcost };
            dataGridView1.Rows.Add(row);
        }
        void clearText()
        {
            comboBox1.SelectedItem = null;
            unitprice.Clear();
            discountperitems.Clear();
            quantity.Clear();
            subtotal.Clear();
            tax.Clear();
            totalcost.Clear();
            change.Clear();
            amouuntpaid.Clear();
            finalcost.Clear();
            quantity.Enabled = false;
        }
        void getFinal()
        {
            int f = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                f = f + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
            }
           finalcost.Text = f.ToString();
        }

        private void amouuntpaid_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(amouuntpaid.Text) == true) { }
            else
            {
                int f = Convert.ToInt32(finalcost.Text);
                int payment = Convert.ToInt32(amouuntpaid.Text);
                int remainig = f - payment;
                change.Text = remainig.ToString();
             
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            S = 0;
        }
        void getInvoiceid()
        {
            SqlConnection con = new SqlConnection(cs);
            string q = "select invoice_id from Order_Master";
            SqlDataAdapter sda = new SqlDataAdapter(q, con);
           
            DataTable data = new DataTable();
            sda.Fill(data);
            if (data.Rows.Count < 1)
            {
                invoice.Text = "1";
            }
            else
            {
                SqlConnection con2 = new SqlConnection(cs);
                string q2 = "select max(invoice_id) from Order_Master";
                SqlCommand cmd = new SqlCommand(q2, con2);
                con2.Open();
                int a=Convert.ToInt32(cmd.ExecuteScalar());
                a+=1;
                invoice.Text = a.ToString();
                con2.Close();
            }
            
        }

        private void insert_to_db_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(finalcost.Text) == false || string.IsNullOrEmpty(amouuntpaid.Text) == false)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into Order_Master values(@inv_id,@username,@datetime,@finalcost)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@inv_id", invoice.Text);
                cmd.Parameters.AddWithValue("@username", user.Text);
                cmd.Parameters.AddWithValue("@datetime", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@finalcost", finalcost.Text);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Inserted");
                    getInvoiceid();
                    clearText();

                }
                else
                {
                    MessageBox.Show("Not Done");
                }
                con.Close();
                insertInto_DB();
            }
            else { MessageBox.Show("Fields are empty"); }
        }

        private void quantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void amouuntpaid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bitmap = Properties.Resources.print;
            Image image = bitmap;
            e.Graphics.DrawImage(image, 30, 5, 800, 250);
            e.Graphics.DrawString("Invoice ID: " + invoice.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 300));
            e.Graphics.DrawString("Username: " +user.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 330));
            e.Graphics.DrawString("Date: " +DateTime.Now.ToShortDateString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 360));
            e.Graphics.DrawString("Time: " +DateTime.Now.ToLongTimeString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 390));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 420));
            e.Graphics.DrawString("Selected Items", new Font("Arial", 15, FontStyle.Underline), Brushes.Black, new Point(30,450));
            e.Graphics.DrawString("Unit Price", new Font("Arial", 15, FontStyle.Underline), Brushes.Black, new Point(200, 450));
            e.Graphics.DrawString("Quantity", new Font("Arial", 15, FontStyle.Underline), Brushes.Black, new Point(350, 450));
            e.Graphics.DrawString("Discount", new Font("Arial", 15, FontStyle.Underline), Brushes.Black, new Point(500, 450));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 480));
            //items
            int gape1 = 510;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i <dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, gape1));
                        gape1 += 30;
                    }
                    catch { }
                }
            }
            //Unite price
            int gape2 = 510;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(200, gape2));
                        gape2 += 30;
                    }
                    catch { }
                }
            }
           
            //Quantity
            int gape4 = 510;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(500, gape4));
                        gape4 += 30;
                    }
                    catch { }
                }
            }
            //Discount
            int gape3 = 510;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(350, gape3));
                        gape3 += 30;
                    }
                    catch { }
                }
            }
            //-Subtotal

            e.Graphics.DrawString("--------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 900));
            int st = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                st = st + Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
            }
            e.Graphics.DrawString("Sub Total:" + st, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 920));
            //Tax

            int t = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                t = t + Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
            }
            e.Graphics.DrawString("Tax: " +t, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 940));

            //Final Amount
            e.Graphics.DrawString("Final Amount: " + finalcost.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 960));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 980));

            //Amount Paid
            e.Graphics.DrawString("Amount Paid: " + amouuntpaid.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 1020));
            e.Graphics.DrawString("Change: " + change.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 1040));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 1060));


            //e.Graphics.DrawString("--------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 900));
            //e.Graphics.DrawString("Sub Total: " +subtotal.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 920));
            //e.Graphics.DrawString("Tax: " +tax.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 940));
            //e.Graphics.DrawString("Final Amount: " + finalcost.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 960));
            //e.Graphics.DrawString("--------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 980));


            
        }

        private void addItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            getItems();
        }

        private void editItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDelete ud = new UpdateDelete();
            ud.ShowDialog();
        }

        private void viewDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view v = new view();
            v.ShowDialog();
        }
        int getLastInvoiceId()
        {
            SqlConnection con = new SqlConnection(cs);
            string q = "select max(invoice_id) from Order_Master";
            SqlCommand cmd = new SqlCommand(q,con);
            con.Open();
            int Maxid = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Maxid;
        }
        void insertInto_DB()
        {
            SqlConnection con = new SqlConnection(cs);
           
            int a = 0;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string q = "insert into Order_Details values(@inv_id,@item_name,@unit_price,@discount,@quantity,@subtotal,@tax,@totalcost)";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@inv_id", getLastInvoiceId());
                    cmd.Parameters.AddWithValue("@item_name", dataGridView1.Rows[i].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@unit_price", dataGridView1.Rows[i].Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@discount", dataGridView1.Rows[i].Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("@quantity", dataGridView1.Rows[i].Cells[4].Value.ToString());
                    cmd.Parameters.AddWithValue("@subtotal", dataGridView1.Rows[i].Cells[5].Value.ToString());
                    cmd.Parameters.AddWithValue("@tax", dataGridView1.Rows[i].Cells[6].Value.ToString());
                    cmd.Parameters.AddWithValue("@totalcost", dataGridView1.Rows[i].Cells[7].Value.ToString());
                    con.Open();
                    a = a + cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch { }
            if (a > 0) { MessageBox.Show("Done"); }
            else { MessageBox.Show("Not done"); }
           
        }

        private void viewAllDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BothTable b = new BothTable();
            b.ShowDialog();
        }
    }
}
/* dataGridView1.Columns[0].Name = "Sno.";
            dataGridView1.Columns[1].Name = "Item Name";
            dataGridView1.Columns[2].Name = "Unit Price";
            dataGridView1.Columns[3].Name = "Discount";
            dataGridView1.Columns[4].Name = "Quantity";
            dataGridView1.Columns[5].Name = "Sub Total";
            dataGridView1.Columns[6].Name = "Tax";
            dataGridView1.Columns[7].Name = "Total Cost";*/
