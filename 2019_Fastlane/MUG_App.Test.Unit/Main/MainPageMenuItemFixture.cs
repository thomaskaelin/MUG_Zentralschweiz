using FluentAssertions;
using MUG_App.Shared.Main;
using Xunit;

namespace MUG_App.Test.Unit.Main
{
    public class MainPageMenuItemFixture
    {
        private MainPageMenuItem _testee;

        public MainPageMenuItemFixture()
        {
            _testee = new MainPageMenuItem();
        }

        [Fact]
        public void Id_IsInitialized_ByConstructor()
        {
            // Assert
            var result = _testee.Id;
            result.Should().Be(-1);
        }

        [Fact]
        public void Id_CanBeModified()
        {
            // Arrange
            const int newId = 42;

            // Act
            _testee.Id = newId;

            // Assert
            _testee.Id.Should().Be(newId);
        }

        [Fact]
        public void Title_IsInitialized_ByConstructor()
        {
            // Assert
            var result = _testee.Title;
            result.Should().BeEmpty();
        }

        [Fact]
        public void Title_CanBeModified()
        {
            // Arrange
            const string newTitle = "New Title";

            // Act
            _testee.Title = newTitle;

            // Assert
            _testee.Title.Should().Be(newTitle);
        }
    }
}
