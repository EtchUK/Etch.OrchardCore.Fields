using OrchardCore.Security.Permissions;
using System.Collections.Generic;

namespace Etch.OrchardCore.Fields.EventBrite
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageEventBriteAPI = new Permission("EventBriteAPI", "Manage EventBrite API Details");

        public IEnumerable<Permission> GetPermissions()
        {
            return new[] { ManageEventBriteAPI };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManageEventBriteAPI }
                }
            };
        }
    }
}