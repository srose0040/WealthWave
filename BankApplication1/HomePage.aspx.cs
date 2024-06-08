using BankApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication1
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve user details from the session
            UserDetails userDetails = (UserDetails)Session["UserDetails"];
            if (userDetails != null)
            {
<<<<<<< HEAD
              
                lblFirstName.Text = userDetails.FirstName;
                lblLastName.Text = userDetails.LastName;

                // Display the welcome message with a new line
                WelcomeLabel.Text = $"Welcome to WealthWave Bank, {userDetails.FirstName} {userDetails.LastName}!{Environment.NewLine}We are here to provide you with the best banking service.";
                
                btnLogout.Click += LogoutButton_Click;
            }
=======

                lblFirstName.Text = userDetails.FirstName;
                lblLastName.Text = userDetails.LastName;

                // Display the welcome message
                WelcomeLabel.Text = $"Welcome to WealthWave Bank, {userDetails.FirstName} {userDetails.LastName}! We are here to provide you with the best banking service.";


                // Set the image URL using a relative path
                string relativePath = "Images/image9.png";
                image9.ImageUrl = relativePath;


                btnLogout.Click += LogoutButton_Click;
            }
            else
            {

                // Set the image URL using a relative path
                string relativePath = "Images/image9.png";
                image9.ImageUrl = relativePath;
            }
>>>>>>> ffac5bf8acbeee7fa07991c6cfa003738767045d
        }
        protected void AccountDetails_Click(object sender, EventArgs e)
        {
            // redirect user into account details page 
            Response.Redirect("AccountDetails.aspx");
        }

        // This method is called when the user clicks a logout button or takes some other action to log out
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            // Log the user out
            FormsAuthentication.SignOut();
            Session.Abandon(); // Optional: Abandon the session

            // Redirect to the login page or any other desired page
            Response.Redirect("~/LoginPage.aspx");
        }
    }
}

