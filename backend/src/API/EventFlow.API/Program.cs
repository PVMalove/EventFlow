using EventFlow.API.Extensions;
using EventFlow.API.Middleware;
using EventFlow.Common.Application;
using EventFlow.Common.Infrastructure;
using EventFlow.Common.Presentation.Endpoints;
using EventFlow.Events.Application;
using EventFlow.Events.Infrastructure;
using EventFlow.Ticketing.Infrastructure;
using EventFlow.Users.Infrastructure;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

services.AddExceptionHandler<GlobalExceptionHandler>();
services.AddProblemDetails();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options => { options.CustomSchemaIds(t => t.FullName?.Replace("+", ".")); });

services.AddApplication([
    EventFlow.Events.Application.AssemblyReference.Assembly,
    EventFlow.Users.Application.AssemblyReference.Assembly,
    EventFlow.Ticketing.Application.AssemblyReference.Assembly
]);

var dbConnectionString = builder.Configuration.GetConnectionString("Database")!;
var cacheConnectionString = builder.Configuration.GetConnectionString("Cache")!;

services.AddInfrastructure(
    [TicketingModule.ConfigureConsumers],
    dbConnectionString, cacheConnectionString);

builder.Configuration.AddModuleConfiguration(["events", "users", "ticketing"]);

builder.Services.AddHealthChecks()
    .AddNpgSql(dbConnectionString)
    .AddRedis(cacheConnectionString);

services.AddEventsModule(builder.Configuration);
services.AddUsersModule(builder.Configuration);
services.AddTicketingModule(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.MapEndpoints();

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseSerilogRequestLogging();
app.UseExceptionHandler();

app.Run();