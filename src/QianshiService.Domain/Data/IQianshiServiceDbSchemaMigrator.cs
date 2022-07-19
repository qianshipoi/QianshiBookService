using System.Threading.Tasks;

namespace QianshiService.Data;

public interface IQianshiServiceDbSchemaMigrator
{
    Task MigrateAsync();
}
