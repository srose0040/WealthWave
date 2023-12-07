using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankApplication.Pages
{
    public class SettingAndPrivacyModel : PageModel
    {
        private readonly ILogger<SettingAndPrivacyModel> _logger;

        public SettingAndPrivacyModel(ILogger<SettingAndPrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
