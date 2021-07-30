using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bader.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        List<T> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<int> Count(Expression<Func<T, bool>> predicate = null);
        T FindByID(Guid Id);
        void Create(T obj);
        Task CreateRangeAsync(IEnumerable<T> objList);
        //void Delete(Action<T> deleteFunction, Expression<Func<T, bool>> predicate = null);
        void Delete(object id);
        void Update(T obj, params string[] excludedFields);

    }
}
