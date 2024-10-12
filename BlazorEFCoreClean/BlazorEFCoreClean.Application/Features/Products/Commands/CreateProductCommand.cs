using BlazorEFCoreClean.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEFCoreClean.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public ProductDto Product { get; set; }
    }
}
