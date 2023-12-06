using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankApplication.Pages
{
    public class LoginPageModel : PageModel
    {
        public LoginViewModel Login { get; set; }

        public LoginPageModel()
        {
            // Initialize the Login property in the constructor
            Login = new LoginViewModel();
        }

        public void OnGet()
        {
            // Initialization logic when the page is loaded
        }

        public IActionResult OnPost()
        {
            // Handling form submission logic
            if (ModelState.IsValid)
            {
                // Authenticate user or perform other actions
                return RedirectToPage("/Index");
            }

            // If ModelState is not valid, redisplay the form with validation errors
            return Page();
        }
    }


}

