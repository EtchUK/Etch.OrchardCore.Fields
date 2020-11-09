using Etch.OrchardCore.Fields.Query.Drivers;
using Etch.OrchardCore.Fields.Query.Fields;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Modules;

namespace Etch.OrchardCore.Fields.Query
{
    [Feature("Etch.OrchardCore.Fields.Query")]
    public class Startup : StartupBase
    {
        public Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<QueryField>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentField<QueryField>()
                .UseDisplayDriver<QueryFieldDisplayDriver>();
        }
    }
}
