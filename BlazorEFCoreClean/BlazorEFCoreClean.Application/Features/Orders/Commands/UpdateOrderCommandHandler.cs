using BlazorEFCoreClean.Application.Common.Interfaces;
using BlazorEFCoreClean.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorEFCoreClean.Application.Features.Orders.Commands
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            List<int> productIds = request.Order.Products.Select(p => p.Id).ToList();
            List<Product> products = await _context.Products
                                    .Where(p => productIds.Contains(p.Id))
                                    .ToListAsync(cancellationToken);

            Order? order = await _context.Orders
                    .Where(l => l.Id == request.Order.Id)
                    .FirstOrDefaultAsync(cancellationToken);

            if (order == null)
            {
                throw new Exception();
                //throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            order.OrderDate = request.Order.OrderDate;
            order.TotalAmount = request.Order.TotalAmount;
            order.Products = products;

            await _context.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
