using BlazorEFCoreClean.Application.DTOs;
using MediatR;

namespace BlazorEFCoreClean.Application.Features.Orders.Commands
{
    public record UpdateOrderCommand : IRequest<int>
    {
        public OrderDto Order { get; set; }
    }
}
