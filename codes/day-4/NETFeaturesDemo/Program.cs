using EFCoreDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//create host builder
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

ConfigurationManager configProvider = builder.Configuration;
configProvider.AddJsonFile("appsettings.json", false, true);
string? conStr = configProvider.GetConnectionString("SiemensDbConStr");

IServiceCollection serviceRegistry = builder.Services;
serviceRegistry
    .AddDbContext<SiemensDbContext>
    (
        (DbContextOptionsBuilder options) => 
        options.UseSqlServer(conStr),
        ServiceLifetime.Singleton
    );

//create the host
IHost host = builder.Build();

//get the container (DI) from the host
IServiceProvider provider = host.Services;

//ask for DI
SiemensDbContext db = provider.GetRequiredService<SiemensDbContext>();

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

db.Dispose();