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
    public partial class AdminAddCategory : Form
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";
        private OleDbConnection conn;
        private OleDbCommand cmd;
        private int userId;

        public AdminAddCategory()
        {
            InitializeComponent();
            LoadCategoryData();
        }
        private void LoadCategoryData()
        {
            using (conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM category";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvCats.DataSource = dataTable;

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void tbCatID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddCat_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(tbCat.Text))
            {
                MessageBox.Show("Database Path: " + connectionString, "Debug");

                MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                
                using (conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    
                    string query = "INSERT INTO category (category) VALUES (@category)";

                    using (cmd = new OleDbCommand(query, conn))
                    {
                       
                        cmd.Parameters.AddWithValue("@category", tbCat.Text.Trim());

                        
                        cmd.ExecuteNonQuery();
                    }
                }

                
                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                LoadCategoryData();
                btnClearCat_Click(null, null);
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Error adding category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateCat_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(tbCat.Text))
            {
                MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (string.IsNullOrWhiteSpace(tbCatID.Text))
            {
                MessageBox.Show("Please select a category to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string query = "UPDATE category SET category=@category WHERE id=@id";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;"))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@category", tbCat.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(tbCatID.Text.Trim()));

                        
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Please ensure the category ID is correct.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                
                LoadCategoryData();
                btnClearCat_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveCat_Click(object sender, EventArgs e)
        {
           
            if (dgvCats.SelectedRows.Count > 0)
            {
                
                int categoryId = Convert.ToInt32(dgvCats.SelectedRows[0].Cells["id"].Value);

                
                DialogResult result = MessageBox.Show("Are you sure you want to remove this category?",
                                                      "Confirm Removal",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (conn = new OleDbConnection(connectionString))
                        {
                            conn.Open();

                           
                            string query = "DELETE FROM category WHERE id = @id";

                            using (cmd = new OleDbCommand(query, conn))
                            {
                                
                                cmd.Parameters.AddWithValue("@id", categoryId);

                                
                                cmd.ExecuteNonQuery();
                            }
                        }

                        
                        LoadCategoryData();

                        MessageBox.Show("Category removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error removing category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    
                    MessageBox.Show("Category removal cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a category to remove.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearCat_Click(object sender, EventArgs e)
        {
            tbCatID.Clear();
            tbCat.Clear();
        }



        private void dgvCats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
               
                DataGridViewRow row = dgvCats.Rows[e.RowIndex];

                
                tbCatID.Text = row.Cells["id"].Value.ToString();
                tbCat.Text = row.Cells["category"].Value.ToString();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm(userId);
            adminForm.Show();
            this.Hide();
        }

        private void tbCat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
