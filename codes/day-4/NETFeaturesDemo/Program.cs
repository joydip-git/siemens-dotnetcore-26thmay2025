using EFCoreDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = ConfigureHost(args);
//get the container (DI) from the host
IServiceProvider provider = host.Services;
UseEFCore(provider);
UseEFCore(provider);

host.Run();


static IHost ConfigureHost(string[] args)
{
    //create host builder
    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

    builder.Configuration.AddJsonFile("appsettings.json", false, true);

    builder
        .Services
        .AddDbContext<SiemensDbContext>
        (
            (DbContextOptionsBuilder options) =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SiemensDbConStr")),
            ServiceLifetime.Transient
        );

    //create the host
    //IHost host = builder.Build();
    //return host;
    return builder.Build();
}
static void UseEFCore(IServiceProvider provider)
{
    //IDisposable -> void Dispose()
    using (IServiceScope scope = provider.CreateScope())
    {
        IServiceProvider scopedProvider = scope.ServiceProvider;
        //ask for DI
        using (SiemensDbContext db = scopedProvider.GetRequiredService<SiemensDbContext>())
        {

            //work with EF Core
            var employees = db.Employees;

            //employees.Add(new Employee { Name = "joydip", Salary = 3000 });

            //bool exists =  employees.Any(e=>e.Id == 1);
            //var found = employees.Where(e => e.Id == 1).First();
            //found.Name = "anil kumar";
            //found.Salary = 4000.00M;
            //employees.Update(found);

            //bool exists = employees.Any(e => e.Id == 3);
            //var found = employees.Where(e => e.Id == 3).First();
            //employees.Remove(found);
            //int result = db.SaveChanges();

            //Console.WriteLine(result > 0 ? "deleted" : "failed");

            employees
                .ToList()
                .ForEach(e => Console.WriteLine(e.Name));

            //db.Dispose();
            //scope.Dispose();
        }

        using (var db = scopedProvider.GetRequiredService<SiemensDbContext>())
        {
            db.Employees.Add(new Employee { Name = "joydip", Salary = 3000 });
            var res = db.SaveChanges();
            Console.WriteLine(res > 0 ? "added" : "failed");
        }
    }
}