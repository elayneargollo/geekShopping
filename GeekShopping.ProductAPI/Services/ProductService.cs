using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public List<Product> GetAll()
        {
            _logger.LogInformation("Method GetAll in ProductService");
            return _productRepository.GetAll();
        }

        public Product GetById(long id)
        {
            _logger.LogInformation("Method GetById in ProductService");
            return _productRepository.GetById(id);
        }

        public Product Add(Product product)
        {
            _logger.LogInformation("Method Add in ProductService");
            return _productRepository.Add(product);
        }

        public string Delete(long id)
        {
            _logger.LogInformation("Method Delete in ProductService");
            _productRepository.Delete(id);

            return _productRepository.Exists(id) ? "There was an error deleting" : "Successfully deleted";
        }

        public Product Update(Product product)
        {
            _logger.LogInformation("Method Update in ProductService");
            return _productRepository.Update(product);
        }
    }
}