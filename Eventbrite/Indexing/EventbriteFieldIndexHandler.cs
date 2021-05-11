using Etch.OrchardCore.Fields.Eventbrite.Fields;
using OrchardCore.Indexing;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Search.Indexing
{
    public class EventbriteFieldIndexHandler : ContentFieldIndexHandler<EventbriteField>
    {
        public override Task BuildIndexAsync(EventbriteField field, BuildFieldIndexContext context)
        {
            var options = context.Settings.ToOptions()
                | DocumentIndexOptions.Store
                | DocumentIndexOptions.Analyze
                ;

            context.DocumentIndex.Set("EventbriteField.StartDate", field.StartDate, options);
            context.DocumentIndex.Set("EventbriteField.EndDate", field.EndDate, options);

            return Task.CompletedTask;
        }
    }
}