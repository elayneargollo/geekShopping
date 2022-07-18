using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(long id);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        string Delete(long id);        
    }
}