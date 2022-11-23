using Etch.OrchardCore.Fields.Query.Drivers;
using Etch.OrchardCore.Fields.Query.Fields;
using Etch.OrchardCore.Fields.Query.Settings;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Modules;

namespace Etch.OrchardCore.Fields.Query
{
    [Feature("Etch.OrchardCore.Fields.Query")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentField<QueryField>()
                .UseDisplayDriver<QueryFieldDisplayDriver>();

            services.AddScoped<IContentPartFieldDefinitionDisplayDriver, QueryFieldSettingsDriver>();

            services.Configure<TemplateOptions>(o =>
            {
                o.MemberAccessStrategy.Register<QueryField>();
            });
        }
    }
}
