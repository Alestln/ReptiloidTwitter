using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence;

public static class PersistenceRegistration
{
    private const string ConnectionStringName = "Data";

    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName)
                               ?? throw new AggregateException(
                                   $"Connection string '{ConnectionStringName}' is not found in configurations.");
        
        services.AddDbContext<SocialDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        SocialDbContext.DbMigrationsHistoryTable,
                        SocialDbContext.DbSchema);
                });
        });
    }
}