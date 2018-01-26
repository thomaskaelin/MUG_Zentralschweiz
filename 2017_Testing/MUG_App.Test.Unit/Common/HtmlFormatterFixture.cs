using FluentAssertions;
using MUG_App.Common;
using NUnit.Framework;

namespace MUG_App.Test.Unit.Common
{
    [TestFixture]
    public class HtmlFormatterFixture
    {
        [TestCase("<b>Bold</b>", "Bold")]
        [TestCase("<ul><li>Item1</li><li>Item2</li></ul>", "Item1Item2")]
        public void RemoveHtmlTags_ReturnsExpectedResult(string input, string expected)
        {
            // Act
            var result = HtmlFormatter.RemoveHtmlTags(input);

            // Assert
            result.Should().Be(expected);
        }
    }
}
