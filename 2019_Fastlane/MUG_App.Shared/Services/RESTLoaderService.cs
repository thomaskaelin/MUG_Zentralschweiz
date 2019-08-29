using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using MUG_App.Shared.Common;
using MUG_App.Shared.Event;
using MUG_App.Shared.Group;
using MUG_App.Shared.Organizer;
using Newtonsoft.Json;

namespace MUG_App.Shared.Services
{
    public class RESTLoaderService : IEventLoaderService, IGroupLoaderService, IOrganizerLoaderService
    {
        private const string GroupURL = "https://api.meetup.com/Mobile-User-Group-Zentralschweiz";
        private const string EventsURL = "https://api.meetup.com/Mobile-User-Group-Zentralschweiz/events";
        private const string Organizer1URL = "https://api.meetup.com/mobile-user-group-zentralschweiz/members/216711932";
        private const string Organizer2URL = "https://api.meetup.com/mobile-user-group-zentralschweiz/members/184741056";

        private readonly HttpClient _client;

        public RESTLoaderService()
        {
            _client = new HttpClient { MaxResponseContentBufferSize = 256000 };
        }

        #region IEventLoaderService

        public async Task<IEnumerable<Event.Event>> LoadEventsAsync()
        {
            var result = new List<Event.Event>();

            try
            {
                var loadedEvents = await GetDataAsync(EventsURL);

                foreach (var loadedEvent in loadedEvents)
                {
                    var modelEvent = new Event.Event
                    {
                        Title = loadedEvent["name"].ToString(),
                        Description = HtmlFormatter.RemoveHtmlTags(loadedEvent["description"].ToString()),
                        RSVPCount = int.Parse(loadedEvent["yes_rsvp_count"].ToString())
                    };

                    result.Add(modelEvent);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            return result;
        }

        #endregion

        #region IGroupLoaderService

        public async Task<Group.Group> LoadGroupAsync()
        {
            var result = new Group.Group();

            try
            {
                var loadedGroup = await GetDataAsync(GroupURL);

                result.Name = loadedGroup["name"].ToString();
                result.Description = HtmlFormatter.RemoveHtmlTags(loadedGroup["description"].ToString());
                result.City = loadedGroup["city"].ToString();
                result.ImageUrl = loadedGroup["group_photo"]["photo_link"].ToString();

                return result;
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            return result;
        }

        #endregion

        #region IOrganizerLoaderService

        public async Task<IEnumerable<Organizer.Organizer>> LoadOrganizersAsync()
        {
            var result = new List<Organizer.Organizer>();

            try
            {
                var modelOrganizer1 = await LoadOrganizerAsync(Organizer1URL);
                var modelOrganizer2 = await LoadOrganizerAsync(Organizer2URL);

                result.Add(modelOrganizer1);
                result.Add(modelOrganizer2);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            return result;
        }

        #endregion

        #region Private Methods

        private async Task<dynamic> GetDataAsync(string restUrl)
        {
            dynamic result = null;

            try
            {
                var uri = new Uri(string.Format(restUrl));
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<dynamic>(content);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            return result;
        }

        private async Task<Organizer.Organizer> LoadOrganizerAsync(string restUrl)
        {
            var loadedOrganizer = await GetDataAsync(restUrl);

            var modelOrganizer = new Organizer.Organizer
            {
                Name = loadedOrganizer["name"].ToString(),
                Description = loadedOrganizer["bio"] != null ? loadedOrganizer["bio"].ToString() : string.Empty,
                City = loadedOrganizer["city"].ToString(),
                ImageUrl = loadedOrganizer["photo"]["photo_link"].ToString()
            };

            return modelOrganizer;
        }

        private static void LogException(Exception ex)
        {
            Debug.WriteLine(@"ERROR {0}", ex.Message);
        }

        #endregion
    }
}