namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    using NativeCode.Sqlite.QueryBuilder.Extensions;

    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class WhereStatement : QueryStatement
    {
        private static readonly Type[] AllowedStatements = { typeof(DeleteStatement), typeof(SelectStatement), typeof(UpdateStatement) };

        public WhereStatement(IQueryBuilder builder) : base(builder, "WHERE")
        {
        }

        public override bool CanBeginStatement(QueryStatement current)
        {
            return AllowedStatements.Contains(current.GetType());
        }

        protected internal override void Prepare(QueryBuilder builder, QueryStatement previous)
        {
        }

        protected internal override void WriteTo(StringBuilder template, QueryStatement root)
        {
            var aliases = !(root is UpdateStatement || root is InsertStatement);

            template.AppendLine();
            template.Append(this.Keyword);
            template.Append(Space);
            template.Append(aliases ? this.GetFilterStringWithAlias() : this.GetFilterString());
        }

        private static string GetFilterComparison(EntityColumnFilter filter, string result, bool last)
        {
            if (filter.Comparison != FilterComparison.IsNotNull && filter.Comparison != FilterComparison.IsNull)
            {
                var value = filter.Column.Tokenize();

                if (filter.Column.IsQuotable)
                {
                    value = value.QuoteString();
                }

                result += Space + value;
            }

            if (!last)
            {
                result += Space + filter.Condition.Stringify() + Space;
            }

            return result;
        }

        private string GetFilterString()
        {
            var result = string.Empty;

            for (var index = 0; index < this.Builder.Filterables.Count; index++)
            {
                var filter = this.Builder.Filterables[index];
                var last = index == this.Builder.Filterables.Count - 1;

                result += filter.Column.Name + Space + filter.Comparison.Stringify();
                result = GetFilterComparison(filter, result, last);
            }

            return result;
        }

        private string GetFilterStringWithAlias()
        {
            var result = string.Empty;

            for (var index = 0; index < this.Builder.Filterables.Count; index++)
            {
                var filter = this.Builder.Filterables[index];
                var last = index == this.Builder.Filterables.Count - 1;

                result += filter.Column.GetName(false) + Space + filter.Comparison.Stringify();
                result = GetFilterComparison(filter, result, last);
            }

            return result;
        }
    }
}