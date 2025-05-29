
using EFCoreDemo;

var db = new SiemensDbContext();
var employees = db.Employees;

employees.ToList().ForEach(e => Console.WriteLine(e.Name));

employees.Add(new Employee());
int result = db.SaveChanges();

db.Dispose();