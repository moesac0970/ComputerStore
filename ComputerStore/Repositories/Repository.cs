using ComputerStore.Api.Interfaces;
using ComputerStore.Data;
using ComputerStore.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComputerStore.Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        public DataContext db;

        public Repository(DataContext context)
        {
            db = context;
        }

        //GET: arts/{id}
        public virtual async Task<T> GetById(int id)
        {
            return await db.Set<T>()
                .FindAsync(id);
        }

        // get an IQueryAble: to manipulate with deferred execution
        // GET: arts
        public virtual IQueryable<T> GetAll()
        {
            // Entities won't be manipulated directly on this set --> faster with AsNoTracking()
            var result = db.Set<T>().AsNoTracking();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            return result;
        }


        public virtual async Task<IEnumerable<T>> ListAll()
        {
            return GetAll().ToList();
        }



        //POST: entities
        public virtual async Task<T> Add(T entity)
        {
            entity.Id = 0;
            db.Set<T>().UpdateRange(entity);
            db.Set<T>().Add(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public virtual async Task<T> Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public virtual async Task<T> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) return null;
            return await Delete(entity);
        }
    }
}
