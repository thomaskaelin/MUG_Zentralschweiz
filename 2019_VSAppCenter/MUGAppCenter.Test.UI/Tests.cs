using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MUGAppCenter.Test.UI
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        private readonly Platform _platform;
        private IApp _app;


        public Tests(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(_platform);
        }

        [Test]
        public void FirstButtonDisplaysPopupMessage()
        {
            WaitForElement("VS App Center Demo");
            WaitForElement("Popup öffnen");
            TakeScreenshot("App gestartet");

            TapElement("Popup öffnen");
            WaitForElement("Hallo MUG-Members!");
            TakeScreenshot("Popup geöffnet");

            TapElement("Ok");
            WaitForElement("VS App Center Demo");
            TakeScreenshot("Popup geschlossen");
        }

        #region Private Methods

        private void WaitForElement(string marked)
        {
            var results = _app.WaitForElement(marked);
            Assert.IsTrue(results.Any());
        }

        private void TapElement(string marked)
        {
            _app.Tap(marked);
        }

        private void TakeScreenshot(string name)
        {
            _app.Screenshot(name);
        }

        #endregion
    }
}
