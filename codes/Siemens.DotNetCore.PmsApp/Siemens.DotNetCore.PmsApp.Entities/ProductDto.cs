
namespace Siemens.DotNetCore.PmsApp.Entities
{
    public class ProductDto
    {
        public required string ProductId { get; set; }
        public required string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }

        public ProductDto()
        {

        }

        public ProductDto(string productId, string productName, string? productDescription, decimal productPrice)
        {
            ProductId = productId;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) 
                return false;

            return obj is ProductDto product &&
                   ProductId == product.ProductId;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            return HashCode.Combine(ProductId) ^ prime;
        }
    }
}
