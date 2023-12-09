using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Images and whatever should go in here
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // Redirect to the next page 
            Response.Redirect("LogInPage.aspx");
        }
    }
}