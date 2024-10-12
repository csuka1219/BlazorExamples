using MediatR;

namespace BlazorEFCoreClean.Application.Features.Products.Commands
{
    public class DeleteProductCommand(int Id) : IRequest { }
}
