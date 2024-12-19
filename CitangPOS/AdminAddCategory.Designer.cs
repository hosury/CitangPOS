namespace CitangPOS
{
    partial class AdminAddCategory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnback = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCatID = new System.Windows.Forms.TextBox();
            this.btnAddCat = new System.Windows.Forms.Button();
            this.btnClearCat = new System.Windows.Forms.Button();
            this.btnRemoveCat = new System.Windows.Forms.Button();
            this.btnUpdateCat = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCats = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCat = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCats)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Transparent;
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(55)))));
            this.btnback.Location = new System.Drawing.Point(32, -16);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(55, 54);
            this.btnback.TabIndex = 5;
            this.btnback.Text = "⭠";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.label5.Location = new System.Drawing.Point(20, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 36);
            this.label5.TabIndex = 13;
            this.label5.Text = "ID";
            // 
            // tbCatID
            // 
            this.tbCatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCatID.Location = new System.Drawing.Point(19, 109);
            this.tbCatID.Name = "tbCatID";
            this.tbCatID.Size = new System.Drawing.Size(333, 35);
            this.tbCatID.TabIndex = 12;
            this.tbCatID.TextChanged += new System.EventHandler(this.tbCatID_TextChanged);
            // 
            // btnAddCat
            // 
            this.btnAddCat.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.btnAddCat.Location = new System.Drawing.Point(34, 336);
            this.btnAddCat.Name = "btnAddCat";
            this.btnAddCat.Size = new System.Drawing.Size(128, 58);
            this.btnAddCat.TabIndex = 11;
            this.btnAddCat.Text = "Add";
            this.btnAddCat.UseVisualStyleBackColor = true;
            this.btnAddCat.Click += new System.EventHandler(this.btnAddCat_Click);
            // 
            // btnClearCat
            // 
            this.btnClearCat.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.btnClearCat.Location = new System.Drawing.Point(188, 423);
            this.btnClearCat.Name = "btnClearCat";
            this.btnClearCat.Size = new System.Drawing.Size(128, 58);
            this.btnClearCat.TabIndex = 9;
            this.btnClearCat.Text = "Clear";
            this.btnClearCat.UseVisualStyleBackColor = true;
            this.btnClearCat.Click += new System.EventHandler(this.btnClearCat_Click);
            // 
            // btnRemoveCat
            // 
            this.btnRemoveCat.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.btnRemoveCat.Location = new System.Drawing.Point(34, 423);
            this.btnRemoveCat.Name = "btnRemoveCat";
            this.btnRemoveCat.Size = new System.Drawing.Size(128, 58);
            this.btnRemoveCat.TabIndex = 8;
            this.btnRemoveCat.Text = "Remove";
            this.btnRemoveCat.UseVisualStyleBackColor = true;
            this.btnRemoveCat.Click += new System.EventHandler(this.btnRemoveCat_Click);
            // 
            // btnUpdateCat
            // 
            this.btnUpdateCat.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.btnUpdateCat.Location = new System.Drawing.Point(188, 336);
            this.btnUpdateCat.Name = "btnUpdateCat";
            this.btnUpdateCat.Size = new System.Drawing.Size(128, 58);
            this.btnUpdateCat.TabIndex = 7;
            this.btnUpdateCat.Text = "Update";
            this.btnUpdateCat.UseVisualStyleBackColor = true;
            this.btnUpdateCat.Click += new System.EventHandler(this.btnUpdateCat_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.dgvCats);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(430, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 623);
            this.panel2.TabIndex = 4;
            // 
            // dgvCats
            // 
            this.dgvCats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCats.BackgroundColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Uighur", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCats.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCats.Location = new System.Drawing.Point(29, 79);
            this.dgvCats.Name = "dgvCats";
            this.dgvCats.Size = new System.Drawing.Size(866, 528);
            this.dgvCats.TabIndex = 0;
            this.dgvCats.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCats_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Uighur", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.label4.Location = new System.Drawing.Point(18, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 63);
            this.label4.TabIndex = 0;
            this.label4.Text = "Categories";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.label1.Location = new System.Drawing.Point(20, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category";
            // 
            // tbCat
            // 
            this.tbCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCat.Location = new System.Drawing.Point(19, 214);
            this.tbCat.Name = "tbCat";
            this.tbCat.Size = new System.Drawing.Size(333, 35);
            this.tbCat.TabIndex = 0;
            this.tbCat.TextChanged += new System.EventHandler(this.tbCat_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbCatID);
            this.panel1.Controls.Add(this.btnAddCat);
            this.panel1.Controls.Add(this.btnClearCat);
            this.panel1.Controls.Add(this.btnRemoveCat);
            this.panel1.Controls.Add(this.btnUpdateCat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbCat);
            this.panel1.Location = new System.Drawing.Point(13, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 623);
            this.panel1.TabIndex = 3;
            // 
            // AdminAddCategory
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
            this.Name = "AdminAddCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminAddCategory";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCats)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCatID;
        private System.Windows.Forms.Button btnAddCat;
        private System.Windows.Forms.Button btnClearCat;
        private System.Windows.Forms.Button btnRemoveCat;
        private System.Windows.Forms.Button btnUpdateCat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvCats;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCat;
        private System.Windows.Forms.Panel panel1;
    }
}