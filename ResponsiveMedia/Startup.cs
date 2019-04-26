using Fluid;
using Microsoft.Extensions.DependencyInjection;
using Moov2.OrchardCore.Fields.ResponsiveMedia.Drivers;
using Moov2.OrchardCore.Fields.ResponsiveMedia.Fields;
using Moov2.OrchardCore.Fields.ResponsiveMedia.Settings;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Modules;

namespace Moov2.OrchardCore.Fields.ResponsiveMedia
{
    [Feature("Moov2.OrchardCore.Fields.ResponsiveMedia")]
    public class Startup : StartupBase
    {
        static Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<ResponsiveMediaField>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ContentField, ResponsiveMediaField>();
            services.AddScoped<IContentFieldDisplayDriver, ResponsiveMediaFieldDisplayDriver>();
            services.AddScoped<IContentPartFieldDefinitionDisplayDriver, ResponsiveMediaFieldSettingsDriver>();
        }
    }
}
