using Microsoft.EntityFrameworkCore;
using Siemens.DotNetCore.PmsApp.DataAccessLayer;
using Siemens.DotNetCore.PmsApp.Repository;
using Siemens.DotNetCore.PmsApp.BusinessLayer;
using Siemens.DotNetCore.PmsApp.Entities;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<SiemensDbContext>(
    (DbContextOptionsBuilder options) => options.UseSqlServer(builder.Configuration.GetConnectionString("SiemensDbConStr")), ServiceLifetime.Singleton);
builder.Services.AddScoped<IPmsDao<ProductDto, string>, ProductDao>();
builder.Services.AddScoped<IPmsBusinessComponent<ProductDto, string>, ProductBo>();

builder.Services.AddOpenApi();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
