using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MUG_App.Event
{
    public interface IEventLoaderService
    {
        Task<IEnumerable<Event>> LoadEventsAsync();
    }
}
