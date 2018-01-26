using System.Linq;
using FakeItEasy;
using FluentAssertions;
using MUG_App.Event;
using NUnit.Framework;

namespace MUG_App.Test.Unit.Event
{
    [TestFixture]
    public class EventPageViewModelFixture : ViewModelFixtureBase<EventPageViewModel>
    {
        private IEventLoaderService _fakeEventLoaderService;

        protected override EventPageViewModel CreateTestee()
        {
            _fakeEventLoaderService = A.Fake<IEventLoaderService>();

            return new EventPageViewModel(_fakeEventLoaderService);
        }

        [Test]
        public void Events_IsInitialized_ByConstructor()
        {
            // Assert
            var result = Testee.Events;
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Test]
        public void RefreshDataCommand_IsInitialized_ByConstructor()
        {
            // Assert
            var result = Testee.RefreshDataCommand;
            result.Should().NotBeNull();
        }

        [Test]
        public void RefreshDataCommand_WhenExecuted_LoadsEventsFromService_And_FillsThemIntoEvents()
        {
            // Arrange
            var dummyEvent1 = CreateDummyEvent("Event 1");
            var dummyEvent2 = CreateDummyEvent("Event 2");
            var dummyEvent3 = CreateDummyEvent("Event 3");

            Testee.Events.Add(dummyEvent1);

            A.CallTo(() => _fakeEventLoaderService.LoadEventsAsync()).Returns(new[] { dummyEvent2, dummyEvent3 });

            // Act
            Testee.RefreshDataCommand.Execute(null);

            // Assert
            Testee.Events.Count.Should().Be(2);
            Testee.Events.First().Should().Be(dummyEvent2);
            Testee.Events.Last().Should().Be(dummyEvent3);
        }

        [Test]
        public void RefreshDataCommand_WhenExecuted_UpdatesIsBusy()
        {
            // Act
            Testee.RefreshDataCommand.Execute(null);

            // Assert
            IsBusyStates.Count.Should().Be(2);
            IsBusyStates[0].Should().BeTrue();
            IsBusyStates[1].Should().BeFalse();
        }

        [Test]
        public void RefreshDataCommand_WhenNotIsBusy_CanBeExecuted()
        {
            // Arrange
            Testee.IsBusy = false;

            // Act
            var result = Testee.RefreshDataCommand.CanExecute(null);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void RefreshDataCommand_WhenIsBusy_CanNotBeExecuted()
        {
            // Arrange
            Testee.IsBusy = true;

            // Act
            var result = Testee.RefreshDataCommand.CanExecute(null);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsBusy_WhenModified_UpdatesRefreshDataCommand()
        {
            // Arrange
            var numberOfEvents = 0;
            Testee.RefreshDataCommand.CanExecuteChanged += (sender, args) => { numberOfEvents++; };

            // Act
            Testee.IsBusy = true;

            // Assert
            numberOfEvents.Should().Be(1);
        }

        #region Private Methods

        private static MUG_App.Event.Event CreateDummyEvent(string title)
        {
            return new MUG_App.Event.Event { Title = title };
        }

        #endregion
    }
}
