namespace NativeCode.Sqlite.QueryBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using SQLite.Net.Attributes;

    public class EntityTable
    {
        private readonly List<EntityColumn> columns;

        public EntityTable(Type type)
        {
            this.Type = type;

            var properties = type.GetRuntimeProperties().ToList();
            this.columns = new List<EntityColumn>(properties.Count);

            foreach (var property in properties)
            {
                this.columns.Add(new EntityColumn(this, property));
            }

            this.Alias = this.TypeName;
            this.Name = this.GetTableName();
        }

        public string Alias { get; private set; }

        public IReadOnlyList<EntityColumn> Columns
        {
            get { return this.columns; }
        }

        public string Name { get; private set; }

        public string TypeName
        {
            get { return this.Type.Name; }
        }

        protected Type Type { get; private set; }

        public EntityColumn this[string key]
        {
            get { return this.Columns.Single(c => c.PropertyName == key); }
        }

        public IEnumerable<EntityColumn> GetAllColumns()
        {
            return from column in this.Columns select column;
        }

        public IEnumerable<EntityColumn> GetCompositeKeys()
        {
            return from column in this.Columns where column.IsPrimaryKey select column;
        }

        public IEnumerable<EntityColumn> GetIndexedColumns()
        {
            return from column in this.Columns where column.IsIndexed orderby column.IndexOrder select column;
        }

        public EntityColumn GetPrimaryKey()
        {
            try
            {
                return this.Columns.Single(c => c.IsPrimaryKey);
            }
            catch (Exception ex)
            {
                // TODO: Replace with a more meaningful exception.
                throw new InvalidOperationException("More than one primary key exists.", ex);
            }
        }

        public IEnumerable<EntityColumn> GetSortedColumns()
        {
            return from column in this.Columns where column.IsSorted orderby column.SortPriority orderby column.Name select column;
        }

        public IEnumerable<EntityColumn> GetMutableColumns()
        {
            return this.Columns.Where(column => !column.IsPrimaryKey && !column.IsIgnored && !column.IsReadOnly && !column.UseDefaultValue);
        }

        public bool HasCompositeKeys()
        {
            return this.Columns.Count(c => c.IsPrimaryKey) > 1;
        }

        public bool IsIndexed()
        {
            return this.Columns.Any(c => c.IsIndexed);
        }

        public bool IsSorted()
        {
            return this.Columns.Any(c => c.IsSorted);
        }

        private string GetTableName()
        {
            var attribute = this.Type.GetTypeInfo().GetCustomAttribute<TableAttribute>();

            if (attribute != null && attribute.Name != null)
            {
                return attribute.Name;
            }

            return this.Type.Name;
        }
    }
}