using System.Linq;
using Integration.DeveloperPortal.Logic.Enums;
using Integration.DeveloperPortal.Logic.Interfaces;
using Integration.DeveloperPortal.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Integration.DeveloperPortal.Pages.Configuration
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public ProviderConfigurationModel ProviderConfigurationModel { get; set; }

        private IProviderConfigurationLogic _providerConfigurationLogic;

        public EditModel(IProviderConfigurationLogic providerConfigurationLogic)
        {
            _providerConfigurationLogic = providerConfigurationLogic;
        }

        public void OnGet(int id)
        {
            ProviderConfigurationModel = _providerConfigurationLogic.GetProviderConfiguration(id);

            ViewData.Add("ContentType", 
                ValueCollections.ContentType.Select(x => new SelectListItem {
                    Text = x,
                    Value = x
                }).ToList()
            );
        }

        public IActionResult OnPostSaveAsync()
        {
            _providerConfigurationLogic.UpdateProviderConfiguration(ProviderConfigurationModel);
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostCancel()
        {
           return RedirectToPage("/Index");
        }
    }
}
