using QianshiService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace QianshiService.Permissions;

public class QianshiServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.AddGroup(QianshiServicePermissions.GroupName, L("Permission:BookStore"));

        var booksPermission = bookStoreGroup.AddPermission(QianshiServicePermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(QianshiServicePermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(QianshiServicePermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(QianshiServicePermissions.Books.Delete, L("Permission:Books.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<QianshiServiceResource>(name);
    }
}
