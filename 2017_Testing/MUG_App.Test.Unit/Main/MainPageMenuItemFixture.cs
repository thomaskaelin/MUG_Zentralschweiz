using FluentAssertions;
using MUG_App.Main;
using NUnit.Framework;

namespace MUG_App.Test.Unit.Main
{
    [TestFixture]
    public class MainPageMenuItemFixture
    {
        private MainPageMenuItem _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new MainPageMenuItem();
        }

        [Test]
        public void Id_IsInitialized_ByConstructor()
        {
            // Assert
            var result = _testee.Id;
            result.Should().Be(-1);
        }

        [Test]
        public void Id_CanBeModified()
        {
            // Arrange
            const int newId = 42;

            // Act
            _testee.Id = newId;

            // Assert
            _testee.Id.Should().Be(newId);
        }

        [Test]
        public void Title_IsInitialized_ByConstructor()
        {
            // Assert
            var result = _testee.Title;
            result.Should().BeEmpty();
        }

        [Test]
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
