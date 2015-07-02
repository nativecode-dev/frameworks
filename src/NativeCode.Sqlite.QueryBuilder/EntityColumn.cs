namespace NativeCode.Sqlite.QueryBuilder
{
    using System.Reflection;

    using NativeCode.Sqlite.QueryBuilder.Attributes;
    using NativeCode.Sqlite.QueryBuilder.Converters;

    using SQLite.Net.Attributes;

    public class EntityColumn
    {
        public EntityColumn(EntityTable table, PropertyInfo property)
        {
            this.Property = property;
            this.Table = table;

            this.SetupProperties();
        }

        public string Alias { get; private set; }

        public IQueryValueConverter Converter { get; set; }

        public object DefaultValue { get; private set; }

        public int? IndexOrder { get; private set; }

        public bool IsAutoIncrementing { get; private set; }

        public bool IsIgnored { get; private set; }

        public bool IsIndexed { get; private set; }

        public bool IsPrimaryKey { get; private set; }

        public bool IsQuotable { get; private set; }

        public bool IsReadOnly { get; private set; }

        public bool IsUnique { get; private set; }

        public bool IsSorted { get; private set; }

        public string Name { get; private set; }

        public string PropertyName
        {
            get { return this.Property.Name; }
        }

        public SortDirection SortDirection { get; private set; }

        public int? SortPriority { get; private set; }

        public EntityTable Table { get; private set; }

        public bool UseDefaultValue { get; private set; }

        protected PropertyInfo Property { get; private set; }

        private string GetColumnName()
        {
            var attribute = this.Property.GetCustomAttribute<ColumnAttribute>();

            if (attribute != null && attribute.Name != null)
            {
                return attribute.Name;
            }

            return this.Property.Name;
        }

        private void SetupProperties()
        {
            this.Alias = this.PropertyName;
            this.Name = this.GetColumnName();

            var defaultAttribute = this.Property.GetCustomAttribute<DefaultAttribute>();
            var indexAttribute = this.Property.GetCustomAttribute<IndexedAttribute>();
            var sortAttribute = this.Property.GetCustomAttribute<SortAttribute>();

            this.DefaultValue = defaultAttribute != null ? defaultAttribute.Value : null;
            this.IndexOrder = indexAttribute != null ? indexAttribute.Order : default(int?);
            this.IsAutoIncrementing = this.Property.GetCustomAttribute<AutoIncrementAttribute>() != null;
            this.IsIgnored = this.Property.GetCustomAttribute<IgnoreAttribute>() != null;
            this.IsIndexed = indexAttribute != null;
            this.IsPrimaryKey = this.Property.GetCustomAttribute<PrimaryKeyAttribute>() != null;
            this.IsQuotable = !this.Property.PropertyType.GetTypeInfo().IsValueType;
            this.IsReadOnly = !this.Property.CanWrite;
            this.IsSorted = sortAttribute != null;
            this.IsUnique = indexAttribute != null && indexAttribute.Unique;
            this.SortDirection = sortAttribute != null ? sortAttribute.Direction : SortDirection.Default;
            this.SortPriority = sortAttribute != null ? sortAttribute.Priority : default(int?);
            this.UseDefaultValue = defaultAttribute != null && defaultAttribute.UseProperty;
        }
    }
}