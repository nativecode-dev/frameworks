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
            foreach (var selectable in this.GetSelectables())
            {
                var table = selectable.Key;

                template.Append(this.Keyword);
                template.Append(Space);
                template.AppendLine(selectable.Join());
                template.Append("FROM");
                template.Append(Space);
                template.Append(table.GetName());
            }
        }
    }
}