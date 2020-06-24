using Etch.OrchardCore.Fields.RenderAlias.Drivers;
using Etch.OrchardCore.Fields.RenderAlias.Fields;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Modules;

namespace Etch.OrchardCore.Fields.RenderAlias
{
    [Feature("Etch.OrchardCore.Fields.RenderAlias")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentField<RenderAliasField>()
                .UseDisplayDriver<RenderAliasFieldDisplayDriver>();
        }
    }
}
