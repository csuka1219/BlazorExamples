using BlazorDapperCRUD.Application.Common.Interfaces;
using BlazorDapperCRUD.Domain.Entities;
using MediatR;

namespace BlazorDapperCRUD.Application.Features.Products.Commands
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
            Product? product = await _context.Products.FindAsync(request, cancellationToken);

            if (product == null)
            {
                throw new Exception();
                //throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            product.Name = request.Product.Name;
            product.Price = request.Product.Price;
            product.StockQuantity = request.Product.StockQuantity;

            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
