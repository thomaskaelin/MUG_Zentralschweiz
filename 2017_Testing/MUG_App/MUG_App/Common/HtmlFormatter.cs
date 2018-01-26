using System.Text.RegularExpressions;

namespace MUG_App.Common
{
    public static class HtmlFormatter
    {
        public static string RemoveHtmlTags(string source)
        {
            return Regex.Replace(source, "<[^>]*>", string.Empty);
        }
    }
}
