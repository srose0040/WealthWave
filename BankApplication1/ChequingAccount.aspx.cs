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
    public partial class ChequingAccount : System.Web.UI.Page
    {
        // Get the user's ID or username after authentication
        int userID;
        double customerBalance;
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String querystr;
        WealthWave.ChequingAccount chequingAccount;

        protected void Page_Load(object sender, EventArgs e)
        {
            // I ADDED THIS BECOS I GOT EXCEPTION THRWN WHEN I RUN THE PROGRAM SO INCASE IF ANYONE RUNS IT FROM THIS PAGE IT AUTOMATICALLY TAKES THEM TO LOGIN PAGE 
            // THE RESEAN IS THAT CUSTOMER ID WILL BE NULL ONLY IF USER NOT LOGGED IN SO WE NEED THEM TO LOGIN
            if (Session["CustomerId"] != null)
            {
                userID = (int)Session["CustomerId"];

                // Create an instance of the Chequing Account class
                chequingAccount = new WealthWave.ChequingAccount();

                // Retrieve user balance from the database
                double currentBalance = GetBalanceFromDatabase(userID);

                // Initialize the SavingsAccount instance with the retrieved balance
                chequingAccount.CurrentBalance = currentBalance;

                balanceTextBox.Text = chequingAccount.CurrentBalance.ToString(); // Displaying balance 
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

            if (Session["ChequingAccountBalance"] == null)
            {
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
                querystr = "";
                querystr = "SELECT ChequingAccountBalance FROM bankapplication.customer WHERE CustomerId='" + userID.ToString() + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows & reader.Read())
                {
                    balance = reader.GetDouble(reader.GetOrdinal("ChequingAccountBalance"));
                    Session["ChequingAccountBalance"] = balance;
                    customerBalance = balance;

                }
                reader.Close();
                conn.Close();
            }
            else
            {
                balance = (double)Session["ChequingAccountBalance"];
                customerBalance = balance;
            }



            return balance;
        }

        protected void TransactionButton_Click(object sender, EventArgs e)
        {
            if (depositRadioButton.Checked)
            {
                double depositAmount = Convert.ToDouble(amountTextBox.Text);

                //Initialize the Account instance with the retrieved balance
                chequingAccount.CurrentBalance = customerBalance;

                //// Perform deposit transaction
                string message;
                chequingAccount.DepositTransaction(depositAmount, out message);

                // Present message to user
                ShowMessage.Text = message;

                //// Update the database with the new balance
                UpdateBalanceInDatabase(userID, chequingAccount.CurrentBalance);
            }
            else if (withdrawRadioButton.Checked)
            {
                double depositAmount = Convert.ToDouble(amountTextBox.Text);

                //Initialize the SavingsAccount instance with the retrieved balance
                chequingAccount.CurrentBalance = customerBalance;

                //// Perform deposit transaction
                string message;
                chequingAccount.WithdrawTransaction(depositAmount, out message);

                // Present message to user
                ShowMessage.Text = message;


                //// Update the database with the new balance
                UpdateBalanceInDatabase(userID, chequingAccount.CurrentBalance);
            }
        }

        // Method to set balance in database
        private void UpdateBalanceInDatabase(int userId, double currentBalance)
        {

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            querystr = "";
            querystr = "UPDATE Customer SET ChequingAccountBalance ='" + currentBalance + "' WHERE CustomerId='" + userID.ToString() + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
            cmd.ExecuteReader();
            conn.Close();

            Session["ChequingAccountBalance"] = currentBalance;

            balanceTextBox.Text = chequingAccount.CurrentBalance.ToString(); // Current balance updated (might be good to let user know interest applied on every deposit)
        }


        // USE A DIFFERENT BUTTON FOR THIS
        //protected void TransactionButton_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/TransactionsHistory.aspx");
        //}

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