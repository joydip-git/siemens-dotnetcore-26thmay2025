namespace ProductManagementSystem.APIServer.Models
{
    public class UserRegistrationDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public long? Mobile { get; set; }
        public DateOnly? DateOfBirth { get; set; }
    }
}
