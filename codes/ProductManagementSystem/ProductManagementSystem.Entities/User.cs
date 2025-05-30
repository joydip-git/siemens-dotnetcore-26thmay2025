namespace ProductManagementSystem.Entities
{
    public class User
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public long Mobile { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
