namespace NativeCode.Sqlite.QueryBuilder.Extensions
{
    public static class FilterComparisonExtensions
    {
        public static string Stringify(this FilterComparison comparison)
        {
            switch (comparison)
            {
                case FilterComparison.GreaterThan:
                    return ">";

                case FilterComparison.GreaterThanOrEqualTo:
                    return ">=";

                case FilterComparison.IsNotNull:
                    return "IS NOT NULL";

                case FilterComparison.IsNull:
                    return "IS NULL";

                case FilterComparison.LessThan:
                    return "<";

                case FilterComparison.LessThanOrEqualTo:
                    return "<=";

                case FilterComparison.Like:
                    return "LIKE";

                case FilterComparison.NotEquals:
                    return "<>";

                case FilterComparison.NotLike:
                    return "NOT LIKE";

                default:
                    return "=";
            }
        }
    }
}