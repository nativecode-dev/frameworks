namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    using NativeCode.Sqlite.QueryBuilder.Extensions;

    public class InsertStatement : QueryStatement
    {
        protected internal InsertStatement(EntityTable table) : base("INSERT", table)
        {
        }

        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected internal override void WriteTo(StringBuilder template, QueryStatement parent)
        {
            template.Append(this.Keyword);
            template.Append(Space);
            template.Append("INTO");
            template.Append(Space);
            template.Append(this.Table.Name);
            template.Append(Space);
            template.Append(OpenParens);
            template.Append(this.Selectables.Select(column => column.Name).Join());
            template.Append(CloseParens);
            template.AppendLine();
            template.Append("VALUES");
            template.Append(Space);
            template.Append(OpenParens);
            template.Append(this.Selectables.Select(EntityColumnExtensions.GetValue).Join());
            template.Append(CloseParens);
        }
    }
}