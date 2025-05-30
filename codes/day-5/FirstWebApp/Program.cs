//web host -> WebApplication
//web host builder -> WebApplicationBuilder
//generic host -> Host
//generic host builder -> HostApplicationBuilder
//HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);
//IHost host = hostBuilder.Build();

WebApplicationBuilder webHostBuilder = WebApplication.CreateBuilder(args);

IServiceCollection serviceRegistry = webHostBuilder.Services;
//registering services (classes) on which moddlewares used in API type application are dependent
serviceRegistry.AddControllers();
serviceRegistry.AddHttpsRedirection(options => options.HttpsPort = 7149);

WebApplication app = webHostBuilder.Build();
//app.Map("welcome", (HttpContext context) => context.Response.WriteAsync("welcome to web..."));
//app.Map("welcome", () => "welcome to web...");
//app.MapGet("welcome", (HttpContext context) => context.Response.WriteAsync("welcome to web..."));

app.UseHttpsRedirection();
app.UseAuthorization();

//web API middleware
app.MapControllers();

app.Run();
