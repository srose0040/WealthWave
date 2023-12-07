using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApplication.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly IUserService _userService;

        public ProfileModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string FirstName { get; set; }

        // Add other properties for editable fields

        public void OnGet()
        {
            // Load the user's information when the page is accessed
            // Example: UserProfile userProfile = _userService.GetUserProfile(User.Identity.Name);
            // Map user data to the model properties
            // Load the user's information when the page is accessed
            UserProfile userProfile = _userService.GetUserProfile(User.Identity.Name);
            // Map user data to the model properties
            FirstName = userProfile.FirstName;
            // Map other properties
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If the form has validation errors, redisplay the form
                return Page();
            }

            // Update the user's information
            // Example: _userService.UpdateUserProfile(User.Identity.Name, FirstName, ...);

            // Redirect the user back to the profile page
            return RedirectToPage("/Profile");
        }
    }
}
