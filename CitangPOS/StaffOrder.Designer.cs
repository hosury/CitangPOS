namespace CitangPOS
{
    partial class StaffOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffOrder));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.cbOrderType = new System.Windows.Forms.ComboBox();
            this.btnClearOrder = new System.Windows.Forms.Button();
            this.btnRemoveOrder = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbProductID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.tbCustomerID = new System.Windows.Forms.TextBox();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbChange = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbTotalPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAmountPaid = new System.Windows.Forms.TextBox();
            this.dgvOrderList = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cbOrderType);
            this.panel1.Controls.Add(this.btnClearOrder);
            this.panel1.Controls.Add(this.btnRemoveOrder);
            this.panel1.Controls.Add(this.btnAddOrder);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.nudQuantity);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbPrice);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbProductName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbProductID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbCategory);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvProducts);
            this.panel1.Location = new System.Drawing.Point(25, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 635);
            this.panel1.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Uighur", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(556, 458);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 38);
            this.label12.TabIndex = 16;
            this.label12.Text = "Choice";
            // 
            // cbOrderType
            // 
            this.cbOrderType.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOrderType.FormattingEnabled = true;
            this.cbOrderType.Items.AddRange(new object[] {
            "Dine In",
            "Take Out"});
            this.cbOrderType.Location = new System.Drawing.Point(652, 458);
            this.cbOrderType.Name = "cbOrderType";
            this.cbOrderType.Size = new System.Drawing.Size(225, 36);
            this.cbOrderType.TabIndex = 15;
            // 
            // btnClearOrder
            // 
            this.btnClearOrder.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearOrder.Location = new System.Drawing.Point(722, 552);
            this.btnClearOrder.Name = "btnClearOrder";
            this.btnClearOrder.Size = new System.Drawing.Size(165, 69);
            this.btnClearOrder.TabIndex = 14;
            this.btnClearOrder.Text = "Clear";
            this.btnClearOrder.UseVisualStyleBackColor = true;
            this.btnClearOrder.Click += new System.EventHandler(this.btnClearOrder_Click);
            // 
            // btnRemoveOrder
            // 
            this.btnRemoveOrder.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveOrder.Location = new System.Drawing.Point(291, 552);
            this.btnRemoveOrder.Name = "btnRemoveOrder";
            this.btnRemoveOrder.Size = new System.Drawing.Size(165, 69);
            this.btnRemoveOrder.TabIndex = 13;
            this.btnRemoveOrder.Text = "Remove";
            this.btnRemoveOrder.UseVisualStyleBackColor = true;
            this.btnRemoveOrder.Click += new System.EventHandler(this.btnRemoveOrder_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrder.Location = new System.Drawing.Point(106, 552);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(165, 69);
            this.btnAddOrder.TabIndex = 12;
            this.btnAddOrder.Text = "Add";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Uighur", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(556, 393);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 38);
            this.label7.TabIndex = 11;
            this.label7.Text = "Quantity";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuantity.Location = new System.Drawing.Point(652, 393);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(225, 38);
            this.nudQuantity.TabIndex = 10;
            this.nudQuantity.ValueChanged += new System.EventHandler(this.nudQuantity_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Uighur", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(99, 464);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 38);
            this.label6.TabIndex = 9;
            this.label6.Text = "Price";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrice.Location = new System.Drawing.Point(162, 458);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(294, 38);
            this.tbPrice.TabIndex = 8;
            this.tbPrice.TextChanged += new System.EventHandler(this.tbPrice_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Uighur", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 38);
            this.label5.TabIndex = 7;
            this.label5.Text = "Product Name";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tbProductName
            // 
            this.tbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProductName.Location = new System.Drawing.Point(162, 393);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(294, 38);
            this.tbProductName.TabIndex = 6;
            this.tbProductName.TextChanged += new System.EventHandler(this.tbProductName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Uighur", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(540, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 38);
            this.label4.TabIndex = 5;
            this.label4.Text = "Product ID";
            // 
            // tbProductID
            // 
            this.tbProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProductID.Location = new System.Drawing.Point(652, 327);
            this.tbProductID.Name = "tbProductID";
            this.tbProductID.Size = new System.Drawing.Size(225, 38);
            this.tbProductID.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Uighur", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Category";
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(162, 323);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(294, 39);
            this.cbCategory.TabIndex = 2;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Uighur", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Products";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.LightCoral;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Uighur", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.Location = new System.Drawing.Point(15, 62);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(945, 236);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            this.dgvProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.tbCustomerID);
            this.panel2.Controls.Add(this.btnReceipt);
            this.panel2.Controls.Add(this.btnPay);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.tbChange);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.tbTotalPrice);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbAmountPaid);
            this.panel2.Controls.Add(this.dgvOrderList);
            this.panel2.Location = new System.Drawing.Point(1018, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 635);
            this.panel2.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Uighur", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 32);
            this.label11.TabIndex = 20;
            this.label11.Text = "Customer ID";
            // 
            // tbCustomerID
            // 
            this.tbCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomerID.Location = new System.Drawing.Point(133, 259);
            this.tbCustomerID.Name = "tbCustomerID";
            this.tbCustomerID.Size = new System.Drawing.Size(180, 35);
            this.tbCustomerID.TabIndex = 19;
            // 
            // btnReceipt
            // 
            this.btnReceipt.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceipt.Location = new System.Drawing.Point(62, 554);
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Size = new System.Drawing.Size(210, 50);
            this.btnReceipt.TabIndex = 18;
            this.btnReceipt.Text = "Receipt";
            this.btnReceipt.UseVisualStyleBackColor = true;
            this.btnReceipt.Click += new System.EventHandler(this.btnReceipt_Click);
            // 
            // btnPay
            // 
            this.btnPay.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.Location = new System.Drawing.Point(62, 498);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(210, 50);
            this.btnPay.TabIndex = 15;
            this.btnPay.Text = "Pay Orders";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Uighur", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(49, 414);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 32);
            this.label10.TabIndex = 17;
            this.label10.Text = "Change";
            // 
            // tbChange
            // 
            this.tbChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChange.Location = new System.Drawing.Point(133, 411);
            this.tbChange.Name = "tbChange";
            this.tbChange.Size = new System.Drawing.Size(180, 35);
            this.tbChange.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Uighur", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(30, 310);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 32);
            this.label9.TabIndex = 15;
            this.label9.Text = "Total Price";
            // 
            // tbTotalPrice
            // 
            this.tbTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalPrice.Location = new System.Drawing.Point(133, 307);
            this.tbTotalPrice.Name = "tbTotalPrice";
            this.tbTotalPrice.Size = new System.Drawing.Size(180, 35);
            this.tbTotalPrice.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Uighur", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(43, 358);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 32);
            this.label8.TabIndex = 13;
            this.label8.Text = "Payment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Uighur", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = "All Orders";
            // 
            // tbAmountPaid
            // 
            this.tbAmountPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAmountPaid.Location = new System.Drawing.Point(133, 358);
            this.tbAmountPaid.Name = "tbAmountPaid";
            this.tbAmountPaid.Size = new System.Drawing.Size(180, 35);
            this.tbAmountPaid.TabIndex = 12;
            this.tbAmountPaid.TextChanged += new System.EventHandler(this.tbAmountPaid_TextChanged);
            // 
            // dgvOrderList
            // 
            this.dgvOrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderList.BackgroundColor = System.Drawing.Color.LightCoral;
            this.dgvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Uighur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(212)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrderList.Location = new System.Drawing.Point(3, 45);
            this.dgvOrderList.Name = "dgvOrderList";
            this.dgvOrderList.Size = new System.Drawing.Size(324, 194);
            this.dgvOrderList.TabIndex = 1;
            this.dgvOrderList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderList_CellContentClick);
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Khaki;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.btnLogOut.Location = new System.Drawing.Point(12, 12);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(127, 27);
            this.btnLogOut.TabIndex = 9;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click_1);
            // 
            // StaffOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(5)))), ((int)(((byte)(4)))));
            this.BackgroundImage = global::CitangPOS.Properties.Resources.noall;
            this.ClientSize = new System.Drawing.Size(1360, 700);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StaffOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffOrder";
            this.Load += new System.EventHandler(this.StaffOrder_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClearOrder;
        private System.Windows.Forms.Button btnRemoveOrder;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbProductID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReceipt;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbChange;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbTotalPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAmountPaid;
        private System.Windows.Forms.DataGridView dgvOrderList;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbCustomerID;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ComboBox cbOrderType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnLogOut;
    }
}