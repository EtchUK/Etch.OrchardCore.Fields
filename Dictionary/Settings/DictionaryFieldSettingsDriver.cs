using Etch.OrchardCore.Fields.Dictionary.Fields;
using Etch.OrchardCore.Fields.Dictionary.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Fields.Dictionary.Settings
{
    public class DictionaryFieldSettingsDriver : ContentPartFieldDefinitionDisplayDriver<DictionaryField>
    {
        #region Dependencies

        private readonly ILogger _logger;

        #endregion Dependencies

        #region Constructor

        public DictionaryFieldSettingsDriver(ILogger<DictionaryFieldSettingsDriver> logger)
        {
            _logger = logger;
        }

        #endregion Constructor

        #region Overrides

        #region Edit

        public override IDisplayResult Edit(ContentPartFieldDefinition model)
        {
            return Initialize<DictionaryFieldSettings>("DictionaryFieldSettings_Edit", viewModel =>
                {
                    model.PopulateSettings(viewModel);
                })
                .Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition model, UpdatePartFieldEditorContext context)
        {
            var settings = new DictionaryFieldSettings();

            if (await context.Updater.TryUpdateModelAsync(settings, Prefix))
            {
                // This makes sure the JSON is correctly formatted as it comes from the front end
                // with incorrect casing
                try
                {
                    settings.DefaultData = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<IList<DictionaryItem>>(settings.DefaultData));
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Error parsing DefaultData for DictionaryFieldSettings");
                }

                context.Builder.WithSettings(settings);
            }

            return Edit(model);
        }

        #endregion Edit

        #endregion Overrides
    }
}
