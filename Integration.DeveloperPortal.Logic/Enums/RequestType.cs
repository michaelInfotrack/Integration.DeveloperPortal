using System.ComponentModel.DataAnnotations;

namespace Integration.DeveloperPortal.Logic.Enums
{
    public enum RequestType
    {
        [Display(Name = "Http")]
        Http,
        [Display(Name = "Rest")]
        Rest
    }
}
