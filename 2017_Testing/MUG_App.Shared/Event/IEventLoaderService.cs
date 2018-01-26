using System.Collections.Generic;
using System.Threading.Tasks;

namespace MUG_App.Shared.Event
{
    public interface IEventLoaderService
    {
        Task<IEnumerable<Event>> LoadEventsAsync();
    }
}
