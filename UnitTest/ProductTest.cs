using Moq;
using MyProject.Application.Services.Product;
using MyProject.Application.Services.Product.Dto;
using MyProject.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class ProductTest
    {
        private Mock<IProductService> productServiceMock;
        private ProductController controller;

        public ProductTest()
        {
            productServiceMock = new Mock<IProductService>();
            controller = new ProductController(productServiceMock.Object);
        }

        [Fact]
        public void Test1()
        {
            //var data = new List<ProductDto>
            //{
            //    new ProductDto {Id = 1, Name = "Name 1", Price = "10000", Description = "Description 1"},
            //    new ProductDto {Id = 2, Name = "Name 2", Price = "20000", Description = "Description 2"},
            //    new ProductDto {Id = 3, Name = "Name 3", Price = "30000", Description = "Description 3"}
            //};

            //var mock = new Mock<IProductService>();
            //mock.Setup(p => p.GetProducts()).Returns(Task.FromResult(data));

            //var result = controller.GetProducts();
            //Assert.Equal(data, result);
        }
    }
}
