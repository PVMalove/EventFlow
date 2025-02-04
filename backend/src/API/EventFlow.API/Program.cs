using EventFlow.API.Extensions;
using EventFlow.Events.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEventsModule(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.ApplyMigrations();
}

EventsModule.MapEndpoints(app);

app.Run();