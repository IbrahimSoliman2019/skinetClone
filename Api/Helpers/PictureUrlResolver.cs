using Api.DTOS;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Api.Helpers
{
    public class PictureUrlResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly IConfiguration configuration;

        public PictureUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl)){
                return configuration["ApiUrl"]+source.PictureUrl;
            }
            return null ;
        }
    }
}