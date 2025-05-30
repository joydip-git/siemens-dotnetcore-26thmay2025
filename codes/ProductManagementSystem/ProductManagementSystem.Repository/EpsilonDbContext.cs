using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagementSystem.Entities;

namespace ProductManagementSystem.Repository
{
    public class EpsilonDbContext : DbContext
    {
        public EpsilonDbContext(DbContextOptions<EpsilonDbContext> context) : base(context) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server=joydip-pc\sqlexpress;database=epsilondb;user id=sa;password=sqlserver2024;TrustServerCertificate=true");
        //}

        //model mapping through Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Product> productBuilder = modelBuilder.Entity<Product>();

            productBuilder
                .ToTable("products")
                .HasKey(p => p.Id);

            productBuilder
                .Property<int>(p => p.Id)
                .UseIdentityColumn(100, 1)
                .HasColumnName("product_id")
                .HasColumnType("int");

            productBuilder
                .Property<string>(p => p.Name)
                .HasColumnName("product_name")
                .HasColumnType("varchar(50)")
                .IsRequired(true);

            productBuilder
                .Property<string?>(p => p.Description)
                .HasColumnName("product_description")
                .HasColumnType("varchar(max)")
                .IsRequired(false);

            productBuilder
                .Property<decimal>(p => p.Price)
                .HasColumnName("product_price")
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            //productBuilder
            //    .HasData(
            //    new Product() { Name = "Dell XPS 15", Description = "new 15 inch laptop from dell", Price = 125000 },
            //    new Product() { Name = "One Plus 13", Description = "new mobile from One Plus", Price = 49999 }
            //    );

            EntityTypeBuilder<User> userModelBuilder = modelBuilder.Entity<User>();

            userModelBuilder
                .ToTable("users")
                .HasKey(user => user.UserId);

            userModelBuilder
                .Property<string>(user => user.UserId)
                .HasColumnName("userid")
                .HasColumnType("varchar(50)")
                .IsRequired(true);

            userModelBuilder
               .Property<string>(user => user.Password)
               .HasColumnName("password")
               .HasColumnType("varchar(50)")
               .IsRequired(true);

            userModelBuilder.HasData(
                new User() { UserId = "joydip@gmail.com", Password = "Joydip@123" }
                );
        }
    }
}
