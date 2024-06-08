using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WealthWave;

namespace BankApplication1
{
    public partial class LoanAccount : System.Web.UI.Page
    {
        int userID;
        double customerBalance;
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String querystr;
        WealthWave.LoanAccount loanAccount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerId"] != null)
            {
                // User is logged in, proceed with loading the page
                userID = (int)Session["CustomerId"];

                if (!IsPostBack)
                {
                    Session["LoanAmount"] = 0.00; // Initialization to remove exceptions
                }

                // Create an instance of the Loan Account class
                loanAccount = new WealthWave.LoanAccount();

                // Retrieve user balance from the database
                double currentBalance = GetBalanceFromDatabase(userID);

                // Initialize the LoanAccount instance with the retrieved balance
                loanAccount.CurrentBalance = currentBalance;

                balanceTextBox.Text = loanAccount.CurrentBalance.ToString(); // Displaying balance 
            }
            else
            {
                // Redirect to the login page because the customer ID will be null only if the user is not logged in
                Response.Redirect("~/LoginPage.aspx");
            }
        }

        // Method to retrieve user balance from the database
        private double GetBalanceFromDatabase(int userId)
        {
            double balance = 0.0;

            if (Session["LoanAccountBalance"] == null)
            {
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
                querystr = "SELECT LoanAccountBalance FROM bankapplication.customer WHERE CustomerId='" + userID.ToString() + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows && reader.Read())
                {
                    balance = reader.GetDouble(reader.GetOrdinal("LoanAccountBalance"));
                    Session["LoanAccountBalance"] = balance;
                    customerBalance = balance;
                }
                reader.Close();
                conn.Close();
            }
            else
            {
                balance = (double)Session["LoanAccountBalance"];
                customerBalance = balance;
            }

            return balance;
        }

        protected void TransactionButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(amountTextBox.Text))
            {
                // Display a reminder message to enter the amount
                ShowMessage.Text = "Please enter the transaction amount.";
                return; // Exit the method since the amount is not provided
            }

            try
            {
                double transactionAmount = Convert.ToDouble(amountTextBox.Text);

                // Initialize the LoanAccount instance with the retrieved balance
                loanAccount.CurrentBalance = customerBalance;
                loanAccount.LoanAmount = (double)Session["LoanAmount"];

                if (depositRadioButton.Checked)
                {
                    // Perform deposit transaction
                    string message;
                    loanAccount.DepositTransaction(transactionAmount, out message);

                    Session["LoanAmount"] = loanAccount.LoanAmount;

                    // Present message to user
                    ShowMessage.Text = message;

                    // Update the database with the new balance
                    UpdateBalanceInDatabase(userID, loanAccount.CurrentBalance);
                }
                else if (withdrawRadioButton.Checked)
                {
                    // Apply for loan
                    string message;
                    loanAccount.ApplyForLoan(transactionAmount, out message);
                    Session["LoanAmount"] = loanAccount.LoanAmount;

                    // Present message to user
                    ShowMessage.Text = message;

                    // Perform withdraw transaction
                    message = "";
                    loanAccount.WithdrawTransaction(transactionAmount, out message);

                    // Present message to user
                    ShowMessage.Text = message;

                    // Update the database with the new balance
                    UpdateBalanceInDatabase(userID, loanAccount.CurrentBalance);
                }
            }
            catch (FormatException)
            {
                // Display an error message to the user
                ShowMessage.Text = "Invalid input format for transaction amount.";
            }
        }

        // Method to set balance in database
        private void UpdateBalanceInDatabase(int userId, double currentBalance)
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            querystr = "UPDATE Customer SET LoanAccountBalance ='" + currentBalance + "' WHERE CustomerId='" + userID.ToString() + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
            cmd.ExecuteReader();
            conn.Close();

            Session["LoanAccountBalance"] = currentBalance;

            balanceTextBox.Text = loanAccount.CurrentBalance.ToString(); // Current balance updated
        }

        // This method is called when the user clicks a logout button or takes some other action to log out
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            // Log the user out
            FormsAuthentication.SignOut();
            Session.Abandon();

            // Redirect to the login page or any other desired page
            Response.Redirect("~/LoginPage.aspx");
        }
    }
}
