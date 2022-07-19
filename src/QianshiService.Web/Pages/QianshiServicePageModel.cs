using QianshiService.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace QianshiService.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class QianshiServicePageModel : AbpPageModel
{
    protected QianshiServicePageModel()
    {
        LocalizationResourceType = typeof(QianshiServiceResource);
    }
}
