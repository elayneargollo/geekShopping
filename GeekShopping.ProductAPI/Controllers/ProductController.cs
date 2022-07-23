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
        public async Task<List<ProductViewModel>> GetAll()
        {
            var products = await _productService.GetAll().ConfigureAwait(false);

            List<ProductViewModel> productViewModel = new List<ProductViewModel>();
            products.ForEach(product => productViewModel.Add(_mapper.Map<ProductViewModel>(product)));

            return productViewModel;
        }

        [HttpGet("{id}")]
        public  async Task<ProductViewModel> GetById(long id)
        {
            var product = await _productService.GetById(id).ConfigureAwait(false);
            return _mapper.Map<ProductViewModel>(product);
        }

        [HttpPost]
        public async Task<ProductViewModel> Add([FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            product = await _productService.Add(product).ConfigureAwait(false);
            return _mapper.Map<ProductViewModel>(product);
        }

        [HttpPut]
        public async Task<ProductViewModel> Update([FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            product = await _productService.Add(product).ConfigureAwait(false);
            return _mapper.Map<ProductViewModel>(product);
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(long id)
        {
            return await _productService.Delete(id).ConfigureAwait(false);
        }
    }
}