using System;
using System.Collections.Generic;
using FluentAssertions;
using MUG_App.Shared.Common;
using Xunit;

namespace MUG_App.Test.Unit.Common
{
    public class HtmlFormatterFixture
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void RemoveHtmlTags_ReturnsExpectedResult(string input, string expected)
        {
            // Act
            var result = HtmlFormatter.RemoveHtmlTags(input);

            // Assert
            result.Should().Be(expected);
        }

        public static IEnumerable<object[]> TestData => new List<object[]>
        {
            new object[] { "<b>Bold</b>", "Bold" },
            new object[] { "<ul><li>Item1</li><li>Item2</li></ul>", "Item1Item2" },
            new object[] { "<p>Paragraph</p>", $"Paragraph{Environment.NewLine + Environment.NewLine}" },
            new object[] { "<p>Paragraph</p> ", $"Paragraph{Environment.NewLine + Environment.NewLine}" },
            new object[] { "Hello<br/>World", $"Hello{Environment.NewLine}World" },
            new object[] { "&amp; - &lt; - &gt; - &apos; - &quot; - &copy;", "& - < - > - ' - \" - ©" }
        };
    }
}
