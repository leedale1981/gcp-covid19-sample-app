using System;

namespace COV19.Services.Interfaces
{
    public interface IQueryOptions<T>
    {
        string QueryValue { get; set; }
        Func<T, bool> QueryPredicate { get; }
        string SortBy { get; set; }
        string SortDirection { get; set; }
        string SearchQuery { get; set; }
        int Top { get; set; }
        int Skip { get; set; }
    }
}