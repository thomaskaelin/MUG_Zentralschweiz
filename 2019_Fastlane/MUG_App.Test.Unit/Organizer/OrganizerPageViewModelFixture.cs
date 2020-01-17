using System.Linq;
using FakeItEasy;
using FluentAssertions;
using MUG_App.Shared.Organizer;
using Xunit;

namespace MUG_App.Test.Unit.Organizer
{
    public class OrganizerPageViewModelFixture : ViewModelFixtureBase<OrganizerPageViewModel>
    {
        private IOrganizerLoaderService _fakeOrganizerLoaderService;

        protected override OrganizerPageViewModel CreateTestee()
        {
            _fakeOrganizerLoaderService = A.Fake<IOrganizerLoaderService>();

            return new OrganizerPageViewModel(_fakeOrganizerLoaderService);
        }

        [Fact]
        public void Organizers_IsInitialized_ByConstructor()
        {
            // Assert
            var result = Testee.Organizers;
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public void RefreshDataCommand_IsInitialized_ByConstructor()
        {
            // Assert
            var result = Testee.RefreshDataCommand;
            result.Should().NotBeNull();
        }

        [Fact]
        public void RefreshDataCommand_WhenExecuted_LoadsOrganizersFromService_And_FillsThemIntoOrganizers()
        {
            // Arrange
            var dummyOrganizer1 = CreateDummyOrganizer("Event 1");
            var dummyOrganizer2 = CreateDummyOrganizer("Event 2");
            var dummyOrganizer3 = CreateDummyOrganizer("Event 3");

            Testee.Organizers.Add(dummyOrganizer1);

            A.CallTo(() => _fakeOrganizerLoaderService.LoadOrganizersAsync()).Returns(new[] { dummyOrganizer2, dummyOrganizer3 });

            // Act
            Testee.RefreshDataCommand.Execute(null);

            // Assert
            Testee.Organizers.Count.Should().Be(2);
            Testee.Organizers.First().Should().Be(dummyOrganizer2);
            Testee.Organizers.Last().Should().Be(dummyOrganizer3);
        }

        [Fact]
        public void RefreshDataCommand_WhenExecuted_UpdatesIsBusy()
        {
            // Act
            Testee.RefreshDataCommand.Execute(null);

            // Assert
            IsBusyStates.Count.Should().Be(2);
            IsBusyStates[0].Should().BeTrue();
            IsBusyStates[1].Should().BeFalse();
        }

        [Fact]
        public void RefreshDataCommand_WhenNotIsBusy_CanBeExecuted()
        {
            // Arrange
            Testee.IsBusy = false;

            // Act
            var result = Testee.RefreshDataCommand.CanExecute(null);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void RefreshDataCommand_WhenIsBusy_CanNotBeExecuted()
        {
            // Arrange
            Testee.IsBusy = true;

            // Act
            var result = Testee.RefreshDataCommand.CanExecute(null);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
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

        private static Shared.Organizer.Organizer CreateDummyOrganizer(string name)
        {
            return new Shared.Organizer.Organizer { Name = name };
        }

        #endregion
    }
}
