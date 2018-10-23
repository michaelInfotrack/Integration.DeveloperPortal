using Integration.DeveloperPortal.Logic;
using Integration.DeveloperPortal.Logic.Interfaces;
using Integration.DeveloperPortal.Repository;
using Integration.DeveloperPortal.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.DeveloperPortal.DependencyResolution
{
    public class Resolver
    {
        public void Resolve(IServiceCollection services)
        {
            services.AddScoped<IProviderConfigurationLogic, ProviderConfigurationLogic>();
            services.AddScoped<IProviderConfigurationRepository, ProviderConfigurationRepository>();
        }
    }
}
