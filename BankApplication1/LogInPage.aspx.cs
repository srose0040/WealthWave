using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication1
{
    public partial class LogInPage : System.Web.UI.Page
    {
        //MySql.Data.MySqlClient.MySqlConnection conn;
        //MySql.Data.MySqlClient.MySqlCommand cmd;
        //MySql.Data.MySqlClient.MySqlDataReader reader;
        String querystr;
        String name;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

            //conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            //conn.Open();
            //querystr = "";
            //querystr = "SELECT * FROM bankapplication.customer WHERE username='" + username.Text + "' AND password='" + password.Text + "'";
            //cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);

            //reader = cmd.ExecuteReader();
            //name = "";
            //while (reader.HasRows & reader.Read())
            //{
            //    name += reader.GetString(reader.GetOrdinal("FirstName")) + " " + reader.GetString(reader.GetOrdinal("LastName"));
            //}

            //if (reader.HasRows)
            //{
            //    Session["UserName"] = name;

            //    // VALIDATE DATABASE CREDENTIALS
            //    // Redirect to the next page 
            //    Response.BufferOutput = true;
            //    Response.Redirect("HomePage.aspx", false);
            //}
            //else
            //{
            //    // display an error message to the user
            //    Response.Write("<script>alert('Invalid User.');</script>");
            //}

            //reader.Close();
            //conn.Close();

           
        }

    }
}