using Dapper;
using Integration.DeveloperPortal.Model;
using Integration.DeveloperPortal.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Integration.DeveloperPortal.Repository
{
    public class ProviderConfigurationRepository : IProviderConfigurationRepository
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public ProviderConfigurationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SaaSIntegrationDatabase");
        }

        public List<ProviderConfiguration> GetAllEnabledConfigurations()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT * FROM ProviderConfiguration WHERE Enabled = 1";

                return dbConnection.Query<ProviderConfiguration>(query).ToList();
            }
        }

        public List<ProviderConfiguration> GetAllConfigurations()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT * FROM ProviderConfiguration";

                return dbConnection.Query<ProviderConfiguration>(query).ToList();
            }
        }

        public ProviderConfiguration GetConfiguration(int providerConfigurationId)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT * FROM ProviderConfiguration WHERE ProviderConfigurationId = @ProviderConfigurationId";

                return dbConnection.Query<ProviderConfiguration>(query, new { ProviderConfigurationId = providerConfigurationId }).FirstOrDefault();
            }
        }

        public void UpdateConfiguration(ProviderConfiguration providerConfiguration)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                var query = 
                    "UPDATE ProviderConfiguration " +
                    "SET RetailerReferencePrefix = @RetailerReferencePrefix, Username = @Username, " +
                    "Password = @Password, Resource = @Resource, Endpoint = @Endpoint, " +
                    "CountryRegion = @CountryRegion, Environment = @Environment, ContentType = @ContentType, " +
                    "RequestType = @RequestType, AuthenticationMethod = @AuthenticationMethod, " +
                    "Enabled = @Enabled " +
                    "WHERE ProviderConfigurationId = @ProviderConfigurationId";

                 dbConnection.Execute(query, new {
                    providerConfiguration.ProviderConfigurationId,
                    providerConfiguration.RetailerReferencePrefix,
                    providerConfiguration.Username,
                    providerConfiguration.Password,
                    providerConfiguration.Resource,
                    providerConfiguration.Endpoint,
                    providerConfiguration.CountryRegion,
                    providerConfiguration.Environment,
                    providerConfiguration.ContentType,
                    providerConfiguration.RequestType,
                    providerConfiguration.AuthenticationMethod,
                    providerConfiguration.Enabled
                });
            }
        }

        public void InsertNewConfiguration(ProviderConfiguration providerConfiguration)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                var query =
                    "INSERT INTO ProviderConfiguration (" +
                    "RetailerReferencePrefix, Username," +
                    "Password, Resource, Endpoint, " +
                    "CountryRegion, Environment, ContentType, " +
                    "RequestType, AuthenticationMethod, Enabled) " +
                    "VALUES (" +
                    "@RetailerReferencePrefix, @Username, " +
                    "@Password, @Resource, @Endpoint, " +
                    "@CountryRegion, @Environment, @ContentType, " +
                    "@RequestType, @AuthenticationMethod, @Enabled)";


                dbConnection.Execute(query, new
                {
                    providerConfiguration.RetailerReferencePrefix,
                    providerConfiguration.Username,
                    providerConfiguration.Password,
                    providerConfiguration.Resource,
                    providerConfiguration.Endpoint,
                    providerConfiguration.CountryRegion,
                    providerConfiguration.Environment,
                    providerConfiguration.ContentType,
                    providerConfiguration.RequestType,
                    providerConfiguration.AuthenticationMethod,
                    providerConfiguration.Enabled
                });
            }
        }
    }
}
