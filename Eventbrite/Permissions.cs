using OrchardCore.Security.Permissions;
using System.Collections.Generic;

namespace Etch.OrchardCore.Fields.Eventbrite
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageEventbriteAPI = new Permission("EventbriteAPI", "Manage Eventbrite API Details");

        public IEnumerable<Permission> GetPermissions()
        {
            return new[] { ManageEventbriteAPI };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManageEventbriteAPI }
                }
            };
        }
    }
}