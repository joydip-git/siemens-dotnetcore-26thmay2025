
namespace ProductManagementSystem.UserInterface.Models
{
    public interface IUserApiManager
    {
        Task<string?> SendRequestToAuthenticateUser(UserViewModel user);
        Task<bool> SendRequestToRegisterUser(UserViewModel user);
    }
}