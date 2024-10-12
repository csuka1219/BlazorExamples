﻿using BlazorDapperCRUD.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDapperCRUD.Application.Features.Products.Commands
{
    public record UpdateProductCommand : IRequest<int>
    {
        public ProductDto Product { get; set; }
    }
}