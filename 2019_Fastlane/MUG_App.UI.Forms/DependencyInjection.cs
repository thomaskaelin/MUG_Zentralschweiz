using GalaSoft.MvvmLight.Ioc;
using MUG_App.Shared.Event;
using MUG_App.Shared.Group;
using MUG_App.Shared.Main;
using MUG_App.Shared.Organizer;
using MUG_App.Shared.Services;

namespace MUG_App.UI.Forms
{
    public static class DependencyInjection
    {
        public static SimpleIoc Container => SimpleIoc.Default;
        
        public static void Register()
        {
            Container.Reset();

            // Services
            Container.Register<RESTLoaderService>();
            Container.Register<IEventLoaderService>(CreateRESTLoaderService);
            Container.Register<IGroupLoaderService>(CreateRESTLoaderService);
            Container.Register<IOrganizerLoaderService>(CreateRESTLoaderService);

            // View Models
            Container.Register<MainPageMasterViewModel>();
            Container.Register<EventPageViewModel>();
            Container.Register<GroupPageViewModel>();
            Container.Register<OrganizerPageViewModel>();
        }

        #region Private Methods

        private static RESTLoaderService CreateRESTLoaderService()
        {
            return Container.GetInstance<RESTLoaderService>();
        }

        #endregion
    }
}
