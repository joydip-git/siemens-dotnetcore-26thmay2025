namespace ProductManagementSystem.Repository
{
    public interface IUserRepository
    {
        bool Register(User user);
        User? Authenticate(User user);
    }
}
