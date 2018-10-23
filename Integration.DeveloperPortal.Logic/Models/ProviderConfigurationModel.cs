using Integration.DeveloperPortal.Logic.Enums;

namespace Integration.DeveloperPortal.Logic.Models
{
    public class ProviderConfigurationModel
    {
        public int ProviderConfigurationId { get; set; }
        public string RetailerReferencePrefix { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Resource { get; set; }
        public string Endpoint { get; set; }
        public Country CountryRegion { get; set; }
        public ConfigurationEnvironment Environment { get; set; }
        public string ContentType { get; set; }
        public RequestType RequestType { get; set; }
        public AuthenticationMethod AuthenticationMethod { get; set; }
        public ConfigurationStatus Enabled { get; set; }
    }
}
