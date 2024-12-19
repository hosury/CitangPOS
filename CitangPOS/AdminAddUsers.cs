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
    public partial class AdminAddUsers : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt;
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb";
        private int userId;

        public AdminAddUsers()
        {
            InitializeComponent();
            LoadUserData();
            cbRole.Items.AddRange(new[] { "Staff", "Admin" });
        }

        void LoadUserData()
        {
            using (conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM useracc";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvUsers.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrEmpty(tbPass.Text) || cbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    
                    string query = "INSERT INTO useracc ([username], [password], [role]) VALUES (@username, @password, @role)";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@username", tbUsername.Text.Trim());
                        command.Parameters.AddWithValue("@password", tbPass.Text.Trim());
                        command.Parameters.AddWithValue("@role", cbRole.SelectedItem.ToString());

                       
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                btnClear_Click(null, null);
                LoadUserData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(tbUsername.Text) ||    // Username
                string.IsNullOrWhiteSpace(tbPass.Text) ||        // Password
                cbRole.SelectedIndex == -1)                     // Role
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            string query = "UPDATE useracc SET [username]=@username, [password]=@password, [role]=@role WHERE [ID]=@id";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;"))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@username", tbUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", tbPass.Text.Trim());
                        cmd.Parameters.AddWithValue("@role", cbRole.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(tbUserID.Text.Trim()));

                        
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Show a success or failure message
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Please ensure the ID is correct.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Refresh the DataGridView and clear the form
                LoadUserData();
                btnClear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgvUsers.SelectedRows.Count > 0)
            {
                // Get the username of the selected row
                string username = dgvUsers.SelectedRows[0].Cells["username"].Value.ToString();

                // Show confirmation message box
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to remove the user '{username}'?",
                    "Confirm Removal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            connection.Open();

                            
                            string query = "DELETE FROM useracc WHERE username = @username";

                            using (OleDbCommand command = new OleDbCommand(query, connection))
                            {
                                // Add parameter for username
                                command.Parameters.AddWithValue("@username", username);

                                // Execute the query to delete the user
                                command.ExecuteNonQuery();
                            }
                        }

                        // Refresh the DataGridView after removing the user
                        LoadUserData();

                        MessageBox.Show("User removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error removing user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("User removal canceled.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to remove.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUsername.Clear();
            tbPass.Clear();
            cbRole.SelectedIndex = -1; // Deselect the ComboBox
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                
                tbUserID.Text = row.Cells["ID"].Value.ToString(); 
                tbUsername.Text = row.Cells["username"].Value.ToString();
                tbPass.Text = row.Cells["password"].Value.ToString();
                cbRole.Text = row.Cells["role"].Value.ToString();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            AdminForm AdminForm = new AdminForm(userId);
            AdminForm.Show();

            this.Hide();
        }
    }
 }
    

    

