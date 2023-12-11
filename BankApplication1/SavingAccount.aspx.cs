using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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
        }

        // Method to retrieve user balance from the database
        private double GetBalanceFromDatabase(int userId)
        {
            double balance = 0.0;

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
                Session["CustomerBalance"] = balance;
                customerBalance = balance;
       
            }
            reader.Close();
            conn.Close();
                     

            return balance;
        }


        protected void TransactionButton_Click(object sender, EventArgs e)
        {
            double depositAmount = Convert.ToDouble(amountTextBox.Text);

            //Initialize the SavingsAccount instance with the retrieved balance
            savingsAccount.CurrentBalance = customerBalance;

            //// Perform deposit transaction
            string message;
            savingsAccount.DepositTransaction(depositAmount, out message);
            // MESSAGE MUST BE PRESENTED TO USER

            //// Update the database with the new balance
            UpdateBalanceInDatabase(userID, savingsAccount.CurrentBalance);
        }

        // Method to retrieve user balance from the database
        private double UpdateBalanceInDatabase(int userId, double currentBalance)
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
                Session["CustomerBalance"] = balance;
                customerBalance = balance;

            }
            reader.Close();
            conn.Close();


            return balance;
        }
    }
}