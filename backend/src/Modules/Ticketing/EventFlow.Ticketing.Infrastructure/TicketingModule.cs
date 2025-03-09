using EventFlow.Common.Infrastructure.Interceptors;
using EventFlow.Common.Presentation.Endpoints;
using EventFlow.Ticketing.Application.Abstractions.Data;
using EventFlow.Ticketing.Application.Carts;
using EventFlow.Ticketing.Domain.Customers;
using EventFlow.Ticketing.Infrastructure.Customers;
using EventFlow.Ticketing.Infrastructure.Database;
using EventFlow.Ticketing.Infrastructure.PublicApi;
using EventFlow.Ticketing.PublicApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventFlow.Ticketing.Infrastructure;

public static class TicketingModule
{
    public static IServiceCollection AddTicketingModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);
        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConnectionString = configuration.GetConnectionString("Database")!;
        
        services.AddDbContext<TicketingDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Ticketing))
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>())
                .UseSnakeCaseNamingConvention());

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TicketingDbContext>());
        
        services.AddSingleton<CartService>();

        services.AddScoped<ITicketingApi, TicketingApi>();
    }
}
