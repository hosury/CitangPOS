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
    public partial class AdminForm : Form
    {
        private OleDbConnection conn;
        private int userId;

        public AdminForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;");
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

      

        private void UpdateCustomerCount()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();


                    string query = "SELECT COUNT(*) FROM Customer";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {

                        object result = cmd.ExecuteScalar();


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

                    DateTime todayStart = DateTime.Today;
                    DateTime todayEnd = todayStart.AddDays(1);

                    string query = "SELECT SUM(TotalPrice) FROM Orders WHERE OrderDate >= @todayStart AND OrderDate < @todayEnd";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@todayStart", todayStart);
                        cmd.Parameters.AddWithValue("@todayEnd", todayEnd);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            decimal todaysIncome = Convert.ToDecimal(result);
                            lblTodaysIncome.Text = $"₱{todaysIncome:N2}";
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

                    // Query to sum all transactions in the Orders table
                    string query = "SELECT SUM(TotalPrice) FROM Orders";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Execute the query and retrieve the result
                        object result = cmd.ExecuteScalar();

                        // If the result is not null, update the label
                        if (result != null && result != DBNull.Value)
                        {
                            decimal totalIncome = Convert.ToDecimal(result);
                            lblTotalIncome.Text = $"₱{totalIncome:N2}"; // Correct formatting
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
                    // Add parameter for today's date (start of today)
                    DateTime todayStart = DateTime.Today;
                    DateTime tomorrowStart = todayStart.AddDays(1); // Start of the next day

                    adapter.SelectCommand.Parameters.AddWithValue("@today", todayStart);
                    adapter.SelectCommand.Parameters.AddWithValue("@tomorrow", tomorrowStart);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Commented out the MessageBox for no customers found
                    // if (dt.Rows.Count == 0)
                    // {
                    //     MessageBox.Show("No customers found for today.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // }

                    dgvAllCustomers.DataSource = dt; // Bind the result to the DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Confirmation Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                string formattedTimeOut = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                conn.Open();
                string updateLogQuery = "UPDATE LogTable SET TimeOut = @timeOut WHERE ID = @userId AND TimeOut IS NULL";
                OleDbCommand updateCmd = new OleDbCommand(updateLogQuery, conn);
                updateCmd.Parameters.AddWithValue("@timeOut", formattedTimeOut);
                updateCmd.Parameters.AddWithValue("@userId", userId);
                updateCmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Logout Successful.");


                loginForm form1 = new loginForm();
                form1.Show();
                this.Hide();
            }
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadTotalUsers();
            UpdateCustomerCount(); // Update the customer count
            UpdateTodaysIncome(); // Update today's income
            UpdateTotalIncome();   // Update total income
            LoadTodaysCustomers();
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
           /* AdminDashboard AdminDashboard = new AdminDashboard();
            AdminDashboard.Show();

            this.Hide();*/
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            AdminAddUsers AdminAddUsers = new AdminAddUsers();
            AdminAddUsers.Show();

            this.Hide();
        }

        private void btnAddCateg_Click(object sender, EventArgs e)
        {
            AdminAddCategory AdminAddCategory = new AdminAddCategory();
            AdminAddCategory.Show();

            this.Hide();
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            AdminAddProducts AdminAddProducts = new AdminAddProducts();
            AdminAddProducts.Show();

            this.Hide();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            AdminCustomer AdminCustomer = new AdminCustomer();
            AdminCustomer.Show();

            this.Hide();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            AdminHistory AdminHistory = new AdminHistory();
            AdminHistory.Show();

            this.Hide();
        }
    }
    }

