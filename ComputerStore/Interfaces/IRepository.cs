using ComputerStore.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComputerStore.Api.Interfaces
{
    interface IRepository<T> where T : EntityBase
    {
        Task<T> GetById(int id);
        IQueryable<T> GetAll();
        Task<T> Add(T entity);
        Task<T> Delete(T entity);
        Task<T> Delete(int id);
        Task<T> Update(T entity);
    }
}
