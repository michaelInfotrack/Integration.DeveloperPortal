using System.Linq;
using Integration.DeveloperPortal.Logic.Enums;
using Integration.DeveloperPortal.Logic.Interfaces;
using Integration.DeveloperPortal.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Integration.DeveloperPortal.Pages
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public ProviderConfigurationModel ProviderConfigurationModel { get; set; }
        private IProviderConfigurationLogic _providerConfigurationLogic;

        public AddModel(IProviderConfigurationLogic providerConfigurationLogic)
        {
            _providerConfigurationLogic = providerConfigurationLogic;
        }

        public void OnGet()
        {
            ViewData.Add("ContentType",
                ValueCollections.ContentType.Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x
                }).ToList()
            );
        }

        public IActionResult OnPostSaveAsync()
        {
            _providerConfigurationLogic.AddNewProviderConfiguration(ProviderConfigurationModel);
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Index");
        }
    }
}
