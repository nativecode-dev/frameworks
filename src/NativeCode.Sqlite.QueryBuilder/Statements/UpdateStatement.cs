namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    using NativeCode.Sqlite.QueryBuilder.Extensions;

    internal class UpdateStatement : QueryStatement
    {
        public UpdateStatement(IQueryBuilder builder) : base(builder, "UPDATE")
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
            template.Append(this.Builder.RootTable.Name);
            template.AppendLine();
            template.Append("SET");
            template.Append(Space);
            template.Append(this.GetColumnSetters());
        }

        private string GetColumnSetters()
        {
            return this.Builder.Selectables.Select(column => string.Format("{0} = {1}", column.Name, column.GetValue())).Join();
        }
    }
}