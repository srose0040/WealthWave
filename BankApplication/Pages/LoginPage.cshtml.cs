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
            // Check if the user clicked on the "Register" link
            if (HttpContext.Request.Query["registerClicked"] == "True")
            {
                // Redirect to the RegisterationForm page
                return RedirectToPage("/RegisterationForm");
            }

            // Handling form submission logic
            if (ModelState.IsValid)
            {
                // redirect users into inner page
                return RedirectToPage("/InnerHomePage");
            }

            // If ModelState is not valid, redisplay the form with validation errors
            return Page();
        }



    }


}

