namespace COV19.Services.Interfaces
{
    public interface IQueryFactory<T>
    {   
        IQuery<T> CreateQuery();
        IQueryOptions<T> CreateQueryOptions();
    }
}