﻿using Etch.OrchardCore.Fields.Values.Fields;
using Etch.OrchardCore.Fields.Values.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;

namespace Etch.OrchardCore.Fields.Values
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
            _contentDefinitionManager.MigrateFieldSettings<ValuesField, ValuesFieldSettings>();

            return 1;
        }

        #endregion Migrations
    }
}