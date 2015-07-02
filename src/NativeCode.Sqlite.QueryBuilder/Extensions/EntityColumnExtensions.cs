namespace NativeCode.Sqlite.QueryBuilder.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class EntityColumnExtensions
    {
        public static string Join(this IEnumerable<string> columns)
        {
            return string.Join(", ", columns);
        }

        public static string Join(this IEnumerable<EntityColumn> columns)
        {
            return columns.Select(c => c.GetName()).Join();
        }

        public static string Tokenize(this EntityColumn column)
        {
            return column.PropertyName.Tokenize();
        }

        public static string GetName(this EntityColumn column)
        {
            return column.GetName(true);
        }

        public static string GetName(this EntityColumn column, bool allowAlias)
        {
            var name = column.Name;

            if (QueryBuilderConfiguration.Current.QualifyColumnNames)
            {
                name = name.QualifyString();
            }

            if (QueryBuilderConfiguration.Current.QualifyTableNames)
            {
                name = column.Table.Alias.QualifyString() + "." + name;
            }

            if (QueryBuilderConfiguration.Current.UseColumnAlias && allowAlias)
            {
                name += " AS " + column.Alias.QualifyString();
            }

            return name;
        }

        public static string GetValue(this EntityColumn column)
        {
            var value = column.Tokenize();

            if (column.IsQuotable)
            {
                value = value.QuoteString();
            }

            return value;
        }
    }
}