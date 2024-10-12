using BlazorEFCoreClean.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEFCoreClean.Application.Features.Orders.Commands
{
    public record UpdateOrderCommand : IRequest<int>
    {
        public OrderDto Order { get; set; }
    }
}
