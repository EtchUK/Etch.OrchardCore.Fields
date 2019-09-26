using OrchardCore.Security.Permissions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Fields.Eventbrite
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageEventbriteAPI = new Permission("EventbriteAPI", "Manage Eventbrite API Details");

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(new[] { ManageEventbriteAPI }.AsEnumerable());
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