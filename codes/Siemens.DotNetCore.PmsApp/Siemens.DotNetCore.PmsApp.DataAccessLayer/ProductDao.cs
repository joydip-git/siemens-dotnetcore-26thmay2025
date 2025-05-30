using Microsoft.EntityFrameworkCore;
using Siemens.DotNetCore.PmsApp.Entities;
using Siemens.DotNetCore.PmsApp.Repository;

namespace Siemens.DotNetCore.PmsApp.DataAccessLayer
{
    public class ProductDao(SiemensDbContext dbContext) : IPmsDao<ProductDto, string>
    {
        //private readonly SiemensDbContext dbContext;
        //public ProductDao(SiemensDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}

        public ProductDto? Delete(string id)
        {
            return null;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            try
            {
                DbSet<Product> products = dbContext.Products;
                var records = new List<ProductDto>();
                if (products.Any())
                {
                    products
                        .ToList()
                        .ForEach(
                        p =>
                        records.Add(
                            new ProductDto
                            {
                                ProductId = p.ProductId,
                                ProductName = p.ProductName,
                                ProductDescription = p.ProductDescription,
                                ProductPrice = p.ProductPrice
                            })
                        );
                }
                return records;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProductDto? GetById(string id)
        {
            return null;
        }

        public ProductDto? Insert(ProductDto entity)
        {
            return null;
        }

        public ProductDto? Update(string id, ProductDto entity)
        {
            return null;
        }
    }
}
