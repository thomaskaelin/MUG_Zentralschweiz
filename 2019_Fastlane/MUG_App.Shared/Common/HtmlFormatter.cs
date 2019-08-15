using System;
using System.Text.RegularExpressions;

namespace MUG_App.Shared.Common
{
    public static class HtmlFormatter
    {
        public static string RemoveHtmlTags(string source)
        {
            source = Regex.Replace(source, "</p>(\\s?)", Environment.NewLine + Environment.NewLine);
            source = Regex.Replace(source, "<br/>", Environment.NewLine);
            source = Regex.Replace(source, "<[^>]*>", string.Empty);
            source = Regex.Replace(source, "&amp;", "&");
            source = Regex.Replace(source, "&lt;", "<");
            source = Regex.Replace(source, "&gt;", ">");
            source = Regex.Replace(source, "&quot;", "\"");
            source = Regex.Replace(source, "&apos;", "'");
            source = Regex.Replace(source, "&copy;", "©");

            return source;
        }
    }
}
