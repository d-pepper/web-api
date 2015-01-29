using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using WebAPI.Abstract.Products;
using WebAPI.Controllers;

namespace WebAPI.Tests.Unit
{
    [TestFixture]
    public class ProductsControllerTests
    {
        [Test]
        public void Test_That_ProductsController_Uses_ProductService()
        {
            var mockProductService = new Mock<IProductService>();

            var productController = new ProductsController(mockProductService.Object);

            productController.GetAllProducts();

            mockProductService.Verify(x => x.GetProducts());
        }

        [Test]
        public void Test_That_ProductController_Returns_At_Least_One_Product_When_Index_Method_Is_Called()
        {
            var mockProductService = new Mock<IProductService>();

            mockProductService.Setup(x => x.GetProducts()).Returns(new List<Product>()  
            {
                new Product()
                {
                    Id=1
                }
            });

            var productController = new ProductsController(mockProductService.Object);

            var result = productController.GetAllProducts();

            Assert.IsTrue(result.Any());
        }

        [Test]
        public void Test_That_ProductsController_Returns_Specfic_Product_When_GetProduct_Is_Called_With_Id_Passed()
        {
            var product = new Product()
            {
                Id = 2
            };

            var mockProductService = new Mock<IProductService>();

            mockProductService.Setup(p => p.GetProduct(2)).Returns(product);

            var productController = new ProductsController(mockProductService.Object);

            var result = productController.GetProduct(2);

            Assert.AreEqual(product, result);
        }
    }
}
