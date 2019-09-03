using System.Threading.Tasks;
using Etch.OrchardCore.Fields.EventBrite.Models;
using OrchardCore.Entities;
using OrchardCore.Settings;

namespace Etch.OrchardCore.Fields.EventBrite.Services
{
    public class EventBriteSettingsService : IEventBriteSettingsService
    {
        private readonly ISiteService _siteService;

        public EventBriteSettingsService(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<EventBriteSettings> GetSettingsAsync()
        {
            var siteSettings = await _siteService.GetSiteSettingsAsync();

            var settings = siteSettings.As<EventBriteSettings>();
            return settings;
        }
    }

    public interface IEventBriteSettingsService
    {
        Task<EventBriteSettings> GetSettingsAsync();
    }
}