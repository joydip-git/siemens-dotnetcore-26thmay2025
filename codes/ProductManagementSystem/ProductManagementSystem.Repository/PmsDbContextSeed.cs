using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ProductManagementSystem.Repository
{
    public class PmsDbContextSeed(PmsDbContext context, ILogger<PmsDbContext> logger) : IPmsDbContextSeed
    {
        public async Task SeedAsync(int retryForAvailability = 0)
        {
            try
            {
                context.Database.Migrate();


                if (!context.Products.Any())
                {
                    context.AddRange(GetPreConfiguredProducts());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 5)
                {
                    retryForAvailability++;
                    logger.Log(LogLevel.Error, ex.Message);
                    await SeedAsync(retryForAvailability);
                }
                throw;
            }
        }
        private static IEnumerable<Product> GetPreConfiguredProducts() =>
        [
                new Product { Name = "dell xps 15", Description = "new 15 inch laptop from dell xps series", Price = 120000 },
                new Product { Name = "lenovo thinkpad 13", Description = "new 13 inch laptop from lenovo", Price = 115000 }
                ];
    }
}
