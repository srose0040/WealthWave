using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace BankApplication1
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String querystr;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string dateOfBirth = DateOfBirth.Text;
            if (!IsValidDate(dateOfBirth))
            {
                
                // display an error message to the user
                Response.Write("<script>alert('You must be born before January 1st, 2009 to register for a bank account.');</script>");
            }


            if (string.IsNullOrEmpty(firstName.Text.Trim()))
            {
                ShowErrorMessage.Text = "First Name is required.";
                return;
            }

            if (string.IsNullOrEmpty(lastName.Text.Trim()))
            {
                ShowErrorMessage.Text = "Last Name is required.";
                return;
            }

            if (string.IsNullOrEmpty(email.Text.Trim()))
            {
                ShowErrorMessage.Text = "Email is required.";
                return;
            }

            // validation for email format
            if (!IsValidEmail(email.Text.Trim()))
            {
                ShowErrorMessage.Text = "Invalid Email Address.";
                return;
            }

            if (string.IsNullOrEmpty(phone.Text.Trim()))
            {
                ShowErrorMessage.Text = "Phone Number is required.";
                return;
            }

            // Additional validation for phone number - digits only
            if (!IsDigitsOnly(phone.Text.Trim()))
            {
                ShowErrorMessage.Text = "Phone Number must contain only digits.";
                return;
            }

            if (string.IsNullOrEmpty(sinNumber.Text.Trim()))
            {
                ShowErrorMessage.Text = "SinNumber is required.";
                return;
            }

            // Additional validation for SIN number - digits only
            if (!IsDigitsOnly(sinNumber.Text.Trim()))
            {
                ShowErrorMessage.Text = "SinNumber must contain only digits.";
                return;
            }
            else
            {
                // GET ALL INFO FROM THE TEXTBOX THEN 
                // CONNECT TO DATABASE AND UPDATE CREDENTIALS
                // Redirect to the next page 
                registerUser(); // Adds user to SQL Database
                Response.Redirect("HomePage.aspx");
            }

            
        }

        private void registerUser() // This method connects to SQL database and puts users info in the Customer table
        {
            double defaultBalance = 0.0;

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);

            conn.Open();

            querystr = "";
            // INPUT VALIDATION MUST BE DONE TO PREVENT SQL INJECTION
            querystr = "INSERT INTO BankApplication.Customer (FirstName, LastName, Email, PhoneNumber, Sex, MaritialStatus, CountryStatus, Address, DateOfBirth, sinNumber, Username, Password, SavingAccountBalance, ChequingAccountBalance, LoanAccountBalance)" +
                "VALUES('" + firstName.Text + "','" + lastName.Text + "','" + email.Text + "','" + phone.Text + "','" + sex.Text + "','" + MaritialStatus.Text + "','" + CountryStatus.Text + "','" + Address.Text + "','" + DateOfBirth.Text + "','" + sinNumber.Text + "','" + username.Text + "','" + password.Text + "','"  + defaultBalance + "','" + defaultBalance + "','" + defaultBalance + "')";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);


            cmd.ExecuteReader();
            conn.Close();

            conn.Open();
            querystr = "";
            querystr = "SELECT CustomerId FROM bankapplication.customer WHERE username='" + username.Text + "' AND password='" + password.Text + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);

            reader = cmd.ExecuteReader();
            while (reader.HasRows & reader.Read())
            {
                int customerId = reader.GetInt32(reader.GetOrdinal("CustomerID"));
                Session["CustomerId"] = customerId;

            }

            conn.Close();
        }



        public bool IsValidDate(string dateString)
        {
            DateTime tempDate;
            bool isDate = DateTime.TryParse(dateString, out tempDate);

            if (isDate)
            {
                DateTime cutOffDate = new DateTime(2009, 1, 1); // January 1 2009
                if (tempDate > cutOffDate)
                {
                    return false;
                }
                else
                {
                    return true;
                }

               // return tempDate < cutOffDate;
            }
            else
            {
                return false;
            }
        }

        private bool IsDigitsOnly(string str)
        {
            // Check if a string contains only digits
            return !string.IsNullOrEmpty(str) && str.All(char.IsDigit);
        }

        private bool IsValidEmail(string email)
        {
            
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }



    }
}