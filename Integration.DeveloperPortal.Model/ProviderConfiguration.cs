using System;

namespace Integration.DeveloperPortal.Model
{
    public class ProviderConfiguration
    {
        public int ProviderConfigurationId { get; set; }
        public string RetailerReferencePrefix { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Resource { get; set; }
        public string Endpoint { get; set; }
        public string CountryRegion { get; set; }
        public string Environment { get; set; }
        public string ContentType { get; set; }
        public string RequestType { get; set; }
        public string AuthenticationMethod { get; set; }
        public string TokenProviderEndpoint { get; set; }
        public string TokenClientId { get; set; }
        public string TokenClientSecret { get; set; }
        public string TokenScope { get; set; }
        public string TokenGrantType { get; set; }
        public int Enabled { get; set; }
    }
}
