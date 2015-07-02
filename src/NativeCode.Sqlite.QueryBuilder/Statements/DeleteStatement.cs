namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    using NativeCode.Sqlite.QueryBuilder.Extensions;

    public class DeleteStatement : QueryStatement
    {
        public DeleteStatement(EntityTable table) : base("DELETE", table)
        {
        }

        protected internal override void Prepare(QueryBuilder builder, QueryStatement previous)
        {
        }

        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected internal override void WriteTo(StringBuilder template, QueryStatement parent)
        {
            template.Append(this.Keyword);
            template.Append(Space);
            template.Append("FROM");
            template.Append(Space);
            template.Append(this.Table.GetName());
        }
    }
}