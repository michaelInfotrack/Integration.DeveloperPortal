using Integration.DeveloperPortal.Authentication;
using Integration.DeveloperPortal.Authentication.Interfaces;
using Integration.DeveloperPortal.Logic;
using Integration.DeveloperPortal.Logic.Interfaces;
using Integration.DeveloperPortal.Logic.Services;
using Integration.DeveloperPortal.Repository;
using Integration.DeveloperPortal.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.DeveloperPortal.DependencyResolution
{
    public class Resolver
    {
        public void Resolve(IServiceCollection services)
        {
            services.AddScoped<IProviderConfigurationLogic, ProviderConfigurationService>();
            services.AddScoped<IProviderConfigurationRepository, ProviderConfigurationRepository>();
            services.AddScoped<ILdapService, LdapService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
