using System.Linq;
using Api.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services){
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<IRepositoryProduct, RepositoryProduct>();
            services.AddScoped<IBasketRepo,BasketRepo>();
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.Configure<ApiBehaviorOptions>(Opt =>
            {
                Opt.InvalidModelStateResponseFactory = ActionContext =>
                {
                    var errors = ActionContext.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray();
                    var errorresponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorresponse);
                };
            });
            return services;
        }
    }
}