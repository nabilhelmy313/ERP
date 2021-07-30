using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Persistence;
using Bader.Application.Interfaces.Repositories;
using Domain.Entities.General;

namespace Persistence
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ERPDbContext _dbContext;
        private DbSet<T> table = null;
        public BaseRepository(ERPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return await _dbContext.Set<T>().ToListAsync();
            else
                return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbContext.Set<T>().ToList();
            else
                return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public Task<int> Count(Expression<Func<T, bool>> predicate = null) =>
                        predicate == null
                ? _dbContext.Set<T>().CountAsync()
                : _dbContext.Set<T>().Where(predicate).CountAsync();

        public virtual T FindByID(Guid Id)
        {
            return _dbContext.Set<T>().FirstOrDefault(z => z.Id == Id);

        }

        public virtual void Create(T obj)
        {
            _dbContext.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Added;
        }

        public virtual async Task CreateRangeAsync(IEnumerable<T> objList)
        {
            await _dbContext.AddRangeAsync(objList);
        }

        //public virtual void Delete(Action<T> deleteFunction, Expression<Func<T, bool>> predicate = null)
        //{
        //    _dbContext.Set<T>().Where(predicate).ForEachAsync(delegate (T item)
        //    {
        //        deleteFunction(item);
        //    });
        //}
        public virtual void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Update(T obj, params string[] excludedFields)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            foreach (string fld in excludedFields)
                _dbContext.Entry(obj).Property(fld).IsModified = false;
        }


    }
}
