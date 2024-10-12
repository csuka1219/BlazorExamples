using BlazorDapperCRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorDapperCRUD.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
