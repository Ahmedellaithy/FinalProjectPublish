namespace FinalProject.Infrastructure.GenericRepositories;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task DeleteByIdAsync(int id);
    Task DeleteAsync(T entity);
    Task AddAsync (T entity);
    Task AddRangeAsync(ICollection<T> entities);
    Task UpdateAsync (T entity);
    Task UpdateRangeAsync(ICollection<T> entities);
    IQueryable<T> GetTableNoTracking ();
    void Transaction(T entity);
    Task SaveChangesAsync();
}