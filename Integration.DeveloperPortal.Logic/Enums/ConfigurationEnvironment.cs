using System.ComponentModel.DataAnnotations;

namespace Integration.DeveloperPortal.Logic.Enums
{
    public enum ConfigurationEnvironment
    {
        [Display(Name = "Test")]
        Test,
        [Display(Name = "Staging")]
        Staging,
        [Display(Name = "Production")]
        Production
    }
}
