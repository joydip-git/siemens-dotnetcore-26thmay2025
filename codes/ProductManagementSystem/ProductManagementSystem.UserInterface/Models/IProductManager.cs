
namespace ProductManagementSystem.UserInterface.Models
{
    public interface IProductManager
    {
        Task<bool> SendAddProductRequest(ProductViewModel product);
        Task<ProductViewModel?> SendGetProductReuqest(int id);
        Task<List<ProductViewModel>?> SendGetProductsRequest();
        Task<bool> SendDeleteProductRequest(int id);
        Task<bool> SendUpdateProductRequest(ProductViewModel product);
    }
}