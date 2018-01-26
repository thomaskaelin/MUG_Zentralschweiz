using FluentAssertions;
using MUG_App.Shared.Main;
using NUnit.Framework;

namespace MUG_App.Test.Unit.Main
{
    [TestFixture]
    public class MainPageMasterViewModelFixture : ViewModelFixtureBase<MainPageMasterViewModel>
    {
        protected override MainPageMasterViewModel CreateTestee()
        {
            return new MainPageMasterViewModel();
        }

        [Test]
        public void MenuItems_IsInitialized_ByConstructor()
        {
            // Assert
            var result = Testee.MenuItems;

            result.Should().NotBeNull();
            result.Count.Should().Be(3);

            result[0].Id.Should().Be(0);
            result[0].Title.Should().Be("Group");

            result[1].Id.Should().Be(1);
            result[1].Title.Should().Be("Organizers");

            result[2].Id.Should().Be(2);
            result[2].Title.Should().Be("Events");
        }
    }
}