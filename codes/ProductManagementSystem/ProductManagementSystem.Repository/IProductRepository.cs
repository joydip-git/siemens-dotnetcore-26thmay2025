namespace ProductManagementSystem.Repository
{
    public interface IProductRepository : IPmsDbRepository<Product, int>
    {
        List<Product>? FilterProductsByName(string name = "");
    }
}
