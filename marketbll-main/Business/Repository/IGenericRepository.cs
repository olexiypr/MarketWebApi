using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task Create(TEntity item);
    TEntity FindById(int id);
    void Remove(TEntity item);
    Task Update(TEntity item);
}