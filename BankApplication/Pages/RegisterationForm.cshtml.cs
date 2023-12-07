using BankApplication.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankApplication.Pages
{
    public class RegisterationFormModel: PageModel
    {
        [BindProperty]
        public RegisterModelView Registeration { get; set; }


        public RegisterationFormModel()
        {
            // Initialize the Login property in the constructor
            Registeration = new RegisterModelView();

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
                // Process the registration (save to database, send confirmation email, etc.)

                // For example, redirect to a confirmation page
                return RedirectToPage("/RegistrationConfirmation");
            }

            // If ModelState is not valid, redisplay the form with validation errors
            return Page();
        }
    }
}


