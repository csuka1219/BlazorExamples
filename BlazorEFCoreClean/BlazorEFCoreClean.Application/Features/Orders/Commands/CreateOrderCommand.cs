using BlazorEFCoreClean.Application.DTOs;
using MediatR;

namespace BlazorEFCoreClean.Application.Features.Orders.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
        public OrderDto Order { get; set; }
    }
}
