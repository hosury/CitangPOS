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

namespace CitangPOS
{
    public partial class AdminDashboard : Form
    {
        private int userId;

        public AdminDashboard()
        {
            InitializeComponent();
        }

        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";

        private void LoadTotalUsers()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();


                    string query = "SELECT COUNT(*) FROM useracc";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {

                        object result = cmd.ExecuteScalar();
                        int userCount = result != DBNull.Value ? Convert.ToInt32(result) : 0;


                        lblTotalUsers.Text = $"{userCount}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user count: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalUsers.Text = "Error loading users";
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            AdminForm AdminForm = new AdminForm(userId);
            AdminForm.Show();

            this.Hide();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadTotalUsers();
            UpdateCustomerCount(); // Update the customer count
            UpdateTodaysIncome(); // Update today's income
            UpdateTotalIncome();   // Update total income
            LoadTodaysCustomers();
        }

        private void lblCustomers_Click(object sender, EventArgs e)
        {
           
        }

        private void UpdateCustomerCount()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Query to count all customers in the Customer table
                    string query = "SELECT COUNT(*) FROM Customer";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Execute the query and retrieve the result
                        object result = cmd.ExecuteScalar();

                        // Check the result and update the label
                        if (result != null)
                        {
                            int customerCount = Convert.ToInt32(result);
                            
                            lblCustomers.Text = $"{customerCount}"; // Update label
                        }
                        else
                        {
                            MessageBox.Show("Debug: Result is null!", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lblCustomers.Text = "Total Customers: 0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer count: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblCustomers.Text = "Error loading customers";
            }
        }

        private void UpdateTodaysIncome()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Define the start and end of today's date
                    DateTime todayStart = DateTime.Today; // Midnight of today
                    DateTime todayEnd = todayStart.AddDays(1); // Midnight of the next day

                    // Query to sum today's transactions based on the date range
                    string query = "SELECT SUM(TotalPrice) FROM Orders WHERE OrderDate >= @todayStart AND OrderDate < @todayEnd";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Add parameters for today's start and end date
                        cmd.Parameters.AddWithValue("@todayStart", todayStart);
                        cmd.Parameters.AddWithValue("@todayEnd", todayEnd);

                        // Execute the query and retrieve the result
                        object result = cmd.ExecuteScalar();

                        // If the result is not null, update the label
                        if (result != null && result != DBNull.Value)
                        {
                            decimal todaysIncome = Convert.ToDecimal(result);
                            lblTodaysIncome.Text = $"₱{todaysIncome:C}"; // Update label with formatted income
                        }
                        else
                        {
                            lblTodaysIncome.Text = "₱0.00";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading today's income: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTodaysIncome.Text = "Error loading income";
            }
        }

        private void UpdateTotalIncome()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();


                    string query = "SELECT SUM(TotalPrice) FROM Orders";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Execute the query and retrieve the result
                        object result = cmd.ExecuteScalar();

                        // If the result is not null, update the label
                        if (result != null && result != DBNull.Value)
                        {
                            decimal totalIncome = Convert.ToDecimal(result);
                            lblTotalIncome.Text = $"₱{totalIncome:C}"; // Update label with formatted total income
                        }
                        else
                        {
                            lblTotalIncome.Text = "₱0.00";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading total income: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalIncome.Text = "Error loading income";
            }
        }

        private OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;");

        private void LoadTodaysCustomers()
        {
            try
            {

                string query = "SELECT * FROM Customer WHERE DateOrdered >= @today AND DateOrdered < @tomorrow ORDER BY DateOrdered";

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {

                    DateTime todayStart = DateTime.Today;
                    DateTime tomorrowStart = todayStart.AddDays(1);

                    adapter.SelectCommand.Parameters.AddWithValue("@today", todayStart);
                    adapter.SelectCommand.Parameters.AddWithValue("@tomorrow", tomorrowStart);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Debugging: Check if any rows are returned
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No customers found for today.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dgvAllCustomers.DataSource = dt; // Bind the result to the DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
