using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using COV19.Services.Domain;
using COV19.Services.Interfaces;
using IdentityServer4.Models;

namespace COV19.Services.Auth
{
    public class Config
    {
        // Clients allowed to access resources from Auth Server
        public static async Task<IEnumerable<Client>> GetClients(IQueryFactory<ClientRegistration> clientRegistrationQueryFactory)
        {
            using (var query = clientRegistrationQueryFactory.CreateQuery())
            {
                var options = clientRegistrationQueryFactory.CreateQueryOptions();
                var clients = await query.Execute(options);

                return clients.Select((clientRegistration) => 
                    new Client
                    {
                        ClientId = clientRegistration.ClientId,
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret(clientRegistration.ClientSecret.Sha256())
                        },
                        AllowedScopes = {clientRegistration.ScopeId}
                    }
                ).ToList();
            }
        }
    
        // APIs allowed to access the Auth server
        public static async Task<IEnumerable<ApiResource>> GetApiResources(IQueryFactory<ClientRegistration> clientRegistrationQueryFactory)
        {
            using (var query = clientRegistrationQueryFactory.CreateQuery())
            {
                var options = clientRegistrationQueryFactory.CreateQueryOptions();
                var clients = await query.Execute(options);

                return clients.Select((clientRegistration) =>
                    new ApiResource(clientRegistration.ScopeId, clientRegistration.ScopeName)
                ).Distinct().ToList();
            }
        }
    }
}