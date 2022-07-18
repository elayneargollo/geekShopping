using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI
{
    public interface IProductService
    {
        List<Product> GetAll();
        Task<Product> GetById(long id);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<string> Delete(long id);        
    }
}