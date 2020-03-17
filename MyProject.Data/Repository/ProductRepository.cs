using MyProject.Core.Entity;
using MyProject.Core.IRepository;
using MyProject.Data.EntityFrameworkCore;

namespace MyProject.Data.Repository
{
    public class ProductRepository : Repository<Product, long>, IProductRepository
    {
        public ProductRepository(MyProjectAppContext dbContext) : base(dbContext)
        {
        }
    }
}