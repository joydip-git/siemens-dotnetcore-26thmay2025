using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.APIServer.Mapping;
using ProductManagementSystem.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ProductManagementSystem.APIServer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PmsDbContext>(
    optionsBuilder => optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("EpsilonDbConStr")), ServiceLifetime.Singleton);

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers();
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy("AnonymousAccess", policy => policy.WithOrigins("*").WithHeaders("*").WithMethods("*"));
    });
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        }
    );
builder.Services.AddSingleton<ITokenManager, JwtTokenManager>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
//app.Use(
//    async (context, next) =>
//    {
//        var auth = context.Request.Headers["Authorization"];
//        await context.Response.WriteAsync(auth[0]);
//        await next();
//    }
//    );
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
