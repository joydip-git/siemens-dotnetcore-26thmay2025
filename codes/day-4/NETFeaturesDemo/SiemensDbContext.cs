using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDemo
{
    public class SiemensDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public SiemensDbContext(DbContextOptions<SiemensDbContext> options) : base(options)
        {

        }
        //use this method for Migration and comment afterwards
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server=JOYDIP-PC\SQLEXPRESS;database=siemensdb;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Employee> builder = modelBuilder.Entity<Employee>();

            builder
                .ToTable("employees")
                .HasKey(e => e.Id);


            builder
                .Property<int>(e => e.Id)
                .HasColumnName("empid")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property<string>(e => e.Name)
                .HasColumnName("empname")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property<decimal>(e => e.Salary)
                .HasColumnName("empsalary")
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            //builder
            //    .HasData
            //    (
            //        new Employee { Id = -1, Name = "anil", Salary = 1000 },
            //        new Employee { Id = -2, Name = "sunil", Salary = 2000 }
            //    );
        }
    }
}
