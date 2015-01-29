using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac;
using WebAPI.Abstract.Products;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private static IContainer Container { get; set; }
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IEnumerable<ProductDataContract> GetAllProducts()
        {
            //Map data model to view model
            //Should put this some where else?


            return _productService.GetProducts().Select(x => new ProductDataContract()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Category = x.Category,
                                Price = x.Price
                            });

        }

        public ProductDataContract GetProduct(int id)
        {

            var product = _productService.GetProduct(id);

            return new ProductDataContract()
            {
                Id = product.Id,
                Category = product.Category,
                Name = product.Name,
                Price = product.Price
            };

//            var product = products.FirstOrDefault((p) => p.Id == id);
//            if (product == null)
//            {
//                return NotFound();
//            }
        }
    }
}
