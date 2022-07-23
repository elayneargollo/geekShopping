using GeekShopping.Web.Models;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services.IServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/controller";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<List<ProductModel>> GetAll()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> GetById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> Add(ProductModel productModel)
        {
            var response = await _client.PostAsJson(BasePath, productModel);

            if(response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else throw new ApplicationException($"Something went wrong calling the API");
        }

        public async Task<string> Delete(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<string>();
        }

        public async Task<ProductModel> Update(ProductModel productModel)
        {
            var response = await _client.PutAsJson(BasePath, productModel);

            if(response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else throw new ApplicationException($"Something went wrong calling the API");
        }
    }
}