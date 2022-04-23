using System.Text.RegularExpressions;

namespace Cinema.Helpers
{
    public static class HumanHelper
    {
        public static bool ConsistOnlyFIO(this string value)
        {
            return (Regex.IsMatch(value, @"^([a-zA-Z-]+\b( )?)+$)"));
        }
    }
}
