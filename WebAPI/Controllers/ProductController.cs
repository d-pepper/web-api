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
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

     public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IEnumerable<ProductDataContract> GetAllProducts()
        {
            return _productService.GetProducts().Select(_mapper.Map);
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            var dataContract = _mapper.Map(product);

            return Ok(dataContract);
        }
    }
}
