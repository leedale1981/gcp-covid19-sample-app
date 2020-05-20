using System;
using COV19.Services.Domain;
using COV19.Services.Interfaces;

namespace COV19.Services.Data.Queries
{
    public class ClientRegistrationQueryOptions : IQueryOptions<ClientRegistration>
    {
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
        public string  QueryValue { get; set; }
        public string SearchQuery { get; set; }
        public int Top { get; set; }
        public int Skip { get; set; }

        public Func<ClientRegistration, bool> QueryPredicate 
        { 
            get 
            {
                return (ClientRegistration cr) => cr.ClientId == this.QueryValue;
            } 
        }
    }
}