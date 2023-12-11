using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        String name;
        WealthWave.LoanAccount loanAccount;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}