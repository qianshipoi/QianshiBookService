using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace QianshiService.Web;

[Dependency(ReplaceServices = true)]
public class QianshiServiceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "QianshiService";
}
