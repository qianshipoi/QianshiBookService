using QianshiService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace QianshiService.Permissions;

public class QianshiServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(QianshiServicePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(QianshiServicePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<QianshiServiceResource>(name);
    }
}
