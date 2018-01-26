using System.Collections.Generic;
using System.Threading.Tasks;
using MUG_App.Event;
using MUG_App.Group;
using MUG_App.Organizer;

namespace MUG_App.Test.Acceptance.Services
{
    public class DummyLoaderService : IEventLoaderService, IGroupLoaderService, IOrganizerLoaderService
    {
        public Task<IEnumerable<Event.Event>> LoadEventsAsync()
        {
            var event1 = new Event.Event {Title = "Cool Topic", Description = "Some super cool stuff here!", RSVPCount = 5};
            var event2 = new Event.Event {Title = "Great Style", Description = "It's going to be huuuuuuge.", RSVPCount = 1337};
            var events = new[] { event1, event2 };
            var result = Task.FromResult<IEnumerable<Event.Event>>(events);

            return result;
        }

        public Task<Group.Group> LoadGroupAsync()
        {
            var group = new Group.Group { Name = "Mobile User Group Zentralschweiz", City = "Lucerne", Description = "Great mobile talks for everyone." };
            var result = Task.FromResult(group);

            return result;
        }

        public Task<IEnumerable<Organizer.Organizer>> LoadOrganizersAsync()
        {
            var organizer1 = new Organizer.Organizer { Name = "Loana Albisser", Description = "Working for bbv since 2016.", City = "Lucerne" };
            var organizer2 = new Organizer.Organizer { Name = "Thomas Kälin", Description = "Working for bbv since 2013.", City = "Lucerne" };
            var organizers = new[] { organizer1, organizer2 };
            var result = Task.FromResult<IEnumerable<Organizer.Organizer>>(organizers);

            return result;
        }
    }
}
