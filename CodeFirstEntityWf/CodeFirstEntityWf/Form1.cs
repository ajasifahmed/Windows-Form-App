using CodeFirstEntityWf.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstEntityWf
{
    public partial class Form1 : Form
    {
        int id = 0;
        Employee model = new Employee();
        DatabaseContext db = new DatabaseContext();
        public Form1()
        {
            InitializeComponent();
            bindGridView();
        }
        void bindGridView()
        {
            dataGridView1.DataSource = db.Employees.ToList<Employee>();
        }
        void clearText()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedItem = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.Name = textBox1.Text;
            model.Gender = comboBox1.SelectedItem.ToString();
            model.Age = Convert.ToInt32(textBox2.Text);
            model.Designation = textBox3.Text;
            db.Employees.Add(model);
            int a=db.SaveChanges();
            if (a > 0)
            {
                MessageBox.Show("Done");
                clearText();
                bindGridView();
            }
            else
            {
                MessageBox.Show("Note Done");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            model = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            textBox1.Text = model.Name;
            textBox2.Text = model.Age.ToString();
            textBox3.Text = model.Designation;
            comboBox1.SelectedItem = model.Gender;
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            model.Id = id;
            model.Gender = comboBox1.SelectedItem.ToString();
            model.Name = textBox1.Text;
            model.Age =Convert.ToInt32(textBox2.Text);
            model.Designation = textBox3.Text;
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            int a=db.SaveChanges();
            if (a > 0)
            {
                MessageBox.Show("Done");
                clearText();
                bindGridView();
            }
            else
            {
                MessageBox.Show("Note Done");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete the selected row permenantlry", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                model = db.Employees.Where(x => x.Id == id).FirstOrDefault();
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                int a=db.SaveChanges();
                if (a > 0)
                {
                    MessageBox.Show("Done");
                    clearText();
                    bindGridView();
                }
                else
                {
                    MessageBox.Show("Note Done");
                }
            }
            else
            {
                MessageBox.Show("You cancelled the process");
            }

        }
    }
}
