using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication1
{
    public partial class TermsAndConditions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AgreeButton_Click(object sender, EventArgs e)
        {
            // Redirect the user to another page
            Response.Redirect("RegistrationForm.aspx");
        }
    }
}