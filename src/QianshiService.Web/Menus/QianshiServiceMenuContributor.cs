using System.Threading.Tasks;

using QianshiService.Localization;
using QianshiService.MultiTenancy;
using QianshiService.Permissions;

using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace QianshiService.Web.Menus;

public class QianshiServiceMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<QianshiServiceResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                QianshiServiceMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        var booksStore = new ApplicationMenuItem("BooksStore", l["Menu:BookStore"], icon: "fa fa-book");
        context.Menu.AddItem(booksStore);

        if(await context.IsGrantedAsync(QianshiServicePermissions.Books.Default))
        {
            booksStore.AddItem(new ApplicationMenuItem("BooksStore.Books", l["Menu:Books"], url: "/Books"));
        }

        if(await context.IsGrantedAsync(QianshiServicePermissions.Authors.Default))
        {
            booksStore.AddItem(new ApplicationMenuItem("BooksStore.Authors", l["Menu:Authors"], url: "/Authors"));
        }


        await Task.CompletedTask;
    }
}
