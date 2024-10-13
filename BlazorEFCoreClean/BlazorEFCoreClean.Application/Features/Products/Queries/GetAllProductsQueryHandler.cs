using AutoMapper;
using BlazorEFCoreClean.Application.Common.Interfaces;
using BlazorEFCoreClean.Application.DTOs;
using BlazorEFCoreClean.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorEFCoreClean.Application.Features.Products.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            List<Product> Products = await _context.Products.AsNoTracking().ToListAsync(cancellationToken);

            List<ProductDto> ProductDtos = _mapper.Map<List<ProductDto>>(Products);

            return ProductDtos;
        }
    }
}
