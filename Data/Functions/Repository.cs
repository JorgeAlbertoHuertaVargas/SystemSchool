using Data.DataContext;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Functions
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext DatabaseContext;

        public Repository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity==null)
                throw new Exception("The entity is null");

            DatabaseContext.Set<TEntity>().Remove(entity);
            await DatabaseContext.SaveChangesAsync();
        }


        public async Task<TEntity> GetById(int id)
        {
            return await DatabaseContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Add(entity);
            await DatabaseContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DatabaseContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            DatabaseContext.Entry(entity).State = EntityState.Modified;
            await DatabaseContext.SaveChangesAsync();
            return entity;
        }
    }
}
