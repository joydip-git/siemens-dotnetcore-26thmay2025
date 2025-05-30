using ProductManagementSystem.Repository;

namespace ProductManagementSystem.APIServer.Models
{
    public interface ITokenManager
    {
        string GenerateJSONWebToken(User user);
    }
}