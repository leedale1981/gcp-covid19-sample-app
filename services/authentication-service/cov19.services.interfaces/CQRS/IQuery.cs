using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COV19.Services.Interfaces
{
    public interface IQuery<T>: IDisposable
    {
        int Id { get; set; }
        Task<IEnumerable<T>> Execute(IQueryOptions<T> queryOptions);
    }
}