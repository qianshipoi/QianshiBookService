using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace QianshiService.Data;

/* This is used if database provider does't define
 * IQianshiServiceDbSchemaMigrator implementation.
 */
public class NullQianshiServiceDbSchemaMigrator : IQianshiServiceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
