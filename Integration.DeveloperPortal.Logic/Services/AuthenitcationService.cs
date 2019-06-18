using Integration.DeveloperPortal.Authentication.Interfaces;
using Integration.DeveloperPortal.Authentication.Models;
using Integration.DeveloperPortal.Logic.Interfaces;

namespace Integration.DeveloperPortal.Logic.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private ILdapService _ldapService;

        public AuthenticationService(ILdapService ldapService)
        {
            _ldapService = ldapService;
        }

        public AppUser Login(string username, string password)
        {
            return _ldapService.Login(username, password);
        }
    }
}
