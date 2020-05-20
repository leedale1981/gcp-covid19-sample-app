using System;
using Microsoft.EntityFrameworkCore;

namespace COV19.Services.Data.Queries
{
    public abstract class DataBaseQuery : IDisposable
    {
        protected readonly DbContext _dbContext;

        public DataBaseQuery(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public int Id { get; set; }

        public void Dispose()
        {
            if (this._dbContext != null)
            {
                this._dbContext.Database.CloseConnection();
                this._dbContext.Dispose();
            }
        }
    }
}