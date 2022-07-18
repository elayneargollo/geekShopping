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

            try
            {
                return _productRepository.GetAll().ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                throw new ArgumentException(nameof(ProductService));
            }
        }

        public Product GetById(long id)
        {
            _logger.LogInformation("Method GetById in ProductService");

            try
            {
                return _productRepository.GetById(id);
            }
            catch(Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                throw new ArgumentException(nameof(ProductService));
            }
        }

        public async Task<Product> Add(Product product)
        {
            _logger.LogInformation("Method Add in ProductService");

            try
            {
                return await _productRepository.Add(product);
            }
            catch(Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                throw new ArgumentException(nameof(ProductService));
            }
        }

        public string Delete(long id)
        {
            _logger.LogInformation("Method Delete in ProductService");

            try
            {
                _productRepository.Delete(id);
                return _productRepository.Exists(id) ? "There was an error deleting" : "Successfully deleted";
            }
            catch(Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                throw new ArgumentException(nameof(ProductService));
            }
        }

        public async Task<Product> Update(Product product)
        {
            _logger.LogInformation("Method Update in ProductService");

            try
            {
                return await _productRepository.Update(product);
            }
            catch(Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                throw new ArgumentException(nameof(ProductService));
            }
        }
    }
}