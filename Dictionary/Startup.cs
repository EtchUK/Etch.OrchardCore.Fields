using Fluid;
using Microsoft.Extensions.DependencyInjection;
using Etch.OrchardCore.Fields.Dictionary.Drivers;
using Etch.OrchardCore.Fields.Dictionary.Fields;
using Etch.OrchardCore.Fields.Dictionary.Settings;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Modules;

namespace Etch.OrchardCore.Fields.Dictionary
{
    [Feature("Etch.OrchardCore.Fields.Dictionary")]
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
