using MyProject.Application.Services.Product.Dto;
using System.Threading.Tasks;

namespace MyProject.Application.Services.Product
{
    public interface IProductService
    {
        Task<MyProject.Core.Entity.Product> CreateProduct(ProductDto input);
    }
}