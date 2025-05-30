namespace ProductManagementSystem.APIServer.Models
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Id},{Name}, {Description}, {Price}";
        }
    }
}
