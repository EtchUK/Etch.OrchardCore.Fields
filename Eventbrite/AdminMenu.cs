using Microsoft.Extensions.Localization;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using System;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Fields.Eventbrite
{
    [Feature("Etch.OrchardCore.Fields.Eventbrite")]
    public class AdminMenu : INavigationProvider
    {
        public AdminMenu(IStringLocalizer<AdminMenu> localizer)
        {
            T = localizer;
        }

        public IStringLocalizer T { get; set; }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder
                .Add(T["Configuration"], configuration => configuration
                    .Add(T["API"], settings => settings
                        .Add(T["Eventbrite API"], T["Eventbrite API"], layers => layers
                            .Action("Index", "Admin", new { area = "OrchardCore.Settings", groupId = Constants.SettingsGroupId })
                            .Permission(Permissions.ManageEventbriteAPI)
                            .LocalNav()
                        )));

            return Task.CompletedTask;
        }
    }
}