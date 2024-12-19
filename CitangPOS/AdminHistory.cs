using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitangPOS
{
    public partial class AdminHistory : Form
    {
        private OleDbConnection connection;
        OleDbDataAdapter adapter;
        DataTable dt; 
        private int userId;

        public AdminHistory()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;");
        }



        private void InitializeDatabaseConnection()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";
            connection = new OleDbConnection(connectionString);
            
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            LoadSalesReport();
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            PrintSalesReport();
        }

        private void LoadSalesReport()
        {
            try
            {
                connection.Open();

               
                DateTime endDate = DateTime.Today;
                DateTime startDate = endDate.AddDays(-6); 

         
                string query = $@"
                    SELECT 
                        OrderDate,
                        product_name,
                        SUM(quantity) AS QuantitySold,
                        price,
                        SUM(TotalPrice) AS TotalPrices
                    FROM 
                        Orders
                    WHERE 
                        OrderDate >= #{startDate:yyyy-MM-dd}# AND OrderDate <= #{endDate:yyyy-MM-dd}#
                    GROUP BY 
                        OrderDate, product_name, price
                    ORDER BY 
                        OrderDate ASC;";

                OleDbCommand cmd = new OleDbCommand(query, connection);

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable reportTable = new DataTable();
                adapter.Fill(reportTable);

                // Bind to DataGridView
                dgvSalesReport.DataSource = reportTable;

                if (reportTable.Rows.Count == 0)
                {
                    MessageBox.Show("No sales data found for the past week.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void PrintSalesReport()
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);

                PrintPreviewDialog printPreview = new PrintPreviewDialog
                {
                    Document = printDoc,
                    Width = 800,
                    Height = 600
                };

                printPreview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error printing sales report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            
            int x = 50; 
            int y = 50; 
            int lineHeight = 20; 
            int orderDateColumnWidth = 120; 
            int productNameColumnWidth = 250; 
            int quantityColumnWidth = 120; 
            int priceColumnWidth = 100; 
            int totalPriceColumnWidth = 120; 

            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font rowFont = new Font("Arial", 10);
            Brush textBrush = Brushes.Black;

            // Print header
            e.Graphics.DrawString("Weekly Sales Report", new Font("Arial", 16, FontStyle.Bold), textBrush, x, y);
            y += lineHeight * 2;

           
            string[] headers = { "Order Date", "Product Name", "Quantity Sold", "Price", "Total Price" };
            e.Graphics.DrawString(headers[0], headerFont, textBrush, x, y); // Order Date
            e.Graphics.DrawString(headers[1], headerFont, textBrush, x + orderDateColumnWidth, y); // Product Name
            e.Graphics.DrawString(headers[2], headerFont, textBrush, x + orderDateColumnWidth + productNameColumnWidth, y); // Quantity Sold
            e.Graphics.DrawString(headers[3], headerFont, textBrush, x + orderDateColumnWidth + productNameColumnWidth + quantityColumnWidth, y); // Price
            e.Graphics.DrawString(headers[4], headerFont, textBrush, x + orderDateColumnWidth + productNameColumnWidth + quantityColumnWidth + priceColumnWidth, y); // Total Price
            y += lineHeight; // Move to the next row for data

            // Print rows from DataGridView
            foreach (DataGridViewRow row in dgvSalesReport.Rows)
            {
                if (row.IsNewRow) continue; // Skip the new row

                // Get and format the Order Date (exclude the time part)
                string orderDate = row.Cells["OrderDate"].Value != null ? Convert.ToDateTime(row.Cells["OrderDate"].Value).ToString("yyyy-MM-dd") : string.Empty;
                string productName = row.Cells["product_name"].Value?.ToString();
                string quantitySold = row.Cells["QuantitySold"].Value?.ToString();
                string price = row.Cells["price"].Value?.ToString();
                string totalPrice = row.Cells["TotalPrices"].Value?.ToString();

                // Print each column value
                e.Graphics.DrawString(orderDate, rowFont, textBrush, x, y); // Order Date
                e.Graphics.DrawString(productName, rowFont, textBrush, x + orderDateColumnWidth, y); // Product Name
                e.Graphics.DrawString(quantitySold, rowFont, textBrush, x + orderDateColumnWidth + productNameColumnWidth, y); // Quantity Sold
                e.Graphics.DrawString(price, rowFont, textBrush, x + orderDateColumnWidth + productNameColumnWidth + quantityColumnWidth, y); // Price
                e.Graphics.DrawString(totalPrice, rowFont, textBrush, x + orderDateColumnWidth + productNameColumnWidth + quantityColumnWidth + priceColumnWidth, y); // Total Price

                y += lineHeight; // Move to the next row
            }

            // Optionally add a footer for total summary or end of report
            y += lineHeight;
            e.Graphics.DrawString("End of Weekly Sales Report", headerFont, textBrush, x, y);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            AdminForm AdminForm = new AdminForm(userId);
            AdminForm.Show();

            this.Hide();
        }

        private void AdminHistory_Load(object sender, EventArgs e)
        {
            
        }
        
    }
}
