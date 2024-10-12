using MediatR;

namespace BlazorEFCoreClean.Application.Features.Orders.Commands
{
    public class DeleteOrderCommand(int Id) : IRequest { }
}
