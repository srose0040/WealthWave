using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using WealthWave;

namespace BankApplication1
{
    public partial class ChequingAccount : System.Web.UI.Page
    {
        int userID;
        double customerBalance;
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        string querystr;
        WealthWave.ChequingAccount chequingAccount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerId"] != null)
            {
                userID = (int)Session["CustomerId"];

                // Create an instance of the Chequing Account class
                chequingAccount = new WealthWave.ChequingAccount();

                // Retrieve user balance from the database
                double currentBalance = GetBalanceFromDatabase(userID);

                // Initialize the ChequingAccount instance with the retrieved balance
                chequingAccount.CurrentBalance = currentBalance;

                balanceTextBox.Text = chequingAccount.CurrentBalance.ToString(); // Displaying balance 
            }
            else
            {
                // Redirect to the login page if the customer ID is null
                Response.Redirect("~/LoginPage.aspx");
            }
        }

        // Method to retrieve user balance from the database
        private double GetBalanceFromDatabase(int userId)
        {
            double balance = 0.0;

            if (Session["ChequingAccountBalance"] == null)
            {
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
                querystr = "SELECT ChequingAccountBalance FROM bankapplication.customer WHERE CustomerId='" + userID.ToString() + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows && reader.Read())
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
            if (string.IsNullOrEmpty(amountTextBox.Text))
            {
                // Display a reminder message to enter the amount
                ShowMessage.Text = "Please enter the transaction amount.";
                return;
            }

            try
            {
                double transactionAmount = Convert.ToDouble(amountTextBox.Text);
                chequingAccount.CurrentBalance = customerBalance;

                if (depositRadioButton.Checked)
                {
                    // Perform deposit transaction
                    string message;
                    chequingAccount.DepositTransaction(transactionAmount, out message);
                    ShowMessage.Text = message;
                }
                else if (withdrawRadioButton.Checked)
                {
                    // Perform withdraw transaction
                    string message;
                    chequingAccount.WithdrawTransaction(transactionAmount, out message);
                    ShowMessage.Text = message;
                }

                // Update the database with the new balance
                UpdateBalanceInDatabase(userID, chequingAccount.CurrentBalance);
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
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            querystr = "UPDATE Customer SET ChequingAccountBalance ='" + currentBalance + "' WHERE CustomerId='" + userID.ToString() + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
            cmd.ExecuteReader();
            conn.Close();

            Session["ChequingAccountBalance"] = currentBalance;

            balanceTextBox.Text = chequingAccount.CurrentBalance.ToString(); // Current balance updated
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
