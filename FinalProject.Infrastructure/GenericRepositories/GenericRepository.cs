using FinalProject.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.GenericRepositories;

public class GenericRepository<T> : IGenericRepository<T> where T :class
{
    private readonly ApplicationDbContext _context;
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync();
    }
    
    public virtual async Task DeleteByIdAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task AddRangeAsync(ICollection<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public virtual async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateRangeAsync(ICollection<T> entities)
    {
        _context.Set<T>().UpdateRange(entities);
        await _context.SaveChangesAsync();
    }

    public IQueryable<T> GetTableNoTracking()
    {
        return _context.Set<T>().AsNoTracking().AsQueryable();
    }

    public virtual void Transaction(T entity)
    {
        _context.Database.BeginTransaction();
    }

    public virtual async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public virtual async Task RemoveAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}