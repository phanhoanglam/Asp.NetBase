using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyProject.Core.IRepository
{
    public interface IRepository<T, K> where T : class
    {
        T Get(K id);

        Task<T> GetAsync(K id);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicates = null);

        T Insert(T entity);

        Task<T> InsertAsync(T entity);

        T Update(T entity);

        //Task<T> UpdateAsync(T entity);
        void Delete(K id);

        Task DeleteAsync(K id);
    }
}