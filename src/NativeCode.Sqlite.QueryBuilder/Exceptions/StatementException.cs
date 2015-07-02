namespace NativeCode.Sqlite.QueryBuilder.Exceptions
{
    using System;

    using NativeCode.Sqlite.QueryBuilder.Statements;

    public class StatementException : Exception
    {
        public StatementException(QueryStatement current, QueryStatement statement) : base(CreateExceptionMessage(current, statement))
        {
        }

        private static string CreateExceptionMessage(QueryStatement current, QueryStatement statement)
        {
            return string.Format("Keyword {0} cannot follow a {1}.", statement.Keyword, current.Keyword);
        }
    }
}