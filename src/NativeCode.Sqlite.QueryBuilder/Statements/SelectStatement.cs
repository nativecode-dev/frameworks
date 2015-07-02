namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    using NativeCode.Sqlite.QueryBuilder.Extensions;

    public class SelectStatement : QueryStatement
    {
        public SelectStatement(EntityTable table) : base("SELECT", table)
        {
        }

        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected internal override void WriteTo(StringBuilder template, QueryStatement parent)
        {
            template.Append(this.Keyword);
            template.Append(Space);
            template.AppendLine(this.Table.GetAllColumns().Join());
            template.Append("FROM");
            template.Append(Space);
            template.Append(this.Table.GetName());
        }
    }
}