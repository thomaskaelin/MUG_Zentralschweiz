using System.Collections.Generic;
using System.Threading.Tasks;

namespace MUG_App.Shared.Organizer
{
    public interface IOrganizerLoaderService
    {
        Task<IEnumerable<Organizer>> LoadOrganizersAsync();
    }
}
