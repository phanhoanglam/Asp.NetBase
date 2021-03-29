using MyProject.Application.Services.Product.Dto;
using MyProject.Core.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Application.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Core.Entity.Product> CreateProduct(ProductDto input)
        {
            var product = await _productRepository.InsertAsync(new Core.Entity.Product
            {
                Name = input.Name,
                Price = input.Price,
                Description = input.Description
            });

            await _unitOfWork.SaveChangeAsync();
            return product;
        }

        public List<ProductDto> GetProducts()
        {
            var products = _productRepository.GetAll().Select(product => new ProductDto { 
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            }).ToList();

            return products;
        }
    }
}