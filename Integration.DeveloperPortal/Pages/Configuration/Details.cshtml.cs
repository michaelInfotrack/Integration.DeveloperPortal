using Integration.DeveloperPortal.Logic.Interfaces;
using Integration.DeveloperPortal.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Integration.DeveloperPortal.Pages.Configuration
{
    public class DetailsModel : PageModel
    {

        [BindProperty]
        public ProviderConfigurationModel ProviderConfigurationModel { get; set; }

        private IProviderConfigurationLogic _providerConfigurationLogic;

        public DetailsModel(IProviderConfigurationLogic providerConfigurationLogic)
        {
            _providerConfigurationLogic = providerConfigurationLogic;
        }

        public void OnGet(int id)
        {
            ProviderConfigurationModel = _providerConfigurationLogic.GetProviderConfiguration(id);
        }
    }
}