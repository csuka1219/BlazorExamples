using BlazorEFCoreClean.Application.DTOs;
using MediatR;

namespace BlazorEFCoreClean.Application.Features.Orders.Queries
{
    public class GetAllOrdersQuery : IRequest<List<OrderDto>>
    {
    }
}
