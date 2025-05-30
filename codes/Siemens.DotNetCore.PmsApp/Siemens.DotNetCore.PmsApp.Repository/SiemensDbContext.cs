using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Siemens.DotNetCore.PmsApp.Repository
{
    //primary constructor
    public class SiemensDbContext(DbContextOptions<SiemensDbContext> options) : DbContext(options)
    {
        //public SiemensDbContext(DbContextOptions<SiemensDbContext> options) : base(options) 
        //{ 
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Product> productModelBuilder = modelBuilder.Entity<Product>();

            productModelBuilder
                .ToTable("products")
                .HasKey(p => p.ProductId);

            productModelBuilder
                .Property<string>(p => p.ProductId)
                .HasColumnName("productid")
                .HasColumnType("varchar(8)")
                .IsRequired();

            productModelBuilder
                .Property<string>(p => p.ProductName)
                .HasColumnName("productname")
                .HasColumnType("varchar(50)")
                .IsRequired();

            productModelBuilder
                .Property<string?>(p => p.ProductDescription)
                .HasColumnName("productdesc")
                .HasColumnType("varchar(max)")
                .IsRequired(false);

            productModelBuilder
                .Property<decimal>(p => p.ProductPrice)
                .HasColumnType("decimal(18,2)")
                .HasColumnName("productprice")
                .HasDefaultValue(0);
        }
    }
}
