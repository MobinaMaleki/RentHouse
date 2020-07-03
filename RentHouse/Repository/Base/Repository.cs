using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentHouse.Data;
using RentHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentHouse.Repository
{
    public class Repository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _dbcontext;
        public Repository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public async Task<TEntity> Add(TEntity obj)
        {
            await _dbcontext.Set<TEntity>().AddAsync(obj);
            return obj;
        }

       public async Task<List<TEntity>> GetAll()
        {
            return await _dbcontext.Set<TEntity>().ToListAsync();
        }
        
        public async Task<TEntity> GetById(TId id)
        {
            return await _dbcontext.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity obj)
        {
            _dbcontext.Set<TEntity>().Remove(obj);
        }

        public async Task RemoveById(TId id)
        {
            var find = await GetById(id);
            Remove(find);
        }

      
        public async Task<int> SaveChangesAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }

        public void Update( TEntity obj)
        {
            _dbcontext.Set<TEntity>().Update(obj);
            //_dbcontext.Entry(obj).State = EntityState.Modified;
        }
    }
       
}
