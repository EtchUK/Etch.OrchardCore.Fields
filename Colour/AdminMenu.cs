using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using System;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Fields.Colour
{
    public class AdminMenu : INavigationProvider
    {
        public IStringLocalizer S { get; set; }

        public AdminMenu(IStringLocalizer<AdminMenu> localizer)
        {
            S = localizer;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder
                .Add(S["Configuration"], configuration => configuration
                    .Add(S["Settings"], settings => settings
                        .Add(S["Colours"], S["Colours"].PrefixPosition(), layers => layers
                        .AddClass("colours").Id("colours")
                            .Action("Index", "Admin", new { area = "OrchardCore.Settings", groupId = Constants.GroupId })
                            .LocalNav()
                        )));

            return Task.CompletedTask;
        }
    }
}
