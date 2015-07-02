namespace NativeCode.Sqlite.QueryBuilder
{
    public enum FilterComparison
    {
        Default = 0,

        Equals = Default,

        NotEquals = 1,

        GreaterThan = 2,

        GreaterThanOrEqualTo = 3,

        IsNull = 4,

        IsNotNull = 5,

        LessThan = 6,

        LessThanOrEqualTo = 7,

        Like = 8,

        NotLike = 9
    }
}