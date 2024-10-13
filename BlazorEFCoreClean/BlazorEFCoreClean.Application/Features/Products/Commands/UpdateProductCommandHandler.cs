using BlazorEFCoreClean.Application.Common.Interfaces;
using BlazorEFCoreClean.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorEFCoreClean.Application.Features.Products.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product? entity = await _context.Products
                    .Where(l => l.Id == request.Product.Id)
                    .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new Exception();
                //throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            entity.Name = request.Product.Name;
            entity.Price = request.Product.Price;
            entity.StockQuantity = request.Product.StockQuantity;

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
