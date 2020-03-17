using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Services.Product;
using MyProject.Application.Services.Product.Dto;
using MyProject.Core.Entity;
using MyProject.Web.Controllers.ControllerBase;
using System.Threading.Tasks;

namespace MyProject.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Create")]
        public async Task<ActionResult<Product>> CreateProduct(ProductDto input)
        {
            var product = await _productService.CreateProduct(input);
            return Ok(product);
        }
    }
}