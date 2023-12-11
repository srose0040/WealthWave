using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WealthWave;

namespace BankApplication1
{
    public partial class SavingAccount : System.Web.UI.Page
    {
        // Get the user's ID or username after authentication
        int userID;
        double customerBalance;
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String querystr;
        String name;
        SavingsAccount savingsAccount;

        protected void Page_Load(object sender, EventArgs e)
        {
            userID = (int)Session["CustomerId"];

            // Create an instance of the SavingsAccount class
            savingsAccount = new SavingsAccount();

            // Retrieve user balance from the database
            double currentBalance = GetBalanceFromDatabase(userID);

            // Initialize the SavingsAccount instance with the retrieved balance
            savingsAccount.CurrentBalance = currentBalance;


            balanceTextBox.Text = savingsAccount.CurrentBalance.ToString(); // Displaying balance (might be good to let user know interest applied on every deposit)

        }

        // Method to retrieve user balance from the database
        private double GetBalanceFromDatabase(int userId)
        {
            double balance = 0.0;

            if (Session["SavingAccountBalance"] == null)
            {
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
                querystr = "";
                querystr = "SELECT CurrentBalance FROM bankapplication.customer WHERE CustomerId='" + userID.ToString() + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows & reader.Read())
                {
                    balance = reader.GetDouble(reader.GetOrdinal("CurrentBalance"));
                    Session["SavingAccountBalance"] = balance;
                    customerBalance = balance;

                }
                reader.Close();
                conn.Close();
            }
            else
            {
                balance = (double)Session["SavingAccountBalance"];
            }

            
                     

            return balance;
        }


        protected void TransactionButton_Click(object sender, EventArgs e)
        {
            if (depositRadioButton.Checked)
            {
                double depositAmount = Convert.ToDouble(amountTextBox.Text);

                //Initialize the SavingsAccount instance with the retrieved balance
                savingsAccount.CurrentBalance = customerBalance;

                //// Perform deposit transaction
                string message;
                savingsAccount.DepositTransaction(depositAmount, out message);

                // Present message to user
                ShowMessage.Text = message;

                //// Update the database with the new balance
                UpdateBalanceInDatabase(userID, savingsAccount.CurrentBalance);
            }
            else if (withdrawRadioButton.Checked)
            {
                double depositAmount = Convert.ToDouble(amountTextBox.Text);

                //Initialize the SavingsAccount instance with the retrieved balance
                savingsAccount.CurrentBalance = customerBalance;

                //// Perform deposit transaction
                string message;
                savingsAccount.WithdrawTransaction(depositAmount, out message);

                // Present message to user
                ShowMessage.Text = message;
                

                //// Update the database with the new balance
                UpdateBalanceInDatabase(userID, savingsAccount.CurrentBalance);
            }
           
        }

        // Method to set balance in database
        private void UpdateBalanceInDatabase(int userId, double currentBalance)
        {

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            querystr = "";
            querystr = "UPDATE Customer SET CurrentBalance ='" + currentBalance + "' WHERE CustomerId='" + userID.ToString() + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
            cmd.ExecuteReader();
            conn.Close();

            Session["SavingAccountBalance"] = currentBalance;

            balanceTextBox.Text = savingsAccount.CurrentBalance.ToString(); // Current balance updated (might be good to let user know interest applied on every deposit)
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