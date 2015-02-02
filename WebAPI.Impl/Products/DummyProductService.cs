using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Abstract;
using WebAPI.Abstract.Products;

namespace WebAPI.Services.Products
{
    public class DummyProductService : IProductService
    {
        readonly Product[] _products = new Product[]
        {
            new Product { Id = 1, Name = "Soup", Category = "Groceries", Price = 1},
            new Product { Id = 2, Name = "Yo-Yo", Category = "Toys", Price = 3.75M},
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M},
        };

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}
