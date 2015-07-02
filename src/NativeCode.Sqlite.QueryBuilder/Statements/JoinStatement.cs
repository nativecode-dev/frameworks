namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Text;

    public class JoinStatement : QueryStatement
    {
        public JoinStatement(IQueryBuilder builder) : base(builder, "JOIN")
        {
        }

        protected internal override void Prepare(QueryBuilder builder, QueryStatement previous)
        {
        }

        protected internal override void WriteTo(StringBuilder template, QueryStatement root)
        {
        }
    }
}