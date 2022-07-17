﻿using AutoMapper;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using GeekShopping.ProductAPI.Model.Dto;
using GeekShopping.ProductAPI.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GeekShopping.ProductAPI
{
    public class Startup
    {
            public IConfiguration Configuration { get; }
            public IWebHostEnvironment Environment { get; }

            public Startup(IConfiguration configuration, IWebHostEnvironment environment)
            {
                Configuration = configuration;
                Environment = environment;
            }

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddCors();
                services.AddControllers();
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 

                services.AddDbContext<MySqlContext>(options =>
                        options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), 
                                        new MySqlServerVersion(
                                            new Version(8,0,5))));
                
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping.ProductAPI", Version = "v1" });
                });

                var config = new AutoMapper.MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Product, ProductViewModel>();
                    cfg.CreateMap<ProductDto, Product>();
                });
    
                IMapper mapper = config.CreateMapper();
                services.AddSingleton(mapper);

                services.AddScoped<IProductRepository, ProductRepository>();
                services.AddScoped<IProductService, ProductService>();
    
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeekShopping.ProductAPI v1"));
                }

                app.UseHttpsRedirection();
                app.UseRouting();

                app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

                app.UseAuthentication();
                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
}
