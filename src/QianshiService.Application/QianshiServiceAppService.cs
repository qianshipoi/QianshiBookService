using System;
using System.Collections.Generic;
using System.Text;
using QianshiService.Localization;
using Volo.Abp.Application.Services;

namespace QianshiService;

/* Inherit your application services from this class.
 */
public abstract class QianshiServiceAppService : ApplicationService
{
    protected QianshiServiceAppService()
    {
        LocalizationResource = typeof(QianshiServiceResource);
    }
}
