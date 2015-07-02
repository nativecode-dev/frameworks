namespace NativeCode.Sqlite.QueryBuilder.Extensions
{
    public static class FilterExpressionExtensions
    {
        public static string Stringify(this FilterCondition condition)
        {
            switch (condition)
            {
                case FilterCondition.Or:
                    return "OR";

                default:
                    return "AND";
            }
        }
    }
}