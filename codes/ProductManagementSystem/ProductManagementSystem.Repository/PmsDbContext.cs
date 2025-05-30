using Microsoft.EntityFrameworkCore;

namespace ProductManagementSystem.Repository
{
    public class PmsDbContext : DbContext
    {
        public PmsDbContext(DbContextOptions<PmsDbContext> options) : base(options) { }

        //public EpsilonDbContext() { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=joydip-pc\\sqlexpress;database=pmsdb;user id=sa; password=sqlserver2024; TrustServerCertificate=true;");
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var productModelBuilder = modelBuilder
                 .Entity<Product>();

            productModelBuilder
                .ToTable("products")
                .HasKey(p => p.Id);

            productModelBuilder
                .Property(p => p.Id)
                .UseIdentityColumn(100, 1)
                .HasColumnName("product_id");

            productModelBuilder
                .Property<string>(p => p.Name)
                .HasColumnName("product_name")
                .HasColumnType("varchar(50)")
                .IsRequired(true);

            productModelBuilder
                .Property<string?>(p => p.Description)
                .HasColumnType("varchar(max)")
                .HasColumnName("product_description")
                .IsRequired(false);

            productModelBuilder
               .Property<decimal>(p => p.Price)
               .HasColumnType("decimal(18,2)")
               .HasColumnName("product_price")
               .HasDefaultValue(0);

            var userModelBuilder = modelBuilder
                .Entity<User>();

            userModelBuilder
                .ToTable("users")
                .HasKey(u => u.UserName);

            userModelBuilder
                .Property<string>(p => p.UserName)
                .HasColumnName("username")
                .HasColumnType("varchar(50)")
                .IsRequired(true);

            userModelBuilder
                .Property<string>(p => p.Password)
                .HasColumnName("password")
                .HasColumnType("varchar(50)")
                .IsRequired(true);

            userModelBuilder.Property<DateOnly?>(p => p.DateOfBirth)
                .HasColumnName("dob")
                .HasColumnType("date")
                .IsRequired(false);

            userModelBuilder
                .Property<long?>(p => p.Mobile)
                .HasColumnName("mobile")
                .HasColumnType("int")
                .IsRequired(false);

            userModelBuilder.HasData(
                new User() { UserName = "joydip.mondal@gmail.com", Password = "Joydip@123", DateOfBirth = new DateOnly(2000, 1, 1), Mobile = 9091929394 }
                );
        }
    }
}
