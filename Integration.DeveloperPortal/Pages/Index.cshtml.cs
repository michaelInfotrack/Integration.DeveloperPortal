using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.DeveloperPortal.Logic.Interfaces;
using Integration.DeveloperPortal.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Integration.DeveloperPortal.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IEnumerable<ProviderConfigurationModel> ProviderConfigurationModels { get; set; }
        private IProviderConfigurationLogic _providerConfigurationLogic;

        public IndexModel(IProviderConfigurationLogic providerConfigurationLogic)
        {
            _providerConfigurationLogic = providerConfigurationLogic;
        }

        public void OnGet()
        {
            ProviderConfigurationModels = _providerConfigurationLogic.GetAllEnabledProviderConfigurations();
        }
    }
}
