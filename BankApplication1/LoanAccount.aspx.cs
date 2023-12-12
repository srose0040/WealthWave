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
            // I ADDED THIS BECOS I GOT EXCEPTION THRWN WHEN I RUN THE PROGRAM SO INCASE IF ANYONE RUNS IT FROM THIS PAGE IT AUTOMATICALLY TAKES THEM TO LOGIN PAGE 
            // THE RESEAN IS THAT CUSTOMER ID WILL BE NULL ONLY IF USER NOT LOGGED IN SO WE NEED THEM TO LOGIN
            if (Session["CustomerId"] != null)
            {
                userID = (int)Session["CustomerId"];



                if (!IsPostBack)
                {
                    Session["LoanAmount"] = 0.00; // Initialization to remove exceptions
                }
                userID = (int)Session["CustomerId"];

                // Create an instance of the Loan Account class
                loanAccount = new WealthWave.LoanAccount();

                // Retrieve user balance from the database
                double currentBalance = GetBalanceFromDatabase(userID);

                // Initialize the SavingsAccount instance with the retrieved balance
                loanAccount.CurrentBalance = currentBalance;

                balanceTextBox.Text = loanAccount.CurrentBalance.ToString(); // Displaying balance 
            }
            else
            {
                // Redirect to the login page BCOS THE CUSTOMER ID WILL BE NULL ONLY IF USER NOT LOGGED IN SO WE NEED THEM TO LOGIN
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
                querystr = "";
                querystr = "SELECT LoanAccountBalance FROM bankapplication.customer WHERE CustomerId='" + userID.ToString() + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows & reader.Read())
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

        //protected void TransactionButton_Click(object sender, EventArgs e)
        //{
        //    if (depositRadioButton.Checked)
        //    {
        //        double depositAmount = Convert.ToDouble(amountTextBox.Text);

        //        //Initialize the Account instance with the retrieved balance
        //        loanAccount.CurrentBalance = customerBalance;
        //        loanAccount.LoanAmount = (double)Session["LoanAmount"];

        //        //// Perform deposit transaction
        //        string message;
        //        loanAccount.DepositTransaction(depositAmount, out message);

        //        Session["LoanAmount"] = loanAccount.LoanAmount;

        //        // Present message to user
        //        ShowMessage.Text = message;

        //        //// Update the database with the new balance
        //        UpdateBalanceInDatabase(userID, loanAccount.CurrentBalance);
        //    }
        //    else if (withdrawRadioButton.Checked)
        //    {

        //        double depositAmount = Convert.ToDouble(amountTextBox.Text);

        //        //Initialize the SavingsAccount instance with the retrieved balance
        //        loanAccount.CurrentBalance = customerBalance;
        //        loanAccount.LoanAmount = (double)Session["LoanAmount"];

        //        // Apply for loan
        //        string message;
        //        loanAccount.ApplyForLoan(depositAmount, out message);
        //        Session["LoanAmount"] = loanAccount.LoanAmount;

        //        // Present message to user
        //        ShowMessage.Text = message;

        //        //// Perform deposit transaction
        //        message = "";
        //        loanAccount.WithdrawTransaction(depositAmount, out message);

        //        // Present message to user
        //        ShowMessage.Text = message;


        //        //// Update the database with the new balance
        //        UpdateBalanceInDatabase(userID, loanAccount.CurrentBalance);
        //    }
        //}

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
                double depositAmount = Convert.ToDouble(amountTextBox.Text);

                // Initialize the Account instance with the retrieved balance
                loanAccount.CurrentBalance = customerBalance;
                loanAccount.LoanAmount = (double)Session["LoanAmount"];

                if (depositRadioButton.Checked)
                {
                    // Perform deposit transaction
                    string message;
                    loanAccount.DepositTransaction(depositAmount, out message);

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
                    loanAccount.ApplyForLoan(depositAmount, out message);
                    Session["LoanAmount"] = loanAccount.LoanAmount;

                    // Present message to user
                    ShowMessage.Text = message;

                    // Perform deposit transaction
                    message = "";
                    loanAccount.WithdrawTransaction(depositAmount, out message);

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
            querystr = "";
            querystr = "UPDATE Customer SET LoanAccountBalance ='" + currentBalance + "' WHERE CustomerId='" + userID.ToString() + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
            cmd.ExecuteReader();
            conn.Close();

            Session["LoanAccountBalance"] = currentBalance;

            balanceTextBox.Text = loanAccount.CurrentBalance.ToString(); // Current balance updated (might be good to let user know interest applied on every deposit)
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