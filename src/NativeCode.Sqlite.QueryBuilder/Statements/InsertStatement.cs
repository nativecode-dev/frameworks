namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    using NativeCode.Sqlite.QueryBuilder.Extensions;

    internal class InsertStatement : QueryStatement
    {
        internal InsertStatement(IQueryBuilder builder) : base(builder, "INSERT")
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
            template.Append("INTO");
            template.Append(Space);
            template.Append(this.Builder.RootTable.Name);
            template.Append(Space);
            template.Append(OpenParens);
            template.Append(this.Builder.Selectables.Select(column => column.Name).Join());
            template.Append(CloseParens);
            template.AppendLine();
            template.Append("VALUES");
            template.Append(Space);
            template.Append(OpenParens);
            template.Append(this.Builder.Selectables.Select(EntityColumnExtensions.GetValue).Join());
            template.Append(CloseParens);
        }
    }
}