namespace GeekShopping.ProductAPI
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public void ProductRepository(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
    }
}