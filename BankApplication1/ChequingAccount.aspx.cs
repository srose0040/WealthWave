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
        String name;
        WealthWave.ChequingAccount chequingAccount;
        protected void Page_Load(object sender, EventArgs e)
        {
            userID = (int)Session["CustomerId"];

            // Create an instance of the Chequing Account class
            chequingAccount = new WealthWave.ChequingAccount();

            // Retrieve user balance from the database
            double currentBalance = GetBalanceFromDatabase(userID);

            // Initialize the SavingsAccount instance with the retrieved balance
            chequingAccount.CurrentBalance = currentBalance;

            balanceTextBox.Text = chequingAccount.CurrentBalance.ToString(); // Displaying balance (might be good to let user know interest applied on every deposit)
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
                querystr = "SELECT CurrentBalance FROM bankapplication.customer WHERE CustomerId='" + userID.ToString() + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
                reader = cmd.ExecuteReader();
                while (reader.HasRows & reader.Read())
                {
                    balance = reader.GetDouble(reader.GetOrdinal("CurrentBalance"));
                    Session["ChequingAccountBalance"] = balance;
                    customerBalance = balance;

                }
                reader.Close();
                conn.Close();
            }
            else
            {
                balance = (double)Session["ChequingAccountBalance"];
            }
           


            return balance;
        }

        protected void TransactionButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TransactionsHistory.aspx");
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