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
            try
            {
                if (dbContext.Products.Any(p => p.ProductId == id))
                {
                    var product = dbContext.Products.Where(p => p.ProductId.Equals(id)).First();
                    dbContext.Products.Remove(product);
                    int result = dbContext.SaveChanges();
                    if (result > 0)
                        return new ProductDto
                        {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            ProductPrice = product.ProductPrice,
                            ProductDescription = product.ProductDescription
                        };
                    else
                        throw new Exception("could not delete");
                }
                else
                    throw new Exception($"product with id:{id} not found...");

            }
            catch (Exception)
            {
                throw;
            }
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
            try
            {
                if (dbContext.Products.Any(p => p.ProductId.Equals(id)))
                {
                    var product = dbContext.Products.Where(p => p.ProductId.Equals(id)).First();
                    return new ProductDto
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductDescription = product.ProductDescription
                    };
                }
                else
                    throw new Exception($"product with id:{id} not found...");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProductDto? Insert(ProductDto entity)
        {
            try
            {
                var product = new Product { ProductId = entity.ProductId, ProductName = entity.ProductName, ProductDescription = entity.ProductDescription, ProductPrice = entity.ProductPrice };
                dbContext.Products.Add(product);
                int result = dbContext.SaveChanges();
                if (result > 0)
                    return entity;
                else
                    throw new Exception("could not add..");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProductDto? Update(string id, ProductDto entity)
        {
            return null;
        }
    }
}
