using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository()
    {
        _dbContext = new TradeMarketDbContext();
        _dbSet = _dbContext.Set<TEntity>();
    }
    public TEntity FindById(int id)
    {
        return _dbSet.Find(id);
    }
 
    public async Task Create(TEntity item)
    {
        await _dbSet.AddAsync(item);
        await _dbContext.SaveChangesAsync();
    }
    public async Task Update(TEntity item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    public void Remove(TEntity item)
    {
        _dbSet.Remove(item);
        _dbContext.SaveChanges();
    }
}