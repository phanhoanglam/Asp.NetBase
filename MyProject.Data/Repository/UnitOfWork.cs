using MyProject.Core.IRepository;
using MyProject.Data.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MyProject.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyProjectAppContext _dbContext;

        public UnitOfWork(MyProjectAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}