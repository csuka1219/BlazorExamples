using MediatR;

namespace BlazorEFCoreClean.Application.Features.Products.Commands
{
    public record DeleteProductCommand(int Id) : IRequest;
}
