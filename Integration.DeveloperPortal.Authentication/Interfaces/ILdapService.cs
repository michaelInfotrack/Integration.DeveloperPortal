using Integration.DeveloperPortal.Authentication.Models;

namespace Integration.DeveloperPortal.Authentication.Interfaces
{
    public interface ILdapService
    {
        AppUser Login(string username, string password);
        AppUser SearchUser(string username);
    }
}