namespace NativeCode.Sqlite.QueryBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NativeCode.Sqlite.QueryBuilder.Attributes;
    using NativeCode.Sqlite.QueryBuilder.Exceptions;
    using NativeCode.Sqlite.QueryBuilder.Statements;

    public class QueryBuilder
    {
        private readonly StringBuilder template = new StringBuilder(200);

        private readonly Queue<QueryStatement> statements = new Queue<QueryStatement>();

        private QueryBuilder(EntityTable table)
        {
            this.Table = table;
        }

        protected QueryStatement CurrentStatement { get; private set; }

        protected EntityTable Table { get; private set; }

        public static QueryBuilder From<TEntity>() where TEntity : class
        {
            return From(QueryBuilderCache.GetEntityTable<TEntity>());
        }

        public static QueryBuilder From(EntityTable table)
        {
            return new QueryBuilder(table);
        }

        public QueryBuilder And(Func<EntityTable, EntityColumn> factory, FilterComparison comparison = FilterComparison.Equals)
        {
            this.CurrentStatement.Filter(factory(this.Table), comparison: comparison);

            return this;
        }

        public virtual QueryTemplate BuildTemplate()
        {
            QueryStatement parent = this.statements.First();

            while (this.statements.Any())
            {
                var statement = this.statements.Dequeue();
                statement.WriteTo(this.template, parent);
            }

            this.template.Append(";");

            return this.ParseQueryTemplate(this.template.ToString());
        }

        public QueryBuilder Delete()
        {
            this.BeginStatement(new DeleteStatement(this.Table));

            return this;
        }

        public QueryBuilder Insert(Func<EntityTable, IEnumerable<EntityColumn>> factory)
        {
            this.BeginStatement(new InsertStatement(this.Table));
            this.CurrentStatement.Select(factory(this.Table));

            return this;
        }

        public void Reset()
        {
            this.template.Clear();
        }

        public QueryBuilder Select(Func<EntityTable, IEnumerable<EntityColumn>> factory)
        {
            this.BeginStatement(new SelectStatement(this.Table));
            this.CurrentStatement.Select(factory(this.Table));

            return this;
        }

        public QueryBuilder OrderBy(Func<EntityTable, EntityColumn> factory, SortDirection direction = SortDirection.Default)
        {
            this.BeginStatement(new OrderByStatement(this.Table));
            this.CurrentStatement.Sort(factory(this.Table), direction);

            return this;
        }

        public QueryBuilder OrderBy(Func<EntityTable, IEnumerable<EntityColumn>> factory)
        {
            this.BeginStatement(new OrderByStatement(this.Table));
            this.CurrentStatement.Sort(factory(this.Table));

            return this;
        }

        public QueryBuilder Update(Func<EntityTable, IEnumerable<EntityColumn>> factory)
        {
            this.BeginStatement(new UpdateStatement(this.Table));
            this.CurrentStatement.Select(factory(this.Table));

            return this;
        }

        public QueryBuilder Where(Func<EntityTable, EntityColumn> factory)
        {
            this.BeginStatement(new WhereStatement(this.Table));
            this.CurrentStatement.Filter(factory(this.Table));

            return this;
        }

        public QueryBuilder Where(Func<EntityTable, IEnumerable<EntityColumn>> factory)
        {
            this.BeginStatement(new WhereStatement(this.Table));
            this.CurrentStatement.Filter(factory(this.Table));

            return this;
        }

        protected QueryBuilder BeginStatement(QueryStatement statement)
        {
            if (statement.CanBeginStatement(this.CurrentStatement))
            {
                this.statements.Enqueue(statement);
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