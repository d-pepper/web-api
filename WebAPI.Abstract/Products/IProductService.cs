using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Abstract.Products
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
    }
}
