﻿using System.Data.Common;
using EventFlow.Ticketing.Application.Abstractions.Data;
using EventFlow.Ticketing.Domain.Customers;
using EventFlow.Ticketing.Domain.Events;
using EventFlow.Ticketing.Domain.Orders;
using EventFlow.Ticketing.Domain.Payments;
using EventFlow.Ticketing.Domain.Tickets;
using EventFlow.Ticketing.Infrastructure.Customers;
using EventFlow.Ticketing.Infrastructure.Events;
using EventFlow.Ticketing.Infrastructure.Orders;
using EventFlow.Ticketing.Infrastructure.Payments;
using EventFlow.Ticketing.Infrastructure.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EventFlow.Ticketing.Infrastructure.Database;

public sealed class TicketingDbContext(DbContextOptions<TicketingDbContext> options)
    : DbContext(options), IUnitOfWork
{
    internal DbSet<Customer> Customers { get; set; }

    internal DbSet<Event> Events { get; set; }

    internal DbSet<TicketType> TicketTypes { get; set; }

    internal DbSet<Order> Orders { get; set; }

    internal DbSet<OrderItem> OrderItems { get; set; }

    internal DbSet<Ticket> Tickets { get; set; }

    internal DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Ticketing);

        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new TicketTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
    }

    public async Task<DbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (Database.CurrentTransaction is not null)
        {
            await Database.CurrentTransaction.DisposeAsync();
        }

        return (await Database.BeginTransactionAsync(cancellationToken)).GetDbTransaction();
    }
}
