using MediatR;

namespace BlazorEFCoreClean.Application.Features.Orders.Commands
{
    public record DeleteOrderCommand(int Id) : IRequest;
}
