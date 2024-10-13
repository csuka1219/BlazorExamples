using AutoMapper;
using BlazorEFCoreClean.Application.Common.Interfaces;
using BlazorEFCoreClean.Application.DTOs;
using BlazorEFCoreClean.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorEFCoreClean.Application.Features.Orders.Queries
{
    internal class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            List<Order> Orders = await _context.Orders.ToListAsync(cancellationToken);

            List<OrderDto> OrderDtos = Orders.Select(order => new OrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Products = _mapper.Map<List<ProductDto>>(order.Products),
            }).ToList();

            return OrderDtos;
        }
    }
}
