using QianshiService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace QianshiService;

[DependsOn(
    typeof(QianshiServiceEntityFrameworkCoreTestModule)
    )]
public class QianshiServiceDomainTestModule : AbpModule
{

}
