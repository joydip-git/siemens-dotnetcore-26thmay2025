namespace ProductManagementSystem.Repository;

public class User
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public long? Mobile { get; set; }
    public DateOnly? DateOfBirth { get; set; }
}

