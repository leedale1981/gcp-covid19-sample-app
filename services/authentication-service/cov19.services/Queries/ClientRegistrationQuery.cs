using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COV19.Services.Domain;
using COV19.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace COV19.Services.Data.Queries
{
    public class ClientRegistrationQuery : DataBaseQuery, IQuery<ClientRegistration>
    {
        public ClientRegistrationQuery(DbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<ClientRegistration>> Execute(IQueryOptions<ClientRegistration> query)
        {   
            return await Task.FromResult(
                ((AuthContext)this._dbContext)
                    .ClientRegistrations
                    .Where(query.QueryPredicate));
        }
    }
}