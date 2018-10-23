using Integration.DeveloperPortal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.DeveloperPortal.Repository.Interfaces
{
    public interface IProviderConfigurationRepository
    {
        List<ProviderConfiguration> GetAllEnabledConfigurations();
        List<ProviderConfiguration> GetAllConfigurations();
        ProviderConfiguration GetConfiguration(int providerConfigurationId);
        void UpdateConfiguration(ProviderConfiguration providerConfiguration);
        void InsertNewConfiguration(ProviderConfiguration providerConfiguration);
     }
}
