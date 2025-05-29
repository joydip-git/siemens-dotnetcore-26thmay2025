using EFCoreDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

//create builder for any type of configuration provider
var configBuilder = new ConfigurationBuilder();

//confiure the builder
configBuilder
    .AddJsonFile("appsettings.json",false,true);

//create the provider
IConfiguration configurationProvider = configBuilder.Build();

//fetch configuration data
var conStr = configurationProvider.GetConnectionString("SiemensDbConStr");

//Console.WriteLine(conStr);

//create registry for services
IServiceCollection serviceRegistry = new ServiceCollection();

//register service
//Action<DbContextOptionsBuilder> builderDel = (op) => op.UseSqlServer(@"server=JOYDIP-PC\SQLEXPRESS;database=siemensdb;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;");
Action<DbContextOptionsBuilder> builderDel = (op) => op.UseSqlServer(conStr);

serviceRegistry
    .AddDbContext<SiemensDbContext>(builderDel, ServiceLifetime.Singleton);

//create container (service provider)
IServiceProvider provider = serviceRegistry.BuildServiceProvider();

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