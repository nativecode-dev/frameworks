namespace NativeCode.Sqlite.QueryBuilder.Attributes
{
    using System;
    using System.Linq;

    using NativeCode.Sqlite.QueryBuilder.Converters;

    public sealed class ConvertAttribute : Attribute
    {
        public ConvertAttribute(Type type)
        {
            this.Type = type;
        }

        public Type Type { get; private set; }

        public IQueryValueConverter GetConverter()
        {
            return QueryBuilderConfiguration.Current.Converters.FirstOrDefault(x => x.CanConvert(this.Type));
        }
    }
}