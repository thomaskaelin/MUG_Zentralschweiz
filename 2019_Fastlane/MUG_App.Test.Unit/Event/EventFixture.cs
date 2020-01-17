using FluentAssertions;
using Xunit;

namespace MUG_App.Test.Unit.Event
{
    public class EventFixture
    {
        private Shared.Event.Event _testee;

        public EventFixture()
        {
            _testee = new Shared.Event.Event();
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

        [Fact]
        public void Description_IsInitialized_ByConstructor()
        {
            // Assert
            var result = _testee.Description;
            result.Should().BeEmpty();
        }

        [Fact]
        public void Description_CanBeModified()
        {
            // Arrange
            const string newDescription = "New Description";

            // Act
            _testee.Description = newDescription;

            // Assert
            _testee.Description.Should().Be(newDescription);
        }

        [Fact]
        public void RSVPCount_IsInitialized_ByConstructor()
        {
            // Assert
            var result = _testee.RSVPCount;
            result.Should().Be(0);
        }

        [Fact]
        public void RSVPCount_CanBeModified()
        {
            // Arrange
            const int newCount = 42;

            // Act
            _testee.RSVPCount = newCount;

            // Assert
            _testee.RSVPCount.Should().Be(newCount);
        }

        [Fact]
        public void ToString_ReturnsCorrectResult()
        {
            // Arrange
            _testee.Title = "Hello";
            _testee.Description = "World";

            // Act
            var result = _testee.ToString();

            // Assert
            result.Should().Be("Hello: World");
        }
    }
}
