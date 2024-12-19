namespace CitangPOS
{
    partial class AdminAddProducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.dtProducedDate = new System.Windows.Forms.DateTimePicker();
            this.btnprodclear = new System.Windows.Forms.Button();
            this.btnprodremove = new System.Windows.Forms.Button();
            this.btnprodupdate = new System.Windows.Forms.Button();
            this.btnprodadd = new System.Windows.Forms.Button();
            this.btnprodimage = new System.Windows.Forms.Button();
            this.pbprod = new System.Windows.Forms.PictureBox();
            this.cbstatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbcat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbstock = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbprice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbprodname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbprodid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnback = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbprod)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.dgvProducts);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(10, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1338, 277);
            this.panel1.TabIndex = 0;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Uighur", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.Location = new System.Drawing.Point(12, 38);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(1313, 223);
            this.dgvProducts.TabIndex = 1;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Uighur", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Products";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.dtExpirationDate);
            this.panel2.Controls.Add(this.dtProducedDate);
            this.panel2.Controls.Add(this.btnprodclear);
            this.panel2.Controls.Add(this.btnprodremove);
            this.panel2.Controls.Add(this.btnprodupdate);
            this.panel2.Controls.Add(this.btnprodadd);
            this.panel2.Controls.Add(this.btnprodimage);
            this.panel2.Controls.Add(this.pbprod);
            this.panel2.Controls.Add(this.cbstatus);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbcat);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.tbstock);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tbprice);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbprodname);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbprodid);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(10, 348);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1338, 340);
            this.panel2.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(592, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 36);
            this.label9.TabIndex = 21;
            this.label9.Text = "Expiration Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(49, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 36);
            this.label8.TabIndex = 20;
            this.label8.Text = "Produced Date";
            // 
            // dtExpirationDate
            // 
            this.dtExpirationDate.CustomFormat = "\" \"";
            this.dtExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpirationDate.Location = new System.Drawing.Point(748, 212);
            this.dtExpirationDate.Name = "dtExpirationDate";
            this.dtExpirationDate.Size = new System.Drawing.Size(246, 38);
            this.dtExpirationDate.TabIndex = 19;
            this.dtExpirationDate.ValueChanged += new System.EventHandler(this.dtExpirationDate_ValueChanged);
            // 
            // dtProducedDate
            // 
            this.dtProducedDate.CustomFormat = "\" \"";
            this.dtProducedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtProducedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtProducedDate.Location = new System.Drawing.Point(209, 212);
            this.dtProducedDate.Name = "dtProducedDate";
            this.dtProducedDate.Size = new System.Drawing.Size(246, 38);
            this.dtProducedDate.TabIndex = 18;
            this.dtProducedDate.ValueChanged += new System.EventHandler(this.dtProducedDate_ValueChanged);
            // 
            // btnprodclear
            // 
            this.btnprodclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprodclear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.btnprodclear.Location = new System.Drawing.Point(787, 276);
            this.btnprodclear.Name = "btnprodclear";
            this.btnprodclear.Size = new System.Drawing.Size(170, 51);
            this.btnprodclear.TabIndex = 17;
            this.btnprodclear.Text = "Clear";
            this.btnprodclear.UseVisualStyleBackColor = true;
            this.btnprodclear.Click += new System.EventHandler(this.btnprodclear_Click);
            // 
            // btnprodremove
            // 
            this.btnprodremove.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprodremove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.btnprodremove.Location = new System.Drawing.Point(568, 276);
            this.btnprodremove.Name = "btnprodremove";
            this.btnprodremove.Size = new System.Drawing.Size(170, 51);
            this.btnprodremove.TabIndex = 16;
            this.btnprodremove.Text = "Remove";
            this.btnprodremove.UseVisualStyleBackColor = true;
            this.btnprodremove.Click += new System.EventHandler(this.btnprodremove_Click);
            // 
            // btnprodupdate
            // 
            this.btnprodupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprodupdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.btnprodupdate.Location = new System.Drawing.Point(355, 276);
            this.btnprodupdate.Name = "btnprodupdate";
            this.btnprodupdate.Size = new System.Drawing.Size(170, 51);
            this.btnprodupdate.TabIndex = 15;
            this.btnprodupdate.Text = "Update";
            this.btnprodupdate.UseVisualStyleBackColor = true;
            this.btnprodupdate.Click += new System.EventHandler(this.btnprodupdate_Click);
            // 
            // btnprodadd
            // 
            this.btnprodadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprodadd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.btnprodadd.Location = new System.Drawing.Point(136, 276);
            this.btnprodadd.Name = "btnprodadd";
            this.btnprodadd.Size = new System.Drawing.Size(170, 51);
            this.btnprodadd.TabIndex = 14;
            this.btnprodadd.Text = "Add";
            this.btnprodadd.UseVisualStyleBackColor = true;
            this.btnprodadd.Click += new System.EventHandler(this.btnprodadd_Click);
            // 
            // btnprodimage
            // 
            this.btnprodimage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprodimage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.btnprodimage.Location = new System.Drawing.Point(1143, 249);
            this.btnprodimage.Name = "btnprodimage";
            this.btnprodimage.Size = new System.Drawing.Size(116, 40);
            this.btnprodimage.TabIndex = 13;
            this.btnprodimage.Text = "Import";
            this.btnprodimage.UseVisualStyleBackColor = true;
            this.btnprodimage.Click += new System.EventHandler(this.btnprodimage_Click);
            // 
            // pbprod
            // 
            this.pbprod.Location = new System.Drawing.Point(1129, 72);
            this.pbprod.Name = "pbprod";
            this.pbprod.Size = new System.Drawing.Size(150, 150);
            this.pbprod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbprod.TabIndex = 12;
            this.pbprod.TabStop = false;
            // 
            // cbstatus
            // 
            this.cbstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbstatus.FormattingEnabled = true;
            this.cbstatus.Items.AddRange(new object[] {
            "Available",
            "Not Available"});
            this.cbstatus.Location = new System.Drawing.Point(748, 156);
            this.cbstatus.Name = "cbstatus";
            this.cbstatus.Size = new System.Drawing.Size(246, 39);
            this.cbstatus.TabIndex = 11;
            this.cbstatus.SelectedIndexChanged += new System.EventHandler(this.cbstatus_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(666, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 36);
            this.label7.TabIndex = 10;
            this.label7.Text = "Status";
            // 
            // cbcat
            // 
            this.cbcat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbcat.FormattingEnabled = true;
            this.cbcat.Location = new System.Drawing.Point(209, 156);
            this.cbcat.Name = "cbcat";
            this.cbcat.Size = new System.Drawing.Size(246, 39);
            this.cbcat.TabIndex = 9;
            this.cbcat.SelectedIndexChanged += new System.EventHandler(this.cbcat_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(93, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 36);
            this.label6.TabIndex = 8;
            this.label6.Text = "Category";
            // 
            // tbstock
            // 
            this.tbstock.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbstock.Location = new System.Drawing.Point(748, 91);
            this.tbstock.Name = "tbstock";
            this.tbstock.Size = new System.Drawing.Size(246, 38);
            this.tbstock.TabIndex = 7;
            this.tbstock.TextChanged += new System.EventHandler(this.tbstock_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(674, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 36);
            this.label5.TabIndex = 6;
            this.label5.Text = "Stock";
            // 
            // tbprice
            // 
            this.tbprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbprice.Location = new System.Drawing.Point(748, 32);
            this.tbprice.Name = "tbprice";
            this.tbprice.Size = new System.Drawing.Size(246, 38);
            this.tbprice.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(677, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 36);
            this.label4.TabIndex = 4;
            this.label4.Text = "Price";
            // 
            // tbprodname
            // 
            this.tbprodname.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbprodname.Location = new System.Drawing.Point(209, 91);
            this.tbprodname.Name = "tbprodname";
            this.tbprodname.Size = new System.Drawing.Size(246, 38);
            this.tbprodname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = "Product Name";
            // 
            // tbprodid
            // 
            this.tbprodid.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbprodid.Location = new System.Drawing.Point(209, 32);
            this.tbprodid.Name = "tbprodid";
            this.tbprodid.Size = new System.Drawing.Size(144, 38);
            this.tbprodid.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "Product ID";
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Transparent;
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(55)))));
            this.btnback.Location = new System.Drawing.Point(1, -18);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(83, 67);
            this.btnback.TabIndex = 6;
            this.btnback.Text = "⭠";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // AdminAddProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.BackgroundImage = global::CitangPOS.Properties.Resources.noall;
            this.ClientSize = new System.Drawing.Size(1360, 700);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminAddProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminAddProducts";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbprod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnprodclear;
        private System.Windows.Forms.Button btnprodremove;
        private System.Windows.Forms.Button btnprodupdate;
        private System.Windows.Forms.Button btnprodadd;
        private System.Windows.Forms.Button btnprodimage;
        private System.Windows.Forms.PictureBox pbprod;
        private System.Windows.Forms.ComboBox cbstatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbcat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbstock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbprice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbprodname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbprodid;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtExpirationDate;
        private System.Windows.Forms.DateTimePicker dtProducedDate;
    }
}