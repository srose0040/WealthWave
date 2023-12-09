using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication1
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PasswordButton_Click(object sender, EventArgs e)
        {
            // GET ALL INFO FROM THE TEXTBOX THEN 
            // CONNECT TO DATABASE AND UPDATE CREDENTIALS
            // Redirect to the next page 
            Response.Redirect("HomePage.aspx");
        }
    }
}