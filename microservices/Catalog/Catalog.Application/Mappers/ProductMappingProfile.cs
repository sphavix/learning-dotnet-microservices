using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Specifications;

namespace Catalog.Application.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<ProductBrand, BrandResponse>().ReverseMap();
            CreateMap<ProductType, TypesResponse>().ReverseMap();
            CreateMap<Pagination<Product>, Pagination<ProductResponse>>().ReverseMap();
        }
    }
}