using System.Threading.Tasks;

namespace MUG_App.Group
{
    public interface IGroupLoaderService
    {
        Task<Group> LoadGroupAsync();
    }
}
