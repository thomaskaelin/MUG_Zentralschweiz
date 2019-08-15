using FakeItEasy;
using FluentAssertions;
using MUG_App.Shared.Group;
using Xunit;

namespace MUG_App.Test.Unit.Group
{
    public class GroupPageViewModelFixture : ViewModelFixtureBase<GroupPageViewModel>
    {
        private IGroupLoaderService _fakeGroupLoaderService;

        protected override GroupPageViewModel CreateTestee()
        {
            _fakeGroupLoaderService = A.Fake<IGroupLoaderService>();

            return new GroupPageViewModel(_fakeGroupLoaderService);
        }

        [Fact]
        public void Name_IsInitialized_ByConstructor()
        {
            // Assert
            var result = Testee.Name;
            result.Should().BeEmpty();
        }

        [Fact]
        public void Description_IsInitialized_ByConstructor()
        {
            // Assert
            var result = Testee.Description;
            result.Should().BeEmpty();
        }

        [Fact]
        public void ImageUrl_IsInitialized_ByConstructor()
        {
            // Assert
            var result = Testee.ImageUrl;
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
        public void RefreshDataCommand_WhenExecuted_LoadsGroupFromService_And_UpdatesAllProperties()
        {
            // Arrange
            var dummyGroup = CreateDummyGroup("My Group", "We talk about cool topics", "no/image/yet.png");
            A.CallTo(() => _fakeGroupLoaderService.LoadGroupAsync()).Returns(dummyGroup);

            // Act
            Testee.RefreshDataCommand.Execute(null);

            // Assert
            Testee.Name.Should().Be(dummyGroup.Name);
            Testee.Description.Should().Be(dummyGroup.Description);
            Testee.ImageUrl.Should().Be(dummyGroup.ImageUrl);
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

        private static Shared.Group.Group CreateDummyGroup(string name, string description, string imageUrl)
        {
            return new Shared.Group.Group
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl
            };
        }

        #endregion
    }
}
