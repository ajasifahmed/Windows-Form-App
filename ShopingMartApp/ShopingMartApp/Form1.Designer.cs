namespace ShopingMartApp
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
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.finalcost = new System.Windows.Forms.Label();
            this.discountperitems = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.totalcost = new System.Windows.Forms.Label();
            this.unitprice = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.tax = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.selectedItems = new System.Windows.Forms.Label();
            this.change = new System.Windows.Forms.Label();
            this.subtotal = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.quantitiy = new System.Windows.Forms.TextBox();
            this.amountpaid = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.invoice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(208, 275);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(121, 20);
            this.textBox10.TabIndex = 9;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(11, 275);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(121, 20);
            this.textBox5.TabIndex = 4;
            // 
            // finalcost
            // 
            this.finalcost.AutoSize = true;
            this.finalcost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalcost.Location = new System.Drawing.Point(208, 258);
            this.finalcost.Name = "finalcost";
            this.finalcost.Size = new System.Drawing.Size(63, 13);
            this.finalcost.TabIndex = 4;
            this.finalcost.Text = "Final Cost";
            // 
            // discountperitems
            // 
            this.discountperitems.AutoSize = true;
            this.discountperitems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discountperitems.Location = new System.Drawing.Point(11, 258);
            this.discountperitems.Name = "discountperitems";
            this.discountperitems.Size = new System.Drawing.Size(108, 13);
            this.discountperitems.TabIndex = 5;
            this.discountperitems.Text = "Discount Per Item";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(208, 221);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(121, 20);
            this.textBox9.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(11, 221);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(121, 20);
            this.textBox4.TabIndex = 3;
            // 
            // totalcost
            // 
            this.totalcost.AutoSize = true;
            this.totalcost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalcost.Location = new System.Drawing.Point(208, 204);
            this.totalcost.Name = "totalcost";
            this.totalcost.Size = new System.Drawing.Size(65, 13);
            this.totalcost.TabIndex = 8;
            this.totalcost.Text = "Total Cost";
            // 
            // unitprice
            // 
            this.unitprice.AutoSize = true;
            this.unitprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitprice.Location = new System.Drawing.Point(11, 204);
            this.unitprice.Name = "unitprice";
            this.unitprice.Size = new System.Drawing.Size(63, 13);
            this.unitprice.TabIndex = 9;
            this.unitprice.Text = "Unit Price";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(208, 164);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(121, 20);
            this.textBox8.TabIndex = 7;
            // 
            // tax
            // 
            this.tax.AutoSize = true;
            this.tax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tax.Location = new System.Drawing.Point(208, 147);
            this.tax.Name = "tax";
            this.tax.Size = new System.Drawing.Size(28, 13);
            this.tax.TabIndex = 10;
            this.tax.Text = "Tax";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(374, 93);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(121, 20);
            this.textBox12.TabIndex = 11;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(209, 93);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(121, 20);
            this.textBox7.TabIndex = 6;
            // 
            // selectedItems
            // 
            this.selectedItems.AutoSize = true;
            this.selectedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedItems.Location = new System.Drawing.Point(11, 147);
            this.selectedItems.Name = "selectedItems";
            this.selectedItems.Size = new System.Drawing.Size(91, 13);
            this.selectedItems.TabIndex = 12;
            this.selectedItems.Text = "Selected Items";
            // 
            // change
            // 
            this.change.AutoSize = true;
            this.change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change.Location = new System.Drawing.Point(374, 64);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(50, 13);
            this.change.TabIndex = 13;
            this.change.Text = "Change";
            // 
            // subtotal
            // 
            this.subtotal.AutoSize = true;
            this.subtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotal.Location = new System.Drawing.Point(209, 64);
            this.subtotal.Name = "subtotal";
            this.subtotal.Size = new System.Drawing.Size(62, 13);
            this.subtotal.TabIndex = 11;
            this.subtotal.Text = "Sub Total";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 93);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(121, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(374, 32);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(121, 20);
            this.textBox11.TabIndex = 10;
            // 
            // quantitiy
            // 
            this.quantitiy.Location = new System.Drawing.Point(209, 32);
            this.quantitiy.Name = "quantitiy";
            this.quantitiy.Size = new System.Drawing.Size(121, 20);
            this.quantitiy.TabIndex = 5;
            // 
            // amountpaid
            // 
            this.amountpaid.AutoSize = true;
            this.amountpaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountpaid.Location = new System.Drawing.Point(374, 15);
            this.amountpaid.Name = "amountpaid";
            this.amountpaid.Size = new System.Drawing.Size(78, 13);
            this.amountpaid.TabIndex = 7;
            this.amountpaid.Text = "Amount Paid";
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(12, 64);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(33, 13);
            this.user.TabIndex = 6;
            this.user.Text = "User";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(209, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Quantity";
            // 
            // invoice
            // 
            this.invoice.Location = new System.Drawing.Point(12, 32);
            this.invoice.Name = "invoice";
            this.invoice.ReadOnly = true;
            this.invoice.Size = new System.Drawing.Size(121, 20);
            this.invoice.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Invoice Number";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 321);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(665, 192);
            this.dataGridView1.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(374, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(455, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 28;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 162);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 525);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.finalcost);
            this.Controls.Add(this.discountperitems);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.totalcost);
            this.Controls.Add(this.unitprice);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.tax);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.selectedItems);
            this.Controls.Add(this.change);
            this.Controls.Add(this.subtotal);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.quantitiy);
            this.Controls.Add(this.amountpaid);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.invoice);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label finalcost;
        private System.Windows.Forms.Label discountperitems;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label totalcost;
        private System.Windows.Forms.Label unitprice;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label tax;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label selectedItems;
        private System.Windows.Forms.Label change;
        private System.Windows.Forms.Label subtotal;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox quantitiy;
        private System.Windows.Forms.Label amountpaid;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox invoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

