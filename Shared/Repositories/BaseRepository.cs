using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public class BaseRepository<T>(DatabaseContext context) where T : BaseReposityory
    {
       
        public IQueryable<T> GetAll()
        {
            return context.Set<T>().AsQueryable();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await GetAll().Where(a => a.Id == id).SingleAsync();
        }


        // it will insert the T into the database
        public async Task<T> AddAsync(T entity)
        {
            var Entry = context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return Entry.Entity;

        }

        public async Task<T> UpdateAsync(T entity)
        {
            var Entry= context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return Entry.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(long id)
        {
            await DeleteAsync(await GetByIdAsync(id));
            await context.SaveChangesAsync();
        }



    }
}
