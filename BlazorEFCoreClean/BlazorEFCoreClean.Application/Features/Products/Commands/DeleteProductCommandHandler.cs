using BlazorEFCoreClean.Application.Common.Interfaces;
using BlazorEFCoreClean.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorEFCoreClean.Application.Features.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product? entity = await _context.Products
                    .Where(l => l.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new Exception();
            }

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
