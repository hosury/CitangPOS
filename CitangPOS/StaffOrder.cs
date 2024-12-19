using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace CitangPOS
{
    public partial class StaffOrder : Form
    {
        private OleDbConnection connection;
        private DataTable orderTable;
        private decimal totalPrice = 0;
        private int userId;


        public StaffOrder(int userId)
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            InitializeOrderTable();
            LoadCategories();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";
            connection = new OleDbConnection(connectionString);
        }

        private void InitializeOrderTable()
        {
            
            orderTable = new DataTable();

           
            orderTable.Columns.Add("Product ID");
            orderTable.Columns.Add("Product Name");
            orderTable.Columns.Add("Price", typeof(decimal));
            orderTable.Columns.Add("Quantity", typeof(int));
            orderTable.Columns.Add("Total", typeof(decimal));
            orderTable.Columns.Add("Change", typeof(decimal));

           
            dgvOrderList.DataSource = orderTable;

            
            dgvOrderList.AutoGenerateColumns = true;
        }

        private void LoadCategories()
        {
            cbCategory.Items.Clear();

            try
            {
               
                using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;"))
                {
                    connection.Open();

                   
                    string query = "SELECT category FROM category";
                    OleDbCommand cmd = new OleDbCommand(query, connection);

                    OleDbDataReader reader = cmd.ExecuteReader();

                   
                    while (reader.Read())
                    {
                        string category = reader["category"].ToString();
                        cbCategory.Items.Add(category);
                    }

                   
                    if (cbCategory.Items.Count > 0)
                    {
                        cbCategory.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No categories found in the database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cbCategory.SelectedItem.ToString();
            LoadProductsByCategory(selectedCategory);
        }

        private void LoadProductsByCategory(string category)
        {
            try
            {
                
                DataTable productsTable = new DataTable();

                
                using (OleDbConnection tempConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;"))
                {
                    tempConnection.Open();

                    
                    string query = "SELECT product_ID, product_name, price, stock FROM products WHERE category = @category";
                    OleDbCommand cmd = new OleDbCommand(query, tempConnection);
                    cmd.Parameters.AddWithValue("@category", category); 

                   
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(productsTable); 

                   
                    dgvProducts.DataSource = productsTable;

                   
                    dgvProducts.Columns["product_ID"].HeaderText = "Product ID";
                    dgvProducts.Columns["product_name"].HeaderText = "Product Name";
                    dgvProducts.Columns["price"].HeaderText = "Price";
                    dgvProducts.Columns["stock"].HeaderText = "Stock"; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

             
                tbProductID.Text = row.Cells["product_ID"].Value.ToString();
                tbProductName.Text = row.Cells["product_name"].Value.ToString();
                tbPrice.Text = row.Cells["price"].Value.ToString();
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrWhiteSpace(tbProductID.Text) || nudQuantity.Value <= 0)
            {
                MessageBox.Show("Please select a product and enter a valid quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productID = tbProductID.Text;
            string productName = tbProductName.Text;
            decimal price = decimal.Parse(tbPrice.Text);
            int quantity = (int)nudQuantity.Value;


            try
            {
                using (OleDbConnection tempConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;"))
                {
                    tempConnection.Open();

                    
                    string stockQuery = "SELECT stock FROM products WHERE product_ID = @productID";
                    OleDbCommand stockCmd = new OleDbCommand(stockQuery, tempConnection);
                    stockCmd.Parameters.AddWithValue("@productID", productID);

                    
                    object result = stockCmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        int currentStock = 0;

                        
                        if (int.TryParse(result.ToString(), out currentStock))
                        {
                            if (currentStock < quantity)
                            {
                                // If stock is insufficient
                                MessageBox.Show($"The selected quantity exceeds the available stock. Only {currentStock} items are available.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid stock information in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                       
                        MessageBox.Show("Product not found or stock information is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            decimal total = price * quantity;


            orderTable.Rows.Add(productID, productName, price, quantity, total, 0);


            UpdateTotalPrice();
        }

        private void btnRemoveOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrderList.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvOrderList.SelectedRows)
                {
                    dgvOrderList.Rows.Remove(row);
                }
                UpdateTotalPrice();
            }
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            orderTable.Rows.Clear();
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            totalPrice = 0;
            foreach (DataRow row in orderTable.Rows)
            {
                totalPrice += Convert.ToDecimal(row["Total"]);
            }
            tbTotalPrice.Text = totalPrice.ToString("0.00");
        }

        private decimal GetAmountPaid()
        {
            if (string.IsNullOrWhiteSpace(tbAmountPaid.Text))
            {
                throw new ArgumentException("Payment amount cannot be empty.");
            }

            try
            {
                decimal amountPaid = Convert.ToDecimal(tbAmountPaid.Text);


                if (amountPaid <= 0)
                {
                    throw new ArgumentException("Payment amount must be greater than zero.");
                }

                return amountPaid;
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid payment amount. Please enter a numeric value.");
            }
        }


        private void tbAmountPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tbAmountPaid.Text))
                {
                    // Attempt to convert the input to a decimal
                    decimal amountPaid = Convert.ToDecimal(tbAmountPaid.Text);
                    decimal change = amountPaid - totalPrice;

                    // Update the change textbox
                    tbChange.Text = change.ToString("0.00");
                }
                else
                {
                    // Clear the change textbox if input is empty
                    tbChange.Clear();
                }
            }
            catch (FormatException)
            {
                // Handle non-numeric input
                tbChange.Clear();
                MessageBox.Show("Please enter a valid numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbAmountPaid.Clear(); // Optional: Clear invalid input
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            // Ensure payment amount is entered
            if (string.IsNullOrWhiteSpace(tbAmountPaid.Text))
            {
                MessageBox.Show("Please enter the payment amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure an order type is selected in the ComboBox
            if (cbOrderType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an order type (e.g., Dine In or Take Out).", "Order Type Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Retrieve payment amount and order type
                decimal amountPaid = Convert.ToDecimal(tbAmountPaid.Text);
                decimal totalAmount = totalPrice;
                string orderType = cbOrderType.SelectedItem.ToString();

                if (amountPaid < totalAmount)
                {
                    MessageBox.Show("Insufficient payment amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal change = amountPaid - totalAmount;

                connection.Open();

                // Insert into Customer table
                string insertCustomerQuery = "INSERT INTO Customer (DateOrdered, TotalPrice, AmountPaid, Change, OrderType) VALUES (@DateOrdered, @TotalPrice, @AmountPaid, @Change, @OrderType)";
                OleDbCommand cmdCustomer = new OleDbCommand(insertCustomerQuery, connection);

                cmdCustomer.Parameters.Add("@DateOrdered", OleDbType.Date).Value = DateTime.Now;
                cmdCustomer.Parameters.Add("@TotalPrice", OleDbType.Currency).Value = totalAmount;
                cmdCustomer.Parameters.Add("@AmountPaid", OleDbType.Currency).Value = amountPaid;
                cmdCustomer.Parameters.Add("@Change", OleDbType.Currency).Value = change;
                cmdCustomer.Parameters.Add("@OrderType", OleDbType.VarChar).Value = orderType;

                // Execute the query
                cmdCustomer.ExecuteNonQuery();

                // Get the generated CustomerID
                OleDbCommand cmdGetCustomerID = new OleDbCommand("SELECT @@IDENTITY", connection);
                int customerID = Convert.ToInt32(cmdGetCustomerID.ExecuteScalar());

                // Insert order details into Orders table and update stock
                foreach (DataRow row in orderTable.Rows)
                {
                    string productName = row["Product Name"].ToString();
                    int productID = Convert.ToInt32(row["Product ID"]);
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    decimal price = Convert.ToDecimal(row["Price"]);
                    decimal total = Convert.ToDecimal(row["Total"]);

                    string insertOrderQuery = "INSERT INTO Orders (CustomerID, product_ID, product_name, OrderDate, quantity, price, TotalPrice) VALUES (@CustomerID, @ProductID, @ProductName, @OrderDate, @Quantity, @Price, @TotalPrice)";
                    OleDbCommand cmdOrder = new OleDbCommand(insertOrderQuery, connection);

                    cmdOrder.Parameters.Add("@CustomerID", OleDbType.Integer).Value = customerID;
                    cmdOrder.Parameters.Add("@ProductID", OleDbType.Integer).Value = productID;
                    cmdOrder.Parameters.Add("@ProductName", OleDbType.VarChar).Value = productName;
                    cmdOrder.Parameters.Add("@OrderDate", OleDbType.Date).Value = DateTime.Now;
                    cmdOrder.Parameters.Add("@Quantity", OleDbType.Integer).Value = quantity;
                    cmdOrder.Parameters.Add("@Price", OleDbType.Currency).Value = price;
                    cmdOrder.Parameters.Add("@TotalPrice", OleDbType.Currency).Value = total;

                    cmdOrder.ExecuteNonQuery();

                    string updateStockQuery = "UPDATE products SET stock = stock - @Quantity WHERE product_ID = @ProductID";
                    OleDbCommand cmdUpdateStock = new OleDbCommand(updateStockQuery, connection);

                    cmdUpdateStock.Parameters.Add("@Quantity", OleDbType.Integer).Value = quantity;
                    cmdUpdateStock.Parameters.Add("@ProductID", OleDbType.Integer).Value = productID;

                    cmdUpdateStock.ExecuteNonQuery();
                }

                tbChange.Text = change.ToString("0.00");
                MessageBox.Show($"Order completed successfully! Change: {change:C}\nOrder Type: {orderType}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset UI
                orderTable.Rows.Clear();
                UpdateTotalPrice();
                tbAmountPaid.Clear();
                tbChange.Clear();
                cbOrderType.SelectedIndex = -1; // Reset ComboBox selection
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing the payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.BeginPrint += new PrintEventHandler(printDocument1_BeginPrint);

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            StaffForm StaffForm = new StaffForm(userId);
            StaffForm.Show();
            this.Hide();
        }

        private void StaffOrder_Load_1(object sender, EventArgs e)
        {
            LoadCategories();
        }

        public class OrderItem
        {
            public string ItemName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal Total => Quantity * Price;  // Calculate total price for each item
        }

        // List to hold the ordered items
        List<OrderItem> orderItems = new List<OrderItem>();

        private void PopulateOrderItems()
        {
            orderItems.Clear(); // Clear existing items

            foreach (DataGridViewRow row in dgvOrderList.Rows)
            {
                if (row.IsNewRow) continue;

                string productName = row.Cells["Product Name"].Value?.ToString() ?? "";
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value ?? 0.0m);

                orderItems.Add(new OrderItem()
                {
                    ItemName = productName,
                    Quantity = quantity,
                    Price = price
                });
            }

            // Assuming CustomerID is displayed somewhere
            string customerID = tbCustomerID.Text.Trim(); // Optional: Display or use this if needed

            // Trigger receipt printing
            PrintReceipt(customerID);
        }

        private void PrintReceipt(string customerID)
        {
            try
            {
                // Prepare the receipt for printing
                printDocument1.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing receipt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // Define fonts and brushes
            Font headerFont = new Font("Arial", 20, FontStyle.Bold); // Reduced header font size
            Font subHeaderFont = new Font("Arial", 16, FontStyle.Bold); // Reduced subheader font size
            Font regularFont = new Font("Arial", 14); // Slightly smaller regular font
            Font smallFont = new Font("Arial", 12); // Smaller for separators
            Font footerFont = new Font("Arial", 14, FontStyle.Italic); // Footer font slightly smaller
            Font boldFooterFont = new Font("Arial", 14, FontStyle.Bold); // Bold footer font slightly smaller
            Brush brush = Brushes.Black;

            // Get page dimensions
            float pageWidth = e.PageBounds.Width;
            float pageHeight = e.PageBounds.Height;

            // Calculate the center position for the header and footer
            float headerCenterX = pageWidth / 2;
            float footerCenterX = pageWidth / 2;

            // Define positions
            float yPos = 20;
            float lineHeight = regularFont.GetHeight(g);
            float headerLineHeight = headerFont.GetHeight(g);

            // Receipt Header (Centered)
            g.DrawString("Citang's Eatery", headerFont, brush, headerCenterX - (g.MeasureString("Citang's Eatery", headerFont).Width / 2), yPos); // Centered title
            yPos += headerLineHeight;

            g.DrawString("Your Friendly Neighborhood Eatery since 1970", smallFont, brush, headerCenterX - (g.MeasureString("Your Friendly Neighborhood Eatery", smallFont).Width / 2), yPos);
            yPos += lineHeight;

            g.DrawString("=====================================================================", regularFont, brush, 10, yPos);
            yPos += lineHeight;

            // Subheader
            g.DrawString("Order Details", subHeaderFont, brush, 10, yPos);
            yPos += lineHeight + 5;

            g.DrawString("=====================================================================", regularFont, brush, 10, yPos);
            yPos += lineHeight;

            // Order Items
            foreach (DataRow row in orderTable.Rows)
            {
                // Ensure Product Name exists
                string productName = row["Product Name"] != DBNull.Value ? row["Product Name"].ToString() : "Unknown Product";

                // Convert Quantity
                if (row["Quantity"] == DBNull.Value)
                {
                    MessageBox.Show($"Quantity is missing for product: {productName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int quantity = Convert.ToInt32(row["Quantity"]);

                // Convert Price
                if (row["Price"] == DBNull.Value)
                {
                    MessageBox.Show($"Price is missing for product: {productName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal price = Convert.ToDecimal(row["Price"]);

                // Convert Total
                if (row["Total"] == DBNull.Value)
                {
                    MessageBox.Show($"Total is missing for product: {productName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal totalPrice = Convert.ToDecimal(row["Total"]);

                // Item Details
                g.DrawString($"Product: {productName}", regularFont, brush, 10, yPos);
                yPos += lineHeight;

                g.DrawString($"  Quantity: {quantity}", regularFont, brush, 10, yPos);
                yPos += lineHeight;

                g.DrawString($"  Price: ₱{price:0.00}   Subtotal: ₱{totalPrice:0.00}", regularFont, brush, 10, yPos);
                yPos += lineHeight + 5;

                g.DrawString("-----------------------------------------", smallFont, brush, 10, yPos);
                yPos += lineHeight;
            }


            // Summary
            decimal totalOrderPrice = Convert.ToDecimal(orderTable.Compute("SUM(Total)", ""));
            decimal amountPaid = Convert.ToDecimal(tbAmountPaid.Text);
            decimal changeGiven = Convert.ToDecimal(tbChange.Text);

            g.DrawString($"TOTAL: ₱{totalOrderPrice:0.00}", subHeaderFont, brush, 10, yPos);
            yPos += lineHeight;

            g.DrawString($"Amount Paid: ₱{amountPaid:0.00}", regularFont, brush, 10, yPos);
            yPos += lineHeight;

            g.DrawString($"Change: ₱{changeGiven:0.00}", regularFont, brush, 10, yPos);
            yPos += lineHeight + 15;

            // Footer (Centered)
            g.DrawString("Thank you for dining with us!", subHeaderFont, brush, footerCenterX - (g.MeasureString("Thank you for dining with us!", subHeaderFont).Width / 2), yPos);
            yPos += lineHeight + 10;

            g.DrawString("=====================================================================", regularFont, brush, 10, yPos);
            yPos += lineHeight;

            g.DrawString("Located at:", footerFont, brush, footerCenterX - (g.MeasureString("Located at:", footerFont).Width / 2), yPos);
            yPos += lineHeight;
            g.DrawString("620 Kuatro Kantos, Sta. Isabel (Bagong Bayan),", boldFooterFont, brush, footerCenterX - (g.MeasureString("620 Kuatro Kantos, Sta. Isabel (Bagong Bayan),", boldFooterFont).Width / 2), yPos);
            yPos += lineHeight;
            g.DrawString("City of Malolos, Bulacan", boldFooterFont, brush, footerCenterX - (g.MeasureString("City of Malolos, Bulacan", boldFooterFont).Width / 2), yPos);
            yPos += lineHeight;

            g.DrawString("Contact Us:", footerFont, brush, footerCenterX - (g.MeasureString("Contact Us:", footerFont).Width / 2), yPos);
            yPos += lineHeight;
            g.DrawString("0955 518 8181", boldFooterFont, brush, footerCenterX - (g.MeasureString("0955 518 8181", boldFooterFont).Width / 2), yPos);
            yPos += lineHeight;

            g.DrawString("Have a great day!", boldFooterFont, brush, footerCenterX - (g.MeasureString("Have a great day!", boldFooterFont).Width / 2), yPos);
        }

        private void dgvOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                // Get the product details from the selected row
                tbProductID.Text = row.Cells["product_ID"].Value.ToString();
                tbProductName.Text = row.Cells["product_name"].Value.ToString();
                tbPrice.Text = row.Cells["price"].Value.ToString();

                // Retrieve and display the current stock of the selected product
                string productID = tbProductID.Text;
                DisplayCurrentStock(productID);
            }*/
        }


        private void tbProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {

        }
        private int rowIndex = 0;

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rowIndex = 0;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            // Confirm logout
            if (MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Format DateTime.Now to remove milliseconds
                string formattedTimeOut = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Initialize the connection if it's not already initialized
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open(); // Open the connection
                }

                try
                {
                    // Update LogTable with TimeOut
                    string updateLogQuery = "UPDATE LogTable SET TimeOut = @timeOut WHERE ID = @userId AND TimeOut IS NULL";
                    OleDbCommand updateCmd = new OleDbCommand(updateLogQuery, connection);
                    updateCmd.Parameters.AddWithValue("@timeOut", formattedTimeOut);
                    updateCmd.Parameters.AddWithValue("@userId", userId);
                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Logout Successful.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during logout: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close(); // Close the connection after the update
                }

                // Load the login form and hide the current form
                loginForm form1 = new loginForm(); // Assuming loginForm is the form where the user logs in
                form1.Show();
                this.Hide(); // Hide the current form (StaffOrder form)
            }
        }
    }
    }
    

