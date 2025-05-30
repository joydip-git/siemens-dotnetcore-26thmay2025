namespace ProductManagementSystem.Entities
{
    public class ProductQueryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
