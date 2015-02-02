using WebAPI.Abstract.Products;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public interface IMapper
    {
        ProductDataContract Map(Product src);
    }
}