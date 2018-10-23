using Integration.DeveloperPortal.Logic.Enums;
using Integration.DeveloperPortal.Logic.Interfaces;
using Integration.DeveloperPortal.Logic.Models;
using Integration.DeveloperPortal.Model;
using Integration.DeveloperPortal.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Integration.DeveloperPortal.Logic
{
    public class ProviderConfigurationLogic : IProviderConfigurationLogic
    {
        private readonly IProviderConfigurationRepository _providerConfigurationRepository;

        public ProviderConfigurationLogic(IProviderConfigurationRepository providerConfigurationRepository)
        {
            _providerConfigurationRepository = providerConfigurationRepository;
        }

        public IEnumerable<ProviderConfigurationModel> GetAllEnabledProviderConfigurations()
        {
            return _providerConfigurationRepository.GetAllEnabledConfigurations().Select(x => MapToModel(x));
        }

        public ProviderConfigurationModel GetProviderConfiguration(int providerConfigurationId)
        {
            var providerConfiguration = _providerConfigurationRepository.GetConfiguration(providerConfigurationId);
            return MapToModel(providerConfiguration);
        }

        public void UpdateProviderConfiguration(ProviderConfigurationModel providerConfigurationModel)
        {
            var providerConfiguration = MapToEntity(providerConfigurationModel);
            _providerConfigurationRepository.UpdateConfiguration(providerConfiguration);
        }

        public void AddNewProviderConfiguration(ProviderConfigurationModel providerConfigurationModel)
        {
            var providerConfiguration = MapToEntity(providerConfigurationModel);
            _providerConfigurationRepository.InsertNewConfiguration(providerConfiguration);
        }

        private ProviderConfiguration MapToEntity(ProviderConfigurationModel providerConfigurationModel)
        {
            return new ProviderConfiguration
            {
                RetailerReferencePrefix = providerConfigurationModel.RetailerReferencePrefix,
                AuthenticationMethod = providerConfigurationModel.AuthenticationMethod.ToString(),
                ContentType = providerConfigurationModel.ContentType,
                CountryRegion = providerConfigurationModel.CountryRegion.ToString(),
                Enabled = providerConfigurationModel.Enabled == ConfigurationStatus.Enabled ? 1 : 0,
                Endpoint = providerConfigurationModel.Endpoint,
                Environment = providerConfigurationModel.Environment.ToString(),
                Password = providerConfigurationModel.Password,
                RequestType = providerConfigurationModel.RequestType.ToString(),
                Resource = providerConfigurationModel.Resource,
                Username = providerConfigurationModel.Username
            };
        }

        private ProviderConfigurationModel MapToModel(ProviderConfiguration providerConfiguration)
        {
            return new ProviderConfigurationModel
            {
                ProviderConfigurationId = providerConfiguration.ProviderConfigurationId,
                RetailerReferencePrefix = providerConfiguration.RetailerReferencePrefix,
                AuthenticationMethod = (AuthenticationMethod)Enum.Parse(typeof(AuthenticationMethod), providerConfiguration.AuthenticationMethod),
                ContentType = providerConfiguration.ContentType,
                CountryRegion = (Country)Enum.Parse(typeof(Country), providerConfiguration.CountryRegion),
                Enabled = (ConfigurationStatus)providerConfiguration.Enabled,
                Endpoint = providerConfiguration.Endpoint,
                Environment = (ConfigurationEnvironment)Enum.Parse(typeof(ConfigurationEnvironment), providerConfiguration.Environment),
                Password = providerConfiguration.Password,
                RequestType = (RequestType)Enum.Parse(typeof(RequestType), providerConfiguration.RequestType),
                Resource = providerConfiguration.Resource,
                Username = providerConfiguration.Username
            };
        }
    }
}
