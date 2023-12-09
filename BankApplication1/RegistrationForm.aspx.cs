﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication1
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
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
            else
            {
                // GET ALL INFO FROM THE TEXTBOX THEN 
                // CONNECT TO DATABASE AND UPDATE CREDENTIALS
                // Redirect to the next page 
                Response.Redirect("HomePage.aspx");
            }

            
        }

        private void registerUser()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);

            conn.Open();

            querystr = "";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);

            cmd.ExecuteReader();

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


    }
}