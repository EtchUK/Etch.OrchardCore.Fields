using Etch.OrchardCore.Fields.EventBrite.Drivers;
using Etch.OrchardCore.Fields.EventBrite.Fields;
using Etch.OrchardCore.Fields.EventBrite.Models;
using Etch.OrchardCore.Fields.EventBrite.Services;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Settings;

namespace Etch.OrchardCore.Fields.EventBrite
{
    [Feature("Etch.OrchardCore.Fields.EventBrite")]
    public class Startup : StartupBase
    {
        public Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<EventBriteField>();
            TemplateContext.GlobalMemberAccessStrategy.Register<EventBriteItem>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ContentField, EventBriteField>();

            services.AddScoped<IDisplayDriver<ISite>, EventBriteSettingsDisplayDriver>();
            services.AddScoped<IContentFieldDisplayDriver, EventBriteFieldDisplayDriver>();

            services.AddScoped<INavigationProvider, AdminMenu>();

            services.AddScoped<IEventBriteSettingsService, EventBriteSettingsService>();

            services.AddHttpClient();
        }
    }
}