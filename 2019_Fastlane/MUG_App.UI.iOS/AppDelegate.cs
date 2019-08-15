using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using UIKit;

namespace MUG_App.UI.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Xamarin.Forms.Forms.Init();
            ImageCircleRenderer.Init();

            LoadApplication(new MUG_App.UI.Forms.App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
