using Integration.DeveloperPortal.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.DeveloperPortal.Logic.Interfaces
{
    public interface IAuthenticationService
    {
        AppUser Login(string username, string password);
    }
}
