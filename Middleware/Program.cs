// Cross-Cutting Concerns Service
// Handles logging and monitoring.
using Serilog;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) => configuration.WriteTo.Console());
builder.Services.AddControllers();
var app = builder.Build();
app.UseSerilogRequestLogging();
app.UseMetricServer();
app.MapControllers();
app.Run();