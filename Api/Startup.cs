using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Api.DTOS;
using Api.Middleware;
using Api.Extensions;
using Infrastructure.Identity;
using StackExchange.Redis;

namespace Api
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(ProductToReturnDTO));
            services.AddDbContext<StoreContext>(opt =>
            {
                opt.UseSqlServer(_config.GetConnectionString("Default"));
            }


            );
            services.AddSingleton<ConnectionMultiplexer>(Opt=>{
                var configuration = ConfigurationOptions.Parse(_config.GetConnectionString("Redis"),true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddDbContext<AppIdentityDBContext>(opt =>
         {
             opt.UseSqlServer(_config.GetConnectionString("IdentityString"));
         }


         );
            services.AddControllers();
            services.AddIdentityService(_config);
            services.AddApplicationServices();
            services.AddSwaggerExtention();
            services.AddCors(Opt =>
            {
                Opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            }
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();


            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtention();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
