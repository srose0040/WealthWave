using System.ComponentModel.DataAnnotations;

namespace BankApplication.Pages.Shared
{
    public class RegisterModelView
    {
        // User Information
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        // Additional User Information ..we can add username, password, confirm password stufff


        // Optional Information
        public string Phone { get; set; }

        // Terms and Conditions
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the terms and conditions.")]
        public bool AgreeToTerms { get; set; }

        public RegisterModelView()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            AgreeToTerms = false;
        }
    }
}
