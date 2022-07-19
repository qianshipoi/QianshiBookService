using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QianshiService.Data;
using Volo.Abp.DependencyInjection;

namespace QianshiService.EntityFrameworkCore;

public class EntityFrameworkCoreQianshiServiceDbSchemaMigrator
    : IQianshiServiceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreQianshiServiceDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the QianshiServiceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<QianshiServiceDbContext>()
            .Database
            .MigrateAsync();
    }
}
