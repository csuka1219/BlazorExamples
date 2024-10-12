using Microsoft.EntityFrameworkCore;

namespace BlazorEFCoreClean.Infrastructure.Persistence
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitialiser(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}