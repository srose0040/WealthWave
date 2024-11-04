using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


namespace BankApplication1
{
    public partial class LogInPage : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String querystr;
        String name;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // This method is called when the login button is clicked.
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // Retrieve the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["WebAppConnString"].ConnectionString;


            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // Define the SQL query to check the username and password
                querystr = "SELECT * FROM db_aa9c1a_bankapp.customer WHERE username=@username AND Password1=@Password";

                // Create a MySqlCommand object with parameters
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username.Text);
                    cmd.Parameters.AddWithValue("@Password", Password1.Text);
                    // Execute the query and read the result
                    using (MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            // Store user information in session variables
                            int customerId = reader.GetInt32(reader.GetOrdinal("CustomerId"));
                            Session["CustomerId"] = customerId;

                            // Retrieve all columns
                            string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                            string lastName = reader.GetString(reader.GetOrdinal("LastName"));
                            string sex = reader.GetString(reader.GetOrdinal("Sex"));
                            string maritalStatus = reader.GetString(reader.GetOrdinal("MaritialStatus"));
                            string countryStatus = reader.GetString(reader.GetOrdinal("CountryStatus"));
                            string address = reader.GetString(reader.GetOrdinal("Address"));
                            string phoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                            DateTime dateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth"));
                            string password = reader.GetString(reader.GetOrdinal("Password1"));
                            string usernameValue = reader.GetString(reader.GetOrdinal("Username"));
                            double currentBalance = reader.GetDouble(reader.GetOrdinal("CurrentBalance"));
                            string email = reader.GetString(reader.GetOrdinal("Email"));
                            int sinNumber = reader.GetInt32(reader.GetOrdinal("SinNumber"));

                            // Store user details in session
                            Session["UserName"] = $"{firstName} {lastName}";
                            Session["UserDetails"] = new UserDetails
                            {
                                CustomerId = customerId,
                                FirstName = firstName,
                                LastName = lastName,
                                Sex = sex,
                                MaritalStatus = maritalStatus,
                                CountryStatus = countryStatus,
                                Address = address,
                                PhoneNumber = phoneNumber,
                                DateOfBirth = dateOfBirth,
                                Password = password,
                                Username = usernameValue,
                                CurrentBalance = currentBalance,
                                Email = email,
                                SinNumber = sinNumber
                            };
                            // Redirect to the home page
                            Response.BufferOutput = true;
                            Response.Redirect("HomePage.aspx", false);
                        }
                        else
                        {
                            // Display an error message to the user
                            Response.Write("<script>alert('Invalid User.');</script>");
                        }
                    }
                }
            }
        }


    }
}


