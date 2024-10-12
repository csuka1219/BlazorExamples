using BlazorEFCoreClean.Application.Common.Interfaces;
using BlazorEFCoreClean.Domain.Entities;
using MediatR;

namespace BlazorEFCoreClean.Application.Features.Orders.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            Order? order = await _context.Orders.FindAsync(request, cancellationToken);

            if (order == null)
            {
                throw new Exception();
                //throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
