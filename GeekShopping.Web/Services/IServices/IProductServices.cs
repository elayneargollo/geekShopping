using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAll();
        Task<ProductModel> GetById(long id);
        Task<ProductModel> Add(ProductModel productModel);
        Task<ProductModel> Update(ProductModel productModel);
        Task<string> Delete(long id);        
    }
}