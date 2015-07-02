namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    using NativeCode.Sqlite.QueryBuilder.Extensions;

    public class UpdateStatement : QueryStatement
    {
        public UpdateStatement(EntityTable table) : base("UPDATE", table)
        {
        }

        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected internal override void WriteTo(StringBuilder template, QueryStatement parent)
        {
            template.Append(this.Keyword);
            template.Append(Space);
            template.Append(this.Table.Name);
            template.AppendLine();
            template.Append("SET");
            template.Append(Space);
            template.Append(this.GetColumnSetters());
        }

        private string GetColumnSetters()
        {
            return this.Selectables.Select(column => string.Format("{0} = {1}", column.Name, column.GetValue())).Join();
        }
    }
}