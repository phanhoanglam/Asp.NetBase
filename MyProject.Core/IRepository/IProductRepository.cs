using MyProject.Core.Entity;

namespace MyProject.Core.IRepository
{
    public interface IProductRepository : IRepository<Product, long>
    {
    }
}