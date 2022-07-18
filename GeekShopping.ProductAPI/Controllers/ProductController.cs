using AutoMapper;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Dto;
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
        public List<ProductViewModel> GetAll()
        {
            var products = _productService.GetAll();

            List<ProductViewModel> productViewModel = new List<ProductViewModel>();
            products.ForEach(product => productViewModel.Add(_mapper.Map<ProductViewModel>(product)));

            return productViewModel;
        }

        [HttpGet("{id}")]
        public ProductViewModel GetById(long id)
        {
            var product = _productService.GetById(id);
            return _mapper.Map<ProductViewModel>(product);
        }

        [HttpPost]
        public ProductViewModel Add([FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            product = _productService.Add(product);
            return _mapper.Map<ProductViewModel>(product);
        }

        [HttpPut]
        public ProductViewModel Update([FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            product = _productService.Add(product);
            return _mapper.Map<ProductViewModel>(product);
        }

        [HttpDelete("{id}")]
        public string Delete(long id)
        {
            return _productService.Delete(id);
        }
    }
}