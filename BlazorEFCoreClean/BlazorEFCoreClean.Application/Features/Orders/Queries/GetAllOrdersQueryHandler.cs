﻿using BlazorEFCoreClean.Application.Common.Interfaces;
using BlazorEFCoreClean.Application.DTOs;
using BlazorEFCoreClean.Application.Features.Products.Queries;
using BlazorEFCoreClean.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEFCoreClean.Application.Features.Orders.Queries
{
    internal class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllOrdersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            List<Order> Orders = await _context.Orders.ToListAsync(cancellationToken);

            List<OrderDto> OrderDtos = Orders.Select(order => new OrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
            }).ToList();

            return OrderDtos;
        }
    }
}