using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;

namespace SendingEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            checkBox1.BackColor = Color.Transparent;


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage(from.Text, to.Text, subject.Text, body.Text);
                //username.Text = from.Text;
                mail.Attachments.Add(new Attachment(attach.Text.ToString()));
                SmtpClient sc = new SmtpClient(comboBox1.SelectedItem.ToString())
                {
                    Port = 587,
                    Credentials = new NetworkCredential(from.Text, password.Text),
                    EnableSsl = true
                };
                sc.Send(mail);
                MessageBox.Show("Email send successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error "+ex.Message,"Not sent",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "select the file";
            op.Filter = "Image file (*.png;*.jpg;*.gif;*.bmp)| *.png; *.jpg; *.gif; *.bmp | All files (*.*)|*.*";
            op.ShowDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                string path = op.FileName.ToString();
                attach.Text = path;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Go to your google account->secrity turn on Less secure app access","Note",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://myaccount.google.com/security");   
        }
    }
}
