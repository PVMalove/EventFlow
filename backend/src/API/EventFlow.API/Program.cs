using EventFlow.API.Extensions;
using EventFlow.API.Middleware;
using EventFlow.Common.Application;
using EventFlow.Common.Infrastructure;
using EventFlow.Events.Application;
using EventFlow.Events.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

services.AddExceptionHandler<GlobalExceptionHandler>();
services.AddProblemDetails();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
});

services.AddApplication([AssemblyReference.Assembly]);
services.AddInfrastructure(builder.Configuration.GetConnectionString("Database")!);
builder.Configuration.AddModuleConfiguration(["events"]);

services.AddEventsModule(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.ApplyMigrations();
}

EventsModule.MapEndpoints(app);

app.UseSerilogRequestLogging();
app.UseExceptionHandler();

app.Run();