using System.Threading.Tasks;

namespace MUG_App.Shared.Group
{
    public interface IGroupLoaderService
    {
        Task<Group> LoadGroupAsync();
    }
}
