using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Moq;
using NUnit.Framework;
using WebAPI.Abstract.Products;
using WebAPI.Controllers;
using WebAPI.Models;

namespace WebAPI.Tests.Unit
{
    [TestFixture]
    public class ProductsTests
    {
        private Mock<IMapper> _mockMapper;
        private Mock<IProductService> _mockProductService;
        private ProductsController _productController;

        [SetUp]
        public void SetUp()
        {
            _mockProductService = new Mock<IProductService>();
            _mockMapper = new Mock<IMapper>();
            _productController = new ProductsController(_mockProductService.Object, _mockMapper.Object);

        }

        [Test]
        public void Test_That_ProductsController_Uses_ProductService()
        {          
            _productController.GetAllProducts();

            _mockProductService.Verify(x => x.GetProducts());
        }

        [Test]
        public void Test_That_ProductController_Returns_At_Least_One_Product_When_Index_Method_Is_Called()
        {
            _mockProductService.Setup(x => x.GetProducts()).Returns(new List<Product>()  
            {
                new Product()
                {
                    Id=1
                }
            });

            var result = _productController.GetAllProducts();

            Assert.IsTrue(result.Any());
        }

        [Test]
        public void Test_That_ProductsController_Returns_Specfic_Product_When_GetProduct_Is_Called_With_Id_Passed()
        {
            _mockProductService.Setup(x => x.GetProduct(2)).Returns(new Product() { Id = 2, Category = "TestCategory", Name = "TestName", Price = 1.99M });
            _mockMapper.Setup(x => x.Map(It.Is<Product>(y=>y.Id==2))).Returns(new ProductDataContract() { Id = 2, Category = "TestCategory", Name = "TestName", Price = 1.99M });

            var productController = new ProductsController(_mockProductService.Object, _mockMapper.Object);

            IHttpActionResult actionResult = productController.GetProduct(2);
            var contentResult = actionResult as OkNegotiatedContentResult<ProductDataContract>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(2, contentResult.Content.Id);
        }
    }
}