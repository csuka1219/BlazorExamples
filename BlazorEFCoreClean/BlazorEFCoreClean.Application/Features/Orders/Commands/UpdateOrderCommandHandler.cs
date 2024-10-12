using BlazorEFCoreClean.Application.Common.Interfaces;
using BlazorEFCoreClean.Domain.Entities;
using MediatR;

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
            Order? order = await _context.Orders.FindAsync(request, cancellationToken);

            if (order == null)
            {
                throw new Exception();
                //throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            order.OrderDate = request.Order.OrderDate;
            order.TotalAmount = request.Order.TotalAmount;

            await _context.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
