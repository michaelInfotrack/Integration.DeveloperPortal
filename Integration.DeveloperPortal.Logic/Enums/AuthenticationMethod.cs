using System.ComponentModel.DataAnnotations;

namespace Integration.DeveloperPortal.Logic.Enums
{
    public enum AuthenticationMethod
    {
        [Display(Name = "Basic")]
        Basic,
        [Display(Name = "Token")]
        Token,
        [Display(Name = "None")]
        None
    }
}
