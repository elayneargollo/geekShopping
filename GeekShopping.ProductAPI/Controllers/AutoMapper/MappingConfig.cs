using AutoMapper;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Dto;
using GeekShopping.ProductAPI.Model.ViewModel;

namespace GeekShopping.ProductAPI.Controllers.AutoMapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfiguration = new MapperConfiguration(config => {
                config.CreateMap<Product, ProductViewModel>();
                config.CreateMap<ProductDto, Product>();
            });

            return mapperConfiguration;
        }
    }
}