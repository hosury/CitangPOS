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
    public partial class StaffForm : Form
    {
        private OleDbConnection conn;
        private int userId;

        public StaffForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;");
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {

        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            StaffOrder StaffOrder = new StaffOrder(userId);
            StaffOrder.Show();

            this.Hide();
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
            // Confirm logout
            if (MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Format DateTime.Now to remove milliseconds
                string formattedTimeOut = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                try
                {
                    // Check if userId is valid
                    if (string.IsNullOrEmpty(userId.ToString()))
                    {
                        MessageBox.Show("User ID is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM LogTable WHERE TimeOut IS NULL AND ID = @userId";
                    OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@userId", userId);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());


                    if (count == 0)
                    {
                        MessageBox.Show("This user has already logged out.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conn.Close(); 
                        return;
                    }


                    string updateLogQuery = "UPDATE LogTable SET TimeOut = @timeOut WHERE ID = @userId AND TimeOut IS NULL";
                    OleDbCommand updateCmd = new OleDbCommand(updateLogQuery, conn);
                    updateCmd.Parameters.AddWithValue("@timeOut", formattedTimeOut);
                    updateCmd.Parameters.AddWithValue("@userId", userId);
                    updateCmd.ExecuteNonQuery();
                    conn.Close();


                    MessageBox.Show("Logout Successful.");
                    Application.Exit();

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"An error occurred while logging out: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
