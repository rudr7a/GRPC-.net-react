using GrpcServices;
using GrpcServices.Data;
using GrpcServices.Services;
using Microsoft.EntityFrameworkCore;
using Grpc.AspNetCore.Server; // gRPC reflection
using Grpc.AspNetCore.Web; // gRPC-Web
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to listen on port 5001 with HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5001, listenOptions =>
    {
        listenOptions.UseHttps(); // Ensure HTTPS is enabled
    });
});

// Add services to the container.
builder.Services.AddGrpc(options =>
{
    options.EnableDetailedErrors = true;
});

// Register gRPC Reflection
builder.Services.AddGrpcReflection();


// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Register the DbContext with the PostgreSQL connection string
builder.Services.AddDbContext<MessageContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Use CORS middleware
app.UseCors("AllowAll");

// Use gRPC-Web middleware
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true }); // Enables gRPC-Web for all gRPC services by default

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>()
   .EnableGrpcWeb(); // This enables gRPC-Web on the GreeterService

// Enable gRPC Reflection endpoint
app.MapGrpcReflectionService();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

// Start the browser and navigate to the application's home page
var url = "https://localhost:5001";  // Adjust the URL and port as needed
Process.Start(new ProcessStartInfo
{
    FileName = url,
    UseShellExecute = true
});

app.Run();
