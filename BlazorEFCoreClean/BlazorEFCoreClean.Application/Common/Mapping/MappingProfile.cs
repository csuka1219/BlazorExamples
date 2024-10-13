using AutoMapper;
using BlazorEFCoreClean.Application.DTOs;
using BlazorEFCoreClean.Domain.Entities;

namespace BlazorEFCoreClean.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().PreserveReferences();
            CreateMap<Order, OrderDto>().PreserveReferences();
        }
    }

}
