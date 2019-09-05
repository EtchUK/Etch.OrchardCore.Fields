using Etch.OrchardCore.Fields.Eventbrite.Drivers;
using Etch.OrchardCore.Fields.Eventbrite.Fields;
using Etch.OrchardCore.Fields.Eventbrite.Models;
using Etch.OrchardCore.Fields.Eventbrite.Services;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Settings;

namespace Etch.OrchardCore.Fields.Eventbrite
{
    [Feature("Etch.OrchardCore.Fields.Eventbrite")]
    public class Startup : StartupBase
    {
        public Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<EventbriteField>();
            TemplateContext.GlobalMemberAccessStrategy.Register<EventbriteEvent>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ContentField, EventbriteField>();
            services.AddScoped<IContentFieldDisplayDriver, EventbriteFieldDisplayDriver>();

            services.AddScoped<IDisplayDriver<ISite>, EventbriteSettingsDisplayDriver>();

            services.AddScoped<INavigationProvider, AdminMenu>();

            services.AddScoped<IEventbriteService, EventbriteService>();
            services.AddScoped<IEventbriteSettingsService, EventbriteSettingsService>();

            services.AddHttpClient();
        }
    }
}