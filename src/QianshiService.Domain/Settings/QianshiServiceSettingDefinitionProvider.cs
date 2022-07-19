using Volo.Abp.Settings;

namespace QianshiService.Settings;

public class QianshiServiceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(QianshiServiceSettings.MySetting1));
    }
}
