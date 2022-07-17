using AutoMapper;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("/api/controller")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly IMapper _mapper; 

        public ProductController(ILogger<ProductController> logger, IProductService productService, IMapper mapper)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            return new List<Product>()
            {
                new Product("product", 546, "description", "category", "url")
            };
        }

        [HttpGet("{id}")]
        public ProductViewModel GetById(long id)
        {
            var product = new Product("product", 546, "description", "category", "url");
            return _mapper.Map<ProductViewModel>(product);
        }
    }
}