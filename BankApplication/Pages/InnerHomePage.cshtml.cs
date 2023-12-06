using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankApplication.Pages
{
    public class InnerHomePageModel : PageModel
    {
        [BindProperty]
        public InnerHomePageModelView ViewModel { get; set; }

        public void OnGet()
        {

            // Initialize or load data for the view model
            ViewModel = new InnerHomePageModelView
            {
                GreetingMessage = $"Welcome, {User.Identity.Name}!",
                UserAccountNumber = "123456789" // WE WILL CHANGE IT LATERRRR...
            };
        }
    }
}
