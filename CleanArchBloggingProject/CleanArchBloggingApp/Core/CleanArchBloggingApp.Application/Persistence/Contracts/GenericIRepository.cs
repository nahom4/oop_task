using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchBloggingApp.Application.Persistence.Contracts
{
    public interface GenericIRepository<T>
    {
     public Task<T> Get();
     public Task<IReadOnlyList<T>> GetAll();

     public Task<T> Create();

     public Task<T> Update();

     public Task<T> Delete();


    }
}