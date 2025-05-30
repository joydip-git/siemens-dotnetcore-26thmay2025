namespace ProductManagementSystem.Repository
{
    public class UserRepository(PmsDbContext context) : IUserRepository
    {
        public User? Authenticate(User user)
        {
            try
            {
                var found = context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).First();
                return found ?? null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Register(User user)
        {
            try
            {
                var found = context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).First();
                if (found == null)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
