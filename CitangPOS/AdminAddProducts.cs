using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitangPOS
{
    public partial class AdminAddProducts : Form
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";
        private OleDbConnection conn;
        private OleDbCommand cmd;
        private int userId;
        private OleDbDataAdapter adapter;
        private DataTable productTable;
        private bool isImageUploaded = false;

        public AdminAddProducts()
        {
            InitializeComponent();
            cbcat.DropDown += cbcat_DropDown;
            LoadProductData(); 
            this.Name = "AdminAddProducts";

        }
        private void cbcat_DropDown(object sender, EventArgs e)
        {
           
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";

            
            cbcat.Items.Clear();

            try
            {
               
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT category FROM category";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbcat.Items.Add(reader["category"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void AdminAddProducts_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            LoadCategories();
            LoadProductData();
        }

        private void LoadCategories()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT category FROM category";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            cbcat.Items.Clear();
                            while (reader.Read())
                            {
                                cbcat.Items.Add(reader["category"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadProductData()
        {
            string query = "SELECT product_id, product_name, category, price, stock, status, prod_image FROM Products";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    
                    dgvProducts.DataSource = dataTable;

                    
                    if (dgvProducts.Columns["image"] != null)
                    {
                        dgvProducts.Columns["image"].CellTemplate = new DataGridViewImageCell();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading product data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnprodadd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    using (conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();

                       
                        string query = "INSERT INTO products (product_name, category, price, stock, status, prod_image, produced_date, expiration_date) " +
               "VALUES (@productName, @category, @price, @stock, @status, @image, @producedDate, @expirationDate)";

                        using (cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@productName", tbprodname.Text.Trim());
                            cmd.Parameters.AddWithValue("@category", cbcat.SelectedItem?.ToString());
                            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(tbprice.Text.Trim()));
                            cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(tbstock.Text.Trim()));
                            cmd.Parameters.AddWithValue("@status", cbstatus.SelectedItem?.ToString());

                            
                            if (pbprod.Image != null)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    pbprod.Image.Save(ms, pbprod.Image.RawFormat);
                                    cmd.Parameters.AddWithValue("@image", ms.ToArray());
                                }
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@image", DBNull.Value);
                            }

                            
                            DateTime? producedDate = dtProducedDate.Value;
                            DateTime? expirationDate = dtExpirationDate.Value;
                            cmd.Parameters.AddWithValue("@producedDate", producedDate.HasValue ? (object)producedDate.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@expirationDate", expirationDate.HasValue ? (object)expirationDate.Value : DBNull.Value);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadProductData();
                            ClearForm();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnprodupdate_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    using (conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();

                        string query = "UPDATE products SET product_name=@productName, category=@category, price=@price, stock=@stock, " +
                                       "status=@status, prod_image=@image WHERE product_ID=@productID";
                        using (cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@productName", tbprodname.Text.Trim());
                            cmd.Parameters.AddWithValue("@category", cbcat.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(tbprice.Text.Trim()));
                            cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(tbstock.Text.Trim()));
                            cmd.Parameters.AddWithValue("@status", cbstatus.SelectedItem.ToString());

                            
                            if (pbprod.Image != null)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    pbprod.Image.Save(ms, pbprod.Image.RawFormat);
                                    cmd.Parameters.AddWithValue("@image", ms.ToArray());
                                }
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@image", DBNull.Value);
                            }

                            cmd.Parameters.AddWithValue("@productID", tbprodid.Text.Trim());

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadProductData();
                            ClearForm();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnprodremove_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbprodid.Text))
            {
                
                DialogResult result = MessageBox.Show("Are you sure you want to remove this product?",
                                                      "Confirm Deletion",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (conn = new OleDbConnection(connectionString))
                        {
                            conn.Open();

                            string query = "DELETE FROM products WHERE product_ID=@productID";
                            using (cmd = new OleDbCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@productID", tbprodid.Text.Trim());
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LoadProductData();
                                ClearForm();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Product deletion canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a Product ID to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnprodclear_Click(object sender, EventArgs e)
        {
            tbprodid.Clear();
            tbprodname.Clear();
            cbcat.SelectedIndex = -1;
            tbprice.Clear();
            tbstock.Clear();
            cbstatus.SelectedIndex = -1;
            pbprod.Image = null;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(tbprodname.Text) ||
             cbcat.SelectedIndex == -1 ||
             string.IsNullOrWhiteSpace(tbprice.Text) ||
             string.IsNullOrWhiteSpace(tbstock.Text) ||
             cbstatus.SelectedIndex == -1)

            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnprodimage_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                pbprod.Image = Image.FromFile(openFileDialog.FileName);
                isImageUploaded = true;
            }
        }

            private void ClearForm()
        {
            tbprodid.Clear(); 
            tbprodname.Clear();
            cbcat.SelectedIndex = -1;
            tbprice.Clear();
            tbstock.Clear();
            cbstatus.SelectedIndex = -1;
            pbprod.Image = null;
            isImageUploaded = false;

            // Reset DateTimePickers
            dtProducedDate.Value = DateTime.Now;
            dtProducedDate.CustomFormat = " ";
            dtExpirationDate.Value = DateTime.Now.AddDays(1);
            dtExpirationDate.CustomFormat = " ";
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm(userId);
            adminForm.Show();
            this.Hide();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
               
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                
                tbprodid.Text = row.Cells["product_id"].Value.ToString();
                tbprodname.Text = row.Cells["product_name"].Value.ToString();
                cbcat.SelectedItem = row.Cells["category"].Value.ToString(); 
                tbprice.Text = row.Cells["price"].Value.ToString();
                tbstock.Text = row.Cells["stock"].Value.ToString();
                cbstatus.SelectedItem = row.Cells["status"].Value.ToString();

                
                if (row.Cells["prod_image"].Value != DBNull.Value)
                {
                    byte[] imageData = (byte[])row.Cells["prod_image"].Value;
                    MemoryStream ms = new MemoryStream(imageData);
                    pbprod.Image = Image.FromStream(ms);
                    isImageUploaded = true;
                }
            }
        }

        private void cbcat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtProducedDate_ValueChanged(object sender, EventArgs e)
        {
            dtProducedDate.CustomFormat = "yyyy-MM-dd"; 

            // Ensure expiration date is not before the produced date
            if (dtExpirationDate.Value < dtProducedDate.Value)
            {
                dtExpirationDate.Value = dtProducedDate.Value.AddDays(1); // Set to the next day
            }
            dtExpirationDate.MinDate = dtProducedDate.Value.AddDays(1); // Update the minimum allowed expiration date
        }

        private void dtExpirationDate_ValueChanged(object sender, EventArgs e)
        {
            dtExpirationDate.CustomFormat = "yyyy-MM-dd"; 

            // Ensure expiration date is not before produced date
            if (dtExpirationDate.Value < dtProducedDate.Value.AddDays(1))
            {
                MessageBox.Show("Expiration date cannot be earlier than the day after the produced date.",
                                "Invalid Expiration Date",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                dtExpirationDate.Value = dtProducedDate.Value.AddDays(1);
            }
        }

        private void tbstock_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }
    

