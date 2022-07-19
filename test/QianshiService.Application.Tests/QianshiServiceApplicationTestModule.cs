using Volo.Abp.Modularity;

namespace QianshiService;

[DependsOn(
    typeof(QianshiServiceApplicationModule),
    typeof(QianshiServiceDomainTestModule)
    )]
public class QianshiServiceApplicationTestModule : AbpModule
{

}
