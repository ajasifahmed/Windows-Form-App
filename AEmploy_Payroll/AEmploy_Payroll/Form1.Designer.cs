namespace AEmploy_Payroll
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.designation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.basicpay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.conveyance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.madical = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.house = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gross = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.incometax = new System.Windows.Forms.TextBox();
            this.netsalary = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            this.insertb = new System.Windows.Forms.Button();
            this.resetb = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(101, 12);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(100, 20);
            this.id.TabIndex = 0;
            this.id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.id_KeyPress);
            this.id.Leave += new System.EventHandler(this.id_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(101, 47);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(100, 20);
            this.name.TabIndex = 1;
            this.name.Leave += new System.EventHandler(this.name_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Designation";
            // 
            // designation
            // 
            this.designation.Location = new System.Drawing.Point(101, 84);
            this.designation.Name = "designation";
            this.designation.Size = new System.Drawing.Size(100, 20);
            this.designation.TabIndex = 2;
            this.designation.Leave += new System.EventHandler(this.designation_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Basic Pay";
            // 
            // basicpay
            // 
            this.basicpay.Location = new System.Drawing.Point(101, 140);
            this.basicpay.MaxLength = 6;
            this.basicpay.Name = "basicpay";
            this.basicpay.Size = new System.Drawing.Size(100, 20);
            this.basicpay.TabIndex = 3;
            this.basicpay.TextChanged += new System.EventHandler(this.basicpay_TextChanged);
            this.basicpay.Leave += new System.EventHandler(this.basicpay_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Conveyance";
            // 
            // conveyance
            // 
            this.conveyance.Location = new System.Drawing.Point(297, 8);
            this.conveyance.Name = "conveyance";
            this.conveyance.ReadOnly = true;
            this.conveyance.Size = new System.Drawing.Size(100, 20);
            this.conveyance.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Medical";
            // 
            // madical
            // 
            this.madical.Location = new System.Drawing.Point(297, 54);
            this.madical.Name = "madical";
            this.madical.ReadOnly = true;
            this.madical.Size = new System.Drawing.Size(100, 20);
            this.madical.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(224, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "House Rent";
            // 
            // house
            // 
            this.house.Location = new System.Drawing.Point(297, 91);
            this.house.Name = "house";
            this.house.ReadOnly = true;
            this.house.Size = new System.Drawing.Size(100, 20);
            this.house.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Gross Pay";
            // 
            // gross
            // 
            this.gross.Location = new System.Drawing.Point(297, 140);
            this.gross.Name = "gross";
            this.gross.ReadOnly = true;
            this.gross.Size = new System.Drawing.Size(100, 20);
            this.gross.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Income Tax";
            // 
            // incometax
            // 
            this.incometax.Location = new System.Drawing.Point(101, 188);
            this.incometax.Name = "incometax";
            this.incometax.ReadOnly = true;
            this.incometax.Size = new System.Drawing.Size(100, 20);
            this.incometax.TabIndex = 8;
            // 
            // netsalary
            // 
            this.netsalary.Location = new System.Drawing.Point(297, 188);
            this.netsalary.Name = "netsalary";
            this.netsalary.ReadOnly = true;
            this.netsalary.Size = new System.Drawing.Size(100, 20);
            this.netsalary.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(224, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Net Salary";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // errorProvider4
            // 
            this.errorProvider4.ContainerControl = this;
            // 
            // insertb
            // 
            this.insertb.Location = new System.Drawing.Point(101, 226);
            this.insertb.Name = "insertb";
            this.insertb.Size = new System.Drawing.Size(75, 23);
            this.insertb.TabIndex = 11;
            this.insertb.Text = "INSERT";
            this.insertb.UseVisualStyleBackColor = true;
            this.insertb.Click += new System.EventHandler(this.insertb_Click);
            // 
            // resetb
            // 
            this.resetb.Location = new System.Drawing.Point(182, 226);
            this.resetb.Name = "resetb";
            this.resetb.Size = new System.Drawing.Size(75, 23);
            this.resetb.TabIndex = 12;
            this.resetb.Text = "RESET";
            this.resetb.UseVisualStyleBackColor = true;
            this.resetb.Click += new System.EventHandler(this.resetb_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 280);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(447, 256);
            this.dataGridView1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Total Employes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(227, 251);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Total Salary";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 255);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(309, 253);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 548);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.resetb);
            this.Controls.Add(this.insertb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.netsalary);
            this.Controls.Add(this.incometax);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gross);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.house);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.madical);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.conveyance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.basicpay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.designation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox designation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox basicpay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox conveyance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox madical;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox house;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox gross;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox incometax;
        private System.Windows.Forms.TextBox netsalary;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Windows.Forms.ErrorProvider errorProvider4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button resetb;
        private System.Windows.Forms.Button insertb;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

