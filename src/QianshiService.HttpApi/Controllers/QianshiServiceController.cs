using QianshiService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QianshiService.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class QianshiServiceController : AbpControllerBase
{
    protected QianshiServiceController()
    {
        LocalizationResource = typeof(QianshiServiceResource);
    }
}
