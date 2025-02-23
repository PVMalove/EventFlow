using EventFlow.Users.Application.Abstractions.Data;
using EventFlow.Users.Domain.Users;
using EventFlow.Users.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Users.Infrastructure.Database;

public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Users);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
