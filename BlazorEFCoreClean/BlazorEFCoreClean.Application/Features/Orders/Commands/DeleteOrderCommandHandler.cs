using BlazorEFCoreClean.Application.Common.Interfaces;
using BlazorEFCoreClean.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            Order? entity = await _context.Orders
                    .Where(l => l.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new Exception();
                //throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
