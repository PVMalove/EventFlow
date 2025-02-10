using System.Data.Common;
using EventFlow.Common.Application.Data;
using Npgsql;

namespace EventFlow.Events.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}