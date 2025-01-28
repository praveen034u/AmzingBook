// Service Discovery Service
// Uses Consul for dynamic service discovery.
using Consul;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
{
    consulConfig.Address = new Uri("http://localhost:8500");
}));

builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();

