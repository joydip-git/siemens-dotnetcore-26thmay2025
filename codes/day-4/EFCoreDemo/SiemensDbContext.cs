using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo
{
    public class SiemensDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=JOYDIP-PC\SQLEXPRESS;database=siemensdb;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;");
        }
    }
}
