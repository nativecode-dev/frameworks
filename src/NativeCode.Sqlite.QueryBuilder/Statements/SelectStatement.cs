namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    using NativeCode.Sqlite.QueryBuilder.Extensions;

    public class SelectStatement : QueryStatement
    {
        public SelectStatement(IQueryBuilder builder) : base(builder, "SELECT")
        {
        }

        protected internal override void Prepare(QueryBuilder builder, QueryStatement previous)
        {
        }

        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected internal override void WriteTo(StringBuilder template, QueryStatement root)
        {
            template.Append(this.Keyword);
            template.Append(Space);
            template.AppendLine(this.Builder.RootTable.GetAllColumns().Join());
            template.Append("FROM");
            template.Append(Space);
            template.Append(this.Builder.RootTable.GetName());
        }
    }
}