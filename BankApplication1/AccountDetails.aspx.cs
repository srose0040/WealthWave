using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication1
{
    public partial class AccountDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve user details from the session
            UserDetails userDetails = (UserDetails)Session["UserDetails"];
            if (userDetails != null)
            {
                // Display user details in labels
                MainContent_lblCustomerId.Text =  userDetails.CustomerId.ToString();
                lblFirstName.Text =  userDetails.FirstName;
                lblLastName.Text =  userDetails.LastName;
                lblDateOfBirth.Text =  userDetails.DateOfBirth.ToString("yyyy-MM-dd");
                lblSex.Text = userDetails.Sex;
                lblPhoneNumber.Text = userDetails.PhoneNumber;
                lblAddress.Text = userDetails.Address;
                lblCurrentBalance.Text = userDetails.CurrentBalance.ToString("C");
                lblEmail.Text = userDetails.Email;

                // Display account holder name and additional information in the label
                lblAccountHolder.Text = $"Detail Account Information of {userDetails.FirstName} {userDetails.LastName}";
            }
            else
            {
                // Redirect to the login page if userDetails is null
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}