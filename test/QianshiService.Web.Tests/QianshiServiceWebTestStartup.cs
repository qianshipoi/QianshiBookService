using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace QianshiService;

public class QianshiServiceWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<QianshiServiceWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
