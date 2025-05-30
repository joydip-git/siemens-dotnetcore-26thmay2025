namespace ProductManagementSystem.Repository
{
    public interface IPmsDbContextSeed
    {
        Task SeedAsync(int retryForAvailability = 0);
    }
}