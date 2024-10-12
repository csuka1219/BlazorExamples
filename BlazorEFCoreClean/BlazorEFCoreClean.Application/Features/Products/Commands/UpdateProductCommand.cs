using BlazorEFCoreClean.Application.DTOs;
using MediatR;

namespace BlazorEFCoreClean.Application.Features.Products.Commands
{
    public record UpdateProductCommand : IRequest<int>
    {
        public ProductDto Product { get; set; }
    }
}
