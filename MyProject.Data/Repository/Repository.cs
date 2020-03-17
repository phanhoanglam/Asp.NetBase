using MyProject.Core.IRepository;
using MyProject.Data.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Data.Repository
{
    public class Repository<T, K> : IRepository<T, K> where T : class
    {
        private readonly MyProjectAppContext _dbContext;

        public Repository(MyProjectAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(K id)
        {
            var entity = Get(id);
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task DeleteAsync(K id)
        {
            _dbContext.Set<T>().Remove(await GetAsync(id));
        }

        public T Get(K id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            var entities = _dbContext.Set<T>().AsQueryable();
            return entities;
        }

        public async Task<T> GetAsync(K id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public T Insert(T entity)
        {
            var insert = _dbContext.Set<T>().Add(entity);
            //_dbContext.SaveChanges();
            return insert.Entity;
        }

        public async Task<T> InsertAsync(T entity)
        {
            var insert = await _dbContext.Set<T>().AddAsync(entity);
            //_dbContext.SaveChanges();
            return insert.Entity;
        }

        public T Update(T entity)
        {
            var update = _dbContext.Set<T>().Update(entity);
            return update.Entity;
        }

        //public async Task<T> UpdateAsync(T entity)
        //{
        //    //var update = await _dbContext.Set<T>().Update(entity);
        //    return entity;
        //}
    }
}