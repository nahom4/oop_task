using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchBloggingApp.Application.Persistence.Contracts
{
    public interface IGenericRepository<T>
    {
     public Task<T> Get(int Id);
     public Task<IReadOnlyList<T>> GetAll();

     public Task<T> Create(T entity);

     public Task<T> Update(T entity);

     public Task<T> Delete(T entity);
     public Task<bool> Exists(int id);



    }
}