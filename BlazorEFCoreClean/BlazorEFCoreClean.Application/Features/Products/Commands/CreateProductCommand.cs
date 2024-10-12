using BlazorEFCoreClean.Application.DTOs;
using MediatR;

namespace BlazorEFCoreClean.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public ProductDto Product { get; set; }
    }
}
