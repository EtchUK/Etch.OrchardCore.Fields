using System.Threading.Tasks;
using Etch.OrchardCore.Fields.Eventbrite.Models;
using OrchardCore.Entities;
using OrchardCore.Settings;

namespace Etch.OrchardCore.Fields.Eventbrite.Services
{
    public class EventbriteSettingsService : IEventbriteSettingsService
    {
        private readonly ISiteService _siteService;

        public EventbriteSettingsService(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<EventbriteSettings> GetSettingsAsync()
        {
            var siteSettings = await _siteService.GetSiteSettingsAsync();

            var settings = siteSettings.As<EventbriteSettings>();
            return settings;
        }
    }

    public interface IEventbriteSettingsService
    {
        Task<EventbriteSettings> GetSettingsAsync();
    }
}