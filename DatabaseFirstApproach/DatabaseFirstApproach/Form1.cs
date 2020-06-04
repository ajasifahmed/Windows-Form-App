using DatabaseFirstApproach.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Install-Package EntityFramework
namespace DatabaseFirstApproach
{
    public partial class Form1 : Form
    {
        int iD = 0;
        Student model = new Student();
        DatabaseFirstApproachEntities db = new DatabaseFirstApproachEntities();
        public Form1()
        {
            InitializeComponent();
            bindGridview();
        }
        void bindGridview()
        {
            dataGridView1.DataSource = db.Students.ToList<Student>();
        }
        void clearText()
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedItem = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.name = textBox1.Text.Trim();
            model.gender = comboBox1.SelectedItem.ToString();
            model.age = Convert.ToInt32(textBox3.Text);
            model.standard = Convert.ToInt32(textBox4.Text);
            db.Students.Add(model);
            int a=db.SaveChanges();
            if (a > 0)
            {
                MessageBox.Show("Done");
                bindGridview();
                clearText();
            }
            else { MessageBox.Show("Note done"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iD = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            model = db.Students.Where(x => x.id == iD).FirstOrDefault();
            model.name = textBox1.Text;
            model.gender = comboBox1.SelectedItem.ToString();
            model.age = Convert.ToInt32(textBox3.Text);
            model.standard = Convert.ToInt32(textBox4.Text);
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                MessageBox.Show("Done");
                clearText();
               bindGridview();
            }
            else
            {
                MessageBox.Show("Note Done");
            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            iD = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            model = db.Students.Where(x => x.id == iD).FirstOrDefault();
            textBox1.Text = model.name;
            textBox3.Text = model.age.ToString();
            textBox4.Text = model.standard.ToString();
            comboBox1.SelectedItem = model.gender.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete the selected row permenantlry", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                iD = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                model = db.Students.Where(x => x.id == iD).FirstOrDefault();
                textBox1.Text = model.name;
                comboBox1.SelectedItem = model.gender.ToString();
                textBox3.Text = model.age.ToString();
                textBox4.Text = model.standard.ToString();
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    MessageBox.Show("Done");
                    clearText();
                    bindGridview();
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
