using ProductManagementSystem.Entities;

namespace ProductManagementSystem.APIService.Models
{
    public interface ITokenManager
    {
        string GenerateJSONWebToken(User user);
    }
}