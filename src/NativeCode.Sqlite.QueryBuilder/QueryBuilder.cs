namespace NativeCode.Sqlite.QueryBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NativeCode.Sqlite.QueryBuilder.Attributes;
    using NativeCode.Sqlite.QueryBuilder.Exceptions;
    using NativeCode.Sqlite.QueryBuilder.Statements;

    public class QueryBuilder : IQueryBuilder
    {
        private readonly List<EntityColumnFilter> filterables = new List<EntityColumnFilter>();

        private readonly Queue<QueryStatement> queue = new Queue<QueryStatement>();

        private readonly List<EntityColumn> selectables = new List<EntityColumn>();

        private readonly List<EntityColumnSort> sortables = new List<EntityColumnSort>();

        private readonly StringBuilder template = new StringBuilder(200);

        private QueryBuilder(EntityTable table)
        {
            this.RootTable = table;
        }

        public EntityTable RootTable { get; private set; }

        public IReadOnlyList<EntityColumnFilter> Filterables
        {
            get { return this.filterables; }
        }

        public IReadOnlyList<EntityColumn> Selectables
        {
            get { return this.selectables; }
        }

        public IReadOnlyList<EntityColumnSort> Sortables
        {
            get { return this.sortables; }
        }

        protected IQueryBuilder Builder
        {
            get { return this; }
        }

        protected QueryStatement CurrentStatement { get; private set; }

        public static QueryBuilder From<TEntity>() where TEntity : class
        {
            return From(QueryBuilderCache.GetEntityTable<TEntity>());
        }

        public static QueryBuilder From(EntityTable table)
        {
            return new QueryBuilder(table);
        }

        void IQueryBuilder.Filter(EntityColumn column, FilterCondition condition, FilterComparison comparison)
        {
            this.filterables.Add(new EntityColumnFilter(column, "Default", condition, comparison));
        }

        void IQueryBuilder.Filter(IEnumerable<EntityColumn> columns, FilterCondition condition, FilterComparison comparison)
        {
            foreach (var column in columns)
            {
                this.Builder.Filter(column, condition, comparison);
            }
        }

        void IQueryBuilder.Select(EntityColumn column)
        {
            this.selectables.Add(column);
        }

        void IQueryBuilder.Select(IEnumerable<EntityColumn> columns)
        {
            foreach (var column in columns)
            {
                this.Builder.Select(column);
            }
        }

        void IQueryBuilder.Sort(EntityColumn column, SortDirection direction)
        {
            this.sortables.Add(new EntityColumnSort(column, direction));
        }

        void IQueryBuilder.Sort(IEnumerable<EntityColumn> columns, SortDirection direction)
        {
            foreach (var column in columns)
            {
                this.Builder.Sort(column, direction);
            }
        }

        public QueryBuilder And(Func<EntityTable, EntityColumn> factory, FilterComparison comparison = FilterComparison.Equals)
        {
            this.Builder.Filter(factory(this.Builder.RootTable), comparison: comparison);

            return this;
        }

        public virtual QueryTemplate BuildTemplate()
        {
            var root = this.queue.First();
            var statements = new List<QueryStatement>();

            // Emtpy the queue and let each statement prepare
            // whatever it needs to before writing.
            while (this.queue.Any())
            {
                var statement = this.queue.Dequeue();
                statements.Add(statement);
                statement.Prepare(this, this.CurrentStatement);
                this.CurrentStatement = statement;
            }

            // Move forward through the statements and write
            // to the template.
            foreach (var statement in statements)
            {
                statement.WriteTo(this.template, root);
            }

            this.template.Append(";");

            return this.ParseQueryTemplate(this.template.ToString());
        }

        public QueryBuilder Delete()
        {
            this.BeginStatement(new DeleteStatement(this));

            return this;
        }

        public QueryBuilder Insert(Func<EntityTable, IEnumerable<EntityColumn>> factory)
        {
            this.BeginStatement(new InsertStatement(this));
            this.Builder.Select(factory(this.Builder.RootTable));

            return this;
        }

        public QueryBuilder Join<TEntity>(Func<EntityTable, EntityColumn> parent, Func<EntityTable, EntityColumn> child) where TEntity : class
        {
            var table = QueryBuilderCache.GetEntityTable<TEntity>();
            var left = parent(this.Builder.RootTable);
            var right = child(table);

            this.BeginStatement(new JoinStatement(this, left, right));

            return this;
        }

        public QueryBuilder JoinSelect<TEntity>(
            Func<EntityTable, EntityColumn> parent,
            Func<EntityTable, EntityColumn> child,
            Func<EntityTable, IEnumerable<EntityColumn>> select) where TEntity : class
        {
            var table = QueryBuilderCache.GetEntityTable<TEntity>();
            var left = parent(this.Builder.RootTable);
            var right = child(table);
            var columns = select(table);

            this.BeginStatement(new JoinStatement(this, left, right));
            this.Builder.Select(columns);

            return this;
        }

        public void Reset()
        {
            this.template.Clear();
        }

        public QueryBuilder Select(Func<EntityTable, IEnumerable<EntityColumn>> factory)
        {
            this.BeginStatement(new SelectStatement(this));
            this.Builder.Select(factory(this.Builder.RootTable));

            return this;
        }

        public QueryBuilder OrderBy(Func<EntityTable, EntityColumn> factory, SortDirection direction = SortDirection.Default)
        {
            this.BeginStatement(new OrderByStatement(this));
            this.Builder.Sort(factory(this.Builder.RootTable));

            return this;
        }

        public QueryBuilder OrderBy(Func<EntityTable, IEnumerable<EntityColumn>> factory)
        {
            this.BeginStatement(new OrderByStatement(this));
            this.Builder.Sort(factory(this.Builder.RootTable));

            return this;
        }

        public QueryBuilder Update(Func<EntityTable, IEnumerable<EntityColumn>> factory)
        {
            this.BeginStatement(new UpdateStatement(this));
            this.Builder.Select(factory(this.Builder.RootTable));

            return this;
        }

        public QueryBuilder Where<TEntity>(Func<EntityTable, EntityColumn> factory)
        {
            var table = QueryBuilderCache.GetEntityTable<TEntity>();
            this.BeginStatement(new WhereStatement(this));
            this.Builder.Filter(factory(table));

            return this;
        }

        public QueryBuilder Where(Func<EntityTable, EntityColumn> factory)
        {
            this.BeginStatement(new WhereStatement(this));
            this.Builder.Filter(factory(this.Builder.RootTable));

            return this;
        }

        public QueryBuilder Where(Func<EntityTable, IEnumerable<EntityColumn>> factory)
        {
            this.BeginStatement(new WhereStatement(this));
            this.Builder.Filter(factory(this.Builder.RootTable));

            return this;
        }

        protected QueryBuilder BeginStatement(QueryStatement statement)
        {
            if (statement.CanBeginStatement(this.CurrentStatement))
            {
                this.queue.Enqueue(statement);
                this.CurrentStatement = statement;

                return this;
            }

            throw new StatementException(this.CurrentStatement, statement);
        }

        protected QueryTemplate ParseQueryTemplate(string query)
        {
            return QueryTemplate.Parse(query);
        }
    }
}