using Microsoft.EntityFrameworkCore;
using Serilog;
using UuidMasterApi;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Reverse proxy.
// builder.Services.Configure<ForwardedHeadersOptions>(options => {
//     options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
// });

// Log
builder.Host.UseSerilog();

// Database.
var connectionString =
builder.Services.AddDbContext<UuidMasterApiDbContext>(
    dbContextOptions => dbContextOptions.UseSqlServer(
        builder.Configuration["ConnectionStrings:UuidMasterApiDbConnectionString"]
    )
);

// Controllers
builder.Services.AddControllers(options => {
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson();

// Entity-model mapper.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UsePathBase("/api");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // SSL not configured.

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

app.Run(async (context) => {
   await context.Response.WriteAsync("Hello from uuidmasterapi!");
});

app.Run();

public partial class Program { } // Required to reference class from tests.
