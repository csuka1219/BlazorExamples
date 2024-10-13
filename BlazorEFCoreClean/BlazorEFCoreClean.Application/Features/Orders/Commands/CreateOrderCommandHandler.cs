using AutoMapper;
using BlazorEFCoreClean.Application.Common.Interfaces;
using BlazorEFCoreClean.Application.DTOs;
using BlazorEFCoreClean.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace BlazorEFCoreClean.Application.Features.Orders.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            List<int> productIds = request.Order.Products.Select(p => p.Id).ToList();
            List<Product> products = await _context.Products
                                    .Where(p => productIds.Contains(p.Id))
                                    .ToListAsync(cancellationToken);

            Order order = new Order
            {
                OrderDate = request.Order.OrderDate,
                TotalAmount = request.Order.TotalAmount,
                Products = products
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
