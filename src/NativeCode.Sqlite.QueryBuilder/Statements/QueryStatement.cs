namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Text;

    public abstract class QueryStatement
    {
        protected const string CloseParens = ")";

        protected const string OpenParens = "(";

        protected const string Space = " ";

        protected internal QueryStatement(IQueryBuilder builder, string keyword)
        {
            this.Builder = builder;
            this.Keyword = keyword;
        }

        public string Keyword { get; private set; }

        protected IQueryBuilder Builder { get; private set; }

        public virtual bool CanBeginStatement(QueryStatement current)
        {
            return current == null;
        }

        protected internal abstract void Prepare(QueryBuilder builder, QueryStatement previous);

        protected internal abstract void WriteTo(StringBuilder template, QueryStatement root);
    }
}