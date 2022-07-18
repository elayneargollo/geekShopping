using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(long id);
        Product Add(Product product);
        Product Update(Product product);
        string Delete(long id);        
    }
}