using RentHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHouse.Repository
{
     public interface IRepository<TId,TEntity> : IDisposable 
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> GetById(TId id);
        Task<List<TEntity>> GetAll();
        void Update( TEntity obj);
        Task RemoveById(TId id);
        void Remove(TEntity obj);
    }
}
