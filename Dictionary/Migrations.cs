using Etch.OrchardCore.Fields.Dictionary.Fields;
using Etch.OrchardCore.Fields.Dictionary.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;

namespace Etch.OrchardCore.Fields.Dictionary
{
    public class Migrations : DataMigration
    {
        #region Dependencies

        private readonly IContentDefinitionManager _contentDefinitionManager;

        #endregion Dependencies

        #region Constructor

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        #endregion Constructor

        #region Migrations

        public int Create()
        {
            _contentDefinitionManager.MigrateFieldSettings<DictionaryField, DictionaryFieldSettings>();

            return 1;
        }

        #endregion Migrations
    }
}
