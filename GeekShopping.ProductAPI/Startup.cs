using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

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
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();
                app.UseRouting();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API REST with ASP NET CORE 6.0");
                    c.RoutePrefix = "swagger";
                });

                app.UseSwagger(c =>
                {
                    c.SerializeAsV2 = true;
                });

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
