namespace NativeCode.Sqlite.QueryBuilder.Statements
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal abstract class QueryStatement
    {
        protected const string CloseParens = ")";

        protected const string OpenParens = "(";

        protected const string Space = " ";

        internal QueryStatement(IQueryBuilder builder, string keyword)
        {
            this.Builder = builder;
            this.Keyword = keyword;
        }

        public string Keyword { get; private set; }

        protected IQueryBuilder Builder { get; set; }

        public virtual bool CanBeginStatement(QueryStatement current)
        {
            return current == null;
        }

        protected internal abstract void Prepare(QueryBuilder builder, QueryStatement previous);

        protected internal abstract void WriteTo(StringBuilder template, QueryStatement root);

        protected IEnumerable<IGrouping<EntityTable, EntityColumnFilter>> GetFilterables()
        {
            return from filter in this.Builder.Filterables group filter by filter.Column.Table into table select table;
        }

        protected IEnumerable<IGrouping<EntityTable, EntityColumn>> GetSelectables()
        {
            return from column in this.Builder.Selectables group column by column.Table into table select table;
        }

        protected IEnumerable<IGrouping<EntityTable, EntityColumnSort>> GetSortables()
        {
            return from sort in this.Builder.Sortables group sort by sort.Column.Table into table select table;
        }
    }
}