namespace NativeCode.Sqlite.QueryBuilder.Extensions
{
    public static class StringExtensions
    {
        public static string QualifyString(this string name)
        {
            return "[" + name + "]";
        }

        public static string QuoteString(this string value)
        {
            if (QueryBuilderConfiguration.Current.UseDoubleQuotes)
            {
                return "\"" + value + "\"";
            }

            return "'" + value + "'";
        }

        public static string Tokenize(this string value)
        {
            return "{" + value + "}";
        }
    }
}