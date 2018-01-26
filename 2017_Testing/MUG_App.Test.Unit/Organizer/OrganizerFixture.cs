using FluentAssertions;
using NUnit.Framework;

namespace MUG_App.Test.Unit.Organizer
{
    [TestFixture]
    public class OrganizerFixture
    {
        private Shared.Organizer.Organizer _testee;

        [SetUp]
        public void SetUp()
        {
            _testee = new Shared.Organizer.Organizer();
        }

        [Test]
        public void Name_IsInitialized_ByConstructor()
        {
            // Assert
            var result = _testee.Name;
            result.Should().BeEmpty();
        }

        [Test]
        public void Name_CanBeModified()
        {
            // Arrange
            const string newName = "New Name";

            // Act
            _testee.Name = newName;

            // Assert
            _testee.Name.Should().Be(newName);
        }

        [Test]
        public void Description_IsInitialized_ByConstructor()
        {
            // Assert
            var result = _testee.Description;
            result.Should().BeEmpty();
        }

        [Test]
        public void Description_CanBeModified()
        {
            // Arrange
            const string newDescription = "New Description";

            // Act
            _testee.Description = newDescription;

            // Assert
            _testee.Description.Should().Be(newDescription);
        }

        [Test]
        public void City_IsInitialized_ByConstructor()
        {
            // Assert
            var result = _testee.City;
            result.Should().BeEmpty();
        }

        [Test]
        public void City_CanBeModified()
        {
            // Arrange
            const string newCity = "New City";

            // Act
            _testee.City = newCity;

            // Assert
            _testee.City.Should().Be(newCity);
        }

        [Test]
        public void ImageUrl_IsInitialized_ByConstructor()
        {
            // Assert
            var result = _testee.ImageUrl;
            result.Should().BeEmpty();
        }

        [Test]
        public void ImageUrl_CanBeModified()
        {
            // Arrange
            const string newImageUrl = "New ImageUrl";

            // Act
            _testee.ImageUrl = newImageUrl;

            // Assert
            _testee.ImageUrl.Should().Be(newImageUrl);
        }

        [Test]
        public void ToString_ReturnsCorrectResult()
        {
            // Arrange
            _testee.Name = "John";
            _testee.Description = "A cool guy!";
            _testee.City = "Lucerne, Switzerland";
            _testee.ImageUrl = "/random/path/too/image.png";

            // Act
            var result = _testee.ToString();

            // Assert
            result.Should().Be("John");
        }
    }
}
