namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NativeCode.Sqlite.QueryBuilder.Attributes;

    public abstract class QueryStatement
    {
        protected const string CloseParens = ")";

        protected const string OpenParens = "(";

        protected const string Space = " ";

        protected readonly List<EntityColumnFilter> Filterables = new List<EntityColumnFilter>();

        protected readonly List<EntityColumn> Selectables = new List<EntityColumn>();

        protected readonly List<EntityColumnSort> Sortables = new List<EntityColumnSort>();

        protected internal QueryStatement(string keyword, EntityTable table)
        {
            this.Keyword = keyword;
            this.Table = table;
        }

        public string Keyword { get; private set; }

        protected EntityTable Table { get; private set; }

        public virtual bool CanBeginStatement(QueryStatement current)
        {
            return current == null;
        }

        protected internal void Filter(
            EntityColumn column,
            string @group = "Default",
            FilterCondition condition = FilterCondition.Default,
            FilterComparison comparison = FilterComparison.Default)
        {
            this.Filterables.Add(new EntityColumnFilter(column, @group, condition, comparison));
        }

        protected internal void Filter(
            IEnumerable<EntityColumn> columns,
            string @group = "Default",
            FilterCondition condition = FilterCondition.Default,
            FilterComparison comparison = FilterComparison.Default)
        {
            this.Filterables.AddRange(columns.Select(c => new EntityColumnFilter(c, @group, condition, comparison)));
        }

        protected internal void Select(EntityColumn column)
        {
            this.Selectables.Add(column);
        }

        protected internal void Select(IEnumerable<EntityColumn> columns)
        {
            this.Selectables.AddRange(columns);
        }

        protected internal void Sort(EntityColumn column, SortDirection direction = SortDirection.Default)
        {
            this.Sortables.Add(new EntityColumnSort(column, direction));
        }

        protected internal void Sort(IEnumerable<EntityColumn> columns)
        {
            this.Sortables.AddRange(columns.Select(c => new EntityColumnSort(c, SortDirection.Default)));
        }

        protected internal abstract void WriteTo(StringBuilder template, QueryStatement parent);
    }
}