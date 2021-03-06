﻿namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Text;

    internal class OrderByStatement : QueryStatement
    {
        internal OrderByStatement(IQueryBuilder builder) : base(builder, "ORDER BY")
        {
        }

        public override bool CanBeginStatement(QueryStatement current)
        {
            return current is SelectStatement || current is WhereStatement;
        }

        protected internal override void Prepare(QueryBuilder builder, QueryStatement previous)
        {
        }

        protected internal override void WriteTo(StringBuilder template, QueryStatement root)
        {
        }
    }
}