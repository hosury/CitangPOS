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
    public partial class AdminCustomer : Form
    {

        OleDbConnection conn;
       
        OleDbDataAdapter adapter;
        DataTable dt;
        private int userId;

        public AdminCustomer()
        {
            InitializeComponent();
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;");
        }

        private OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CitangPOS.accdb;");

        private void LoadAllCustomers()
        {
            try
            {
                string query = "SELECT * FROM Customer ORDER BY DateOrdered";
                adapter = new OleDbDataAdapter(query, conn);
                dt = new DataTable();
                adapter.Fill(dt);

                dgvAllCustomers.DataSource = dt; // Bind the customer data to dgvAllCustomers
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminCustomer_Load(object sender, EventArgs e)
        {
            LoadAllCustomers();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            AdminForm AdminForm = new AdminForm(userId);
            AdminForm.Show();

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
    }
}
