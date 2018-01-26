using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Xamarin.UITest;

namespace MUG_App.Test
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        private IApp _app;
        private readonly Platform _platform;

        private const int NumberOfEventItems = 3;
        private const int NumberOfOrganizerItems = 2;

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
        [Explicit]
        public void StartREPL()
        {
            _app.Repl();
        }

        [Test]
        public void ShowEvents()
        {
            OpenMenu("Events");
            WaitForEvents();
            CheckNumberOfEventListItems(NumberOfEventItems);
            PullToRefresh();
            CheckNumberOfEventListItems(NumberOfEventItems);
            TapFirstItem();
        }

        [Test]
        public void ShowOrganizer()
        {
            OpenMenu("Organizers");
            WaitForOrganizers();
            CheckNumberOfOrganizerListItems(NumberOfOrganizerItems);
        }

        [Test]
        public void ShowGroup()
        {
            OpenMenu("Group");
            CheckGroupTitle();
        }

        private void PullToRefresh()
        {
            _app.DragCoordinates(500, 250, 500, 900);
        }

        private void OpenMenu(string menuItem)
        {
            _app.Tap(c => c.Marked("OK"));
            _app.Tap(c => c.Marked(menuItem));
        }

        private void CheckGroupTitle()
        {
            var result = _app.Query(c => c.Marked("groupNameLabel")).FirstOrDefault();
            result?.Text.Should().Be("Mobile User Group Zentralschweiz");
        }

        private void WaitForEvents()
        {
            _app.WaitForElement(c => c.Marked("eventListItem"));
        }

        private void WaitForOrganizers()
        {
            _app.WaitForElement(c => c.Marked("organizerListItem"));
        }

        private void CheckNumberOfEventListItems(int numberOfItems)
        {
            var result = _app.Query(c => c.Marked("eventListItem")).Count();
            result.Should().Be(numberOfItems);
        }

        private void CheckNumberOfOrganizerListItems(int numberOfItems)
        {
            var result = _app.Query(c => c.Marked("organizerListItem")).Count();
            result.Should().Be(numberOfItems);
        }

        private void TapFirstItem()
        {
            _app.Tap(c => c.Marked("eventList").Index(0));
        }

    }
}

