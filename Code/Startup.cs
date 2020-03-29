using Etch.OrchardCore.Fields.Code.Drivers;
using Etch.OrchardCore.Fields.Code.Fields;
using Etch.OrchardCore.Fields.Code.ViewModels;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Modules;

namespace Etch.OrchardCore.Fields.Code
{
    [Feature("Etch.OrchardCore.Fields.Code")]
    public class Startup : StartupBase
    {
        public Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<CodeField>();
            TemplateContext.GlobalMemberAccessStrategy.Register<DisplayCodeFieldViewModel>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ContentField, CodeField>();

            services.AddScoped<IContentFieldDisplayDriver, CodeFieldDisplayDriver>();
        }
    }
}
