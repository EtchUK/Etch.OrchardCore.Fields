using Fluid;
using Microsoft.Extensions.DependencyInjection;
using Moov2.OrchardCore.Fields.Dictionary.Drivers;
using Moov2.OrchardCore.Fields.Dictionary.Fields;
using Moov2.OrchardCore.Fields.Dictionary.Settings;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Modules;

namespace Moov2.OrchardCore.Fields.Dictionary
{
    [Feature("Moov2.OrchardCore.Fields.Dictionary")]
    public class Startup : StartupBase
    {
        public Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<DictionaryField>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ContentField, DictionaryField>();

            services.AddScoped<IContentFieldDisplayDriver, DictionaryFieldDisplayDriver>();
            services.AddScoped<IContentPartFieldDefinitionDisplayDriver, DictionaryFieldSettingsDriver>();
        }
    }
}
