using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;

namespace GeekShopping.ProductAPI
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(MySqlContext context) : base(context) { }
    }
}