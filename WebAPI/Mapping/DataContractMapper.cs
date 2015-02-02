using WebAPI.Abstract.Products;
using WebAPI.Controllers;
using WebAPI.Models;

namespace WebAPI.Mapping
{
    public class DataContractMapper : IMapper
    {
        public ProductDataContract Map(Product product)
        {
            return new ProductDataContract
            {
                Id = product.Id,
                Category = product.Category,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}