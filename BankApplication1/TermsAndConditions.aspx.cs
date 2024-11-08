using System;
using System.Web.UI;

namespace BankApplication1
{
    public partial class TermsAndConditions : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void AgreeButton_Click(object sender, EventArgs e)
        {
            
            // Set a session variable to track that the user agreed to the terms
            Session["TermsAccepted"] = true;

            //redirecting the back to register page
            Response.Redirect("RegistrationForm.aspx"); 
        }
    }
}
