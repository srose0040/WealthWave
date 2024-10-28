using Org.BouncyCastle.Asn1.Ocsp;
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
            if (!IsPostBack)
            {
                // Store the previous page URL in a session variable
                Session["PreviousPageUrl"] = Request.RawUrl;


                // Load the content of your agreement dynamically
                string filePath = Server.MapPath("~/SettingAndPrivacy.pdf");

                // Check if there is a referrer
                if (Request.UrlReferrer != null)
                {
                    // Get the URL of the previous page
                    string previousPageUrl = Request.UrlReferrer.ToString();

                    // Store the previous page URL in a session variable (optional)
                    Session["PreviousPageUrl"] = previousPageUrl;
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }

                // Retrieve user details from the session
                UserDetails userDetails = (UserDetails)Session["UserDetails"];
                if (userDetails != null)
                {
                    // Display user details in labels
                    MainContent_lblCustomerId.Text = userDetails.CustomerId.ToString();
                    lblFirstName.Text = userDetails.FirstName;
                    lblLastName.Text = userDetails.LastName;
                    lblDateOfBirth.Text = userDetails.DateOfBirth.ToString("yyyy-MM-dd");
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


        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            // Check if the previous page URL is available in the session
            if (Session["PreviousPageUrl"] != null)
            {
                // Redirect the user back to the previous page
                Response.Redirect(Session["PreviousPageUrl"].ToString());
            }
            else
            {
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}


