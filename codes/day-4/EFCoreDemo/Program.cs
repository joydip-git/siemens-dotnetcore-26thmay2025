using EFCoreDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//create registry for services
IServiceCollection serviceRegistry = new ServiceCollection();

//register services
//serviceRegistry.Add(
//    new ServiceDescriptor(
//    serviceType: null,
//    implementationType: typeof(SiemensDbContext),
//    lifetime: ServiceLifetime.Singleton)
//    );
//serviceRegistry.AddSingleton<Intreface,Class>();

Action<DbContextOptionsBuilder> builderDel = (op) => op.UseSqlServer(@"server=JOYDIP-PC\SQLEXPRESS;database=siemensdb;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;");

serviceRegistry
    .AddDbContext<SiemensDbContext>(builderDel, ServiceLifetime.Singleton);

//create container (service provider)
IServiceProvider provider = serviceRegistry.BuildServiceProvider();

//DbContextOptionsBuilder<SiemensDbContext> builder = new();

//builder
//    .UseSqlServer(@"server=JOYDIP-PC\SQLEXPRESS;database=siemensdb;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;");

//DbContextOptions<SiemensDbContext> options = builder.Options;

//var db = new SiemensDbContext(options);
SiemensDbContext db = provider.GetRequiredService<SiemensDbContext>();
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