using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api.Extensions
{
    public static class SwaggerServicesExtention
    {

        public static IServiceCollection AddSwaggerExtention(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                 {
                     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
                 });
            return services;
        }
        public static IApplicationBuilder UseSwaggerExtention(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skinet Api"));
            return app;
        }

    }
}