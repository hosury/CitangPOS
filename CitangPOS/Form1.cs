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
    public partial class loginForm : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;

        private int userId;
        private string userRole;

        private int loginAttempts = 0;

        public loginForm()
        {
            InitializeComponent();
        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {

            conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=CitangPOS.accdb");


            string query = "SELECT [role], ID FROM useracc WHERE UCase(username) = UCase(@username) AND [password] = @password";


            cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", login_username.Text);
            cmd.Parameters.AddWithValue("@password", login_password.Text);

            try
            {
                conn.Open();


                OleDbDataReader reader = cmd.ExecuteReader();

                // Check if we found a user
                if (reader.Read()) // If a record is found
                {
                    string userType = reader["role"].ToString();  // Retrieve role
                    int userId = Convert.ToInt32(reader["ID"]);   // Retrieve user ID


                    string formattedTimeIn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string insertLogQuery = "INSERT INTO LogTable (ID, TimeIn) VALUES (@userId, @timeIn)";
                    OleDbCommand insertCmd = new OleDbCommand(insertLogQuery, conn);
                    insertCmd.Parameters.AddWithValue("@userId", userId);
                    insertCmd.Parameters.AddWithValue("@timeIn", formattedTimeIn);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Login Successful");


                    this.Hide();
                    if (userType == "Admin")
                    {
                        AdminForm adminForm = new AdminForm(userId);
                        adminForm.Show();
                    }
                    else if (userType == "Staff")
                    {
                        StaffOrder staffOrderForm = new StaffOrder(userId);
                        staffOrderForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Unrecognized user type.");
                        this.Show();
                    }
                }
                else
                {
                    loginAttempts++;
                    MessageBox.Show("Invalid username or password.");

                    if (loginAttempts >= 3)
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void registerhere_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void login_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
