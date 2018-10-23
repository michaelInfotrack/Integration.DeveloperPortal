using Integration.DeveloperPortal.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.DeveloperPortal.Logic.Interfaces
{
    public interface IProviderConfigurationLogic
    {
        IEnumerable<ProviderConfigurationModel> GetAllEnabledProviderConfigurations();
        ProviderConfigurationModel GetProviderConfiguration(int providerConfigurationId);
        void UpdateProviderConfiguration(ProviderConfigurationModel providerConfigurationModel);
        void AddNewProviderConfiguration(ProviderConfigurationModel providerConfigurationModel);
    }
}
