using COV19.Services.Data.Queries;
using COV19.Services.Domain;
using COV19.Services.Interfaces;
using Serilog;

namespace COV19.Services.Data.Factories
{
    public class ClientRegistrationQueryFactory : IQueryFactory<ClientRegistration>
    {
        private readonly ILogger _logger; 
        private readonly string _databaseConnectionString;
        
        public ClientRegistrationQueryFactory(ILogger logger, string databaseConnectionString)
        {
            this._logger = logger;
            this._databaseConnectionString = databaseConnectionString;
        }

        public IQuery<ClientRegistration> CreateQuery()
        {
            this._logger.Information($"Instantiating a query command.");
            //this._logger.LogInfo($"with connection string: {this._databaseConnectionString}");
            return new ClientRegistrationQuery(new AuthContext(this._databaseConnectionString));
        }

        public IQueryOptions<ClientRegistration> CreateQueryOptions()
        {
            return new ClientRegistrationQueryOptions();
        }
    }
}