using QianshiService.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace QianshiService.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(QianshiServiceEntityFrameworkCoreModule),
    typeof(QianshiServiceApplicationContractsModule)
    )]
public class QianshiServiceDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
