namespace NativeCode.Sqlite.QueryBuilder.Extensions
{
    public static class EntityTableExtensions
    {
        public static string GetName(this EntityTable table)
        {
            var name = table.Name;
            var alias = QueryBuilderConfiguration.Current.UseTableAlias;
            var qualify = QueryBuilderConfiguration.Current.QualifyTableNames;

            if (qualify)
            {
                name = name.QualifyString();
            }

            if (!alias)
            {
                return name;
            }

            if (qualify)
            {
                name += " AS " + table.Alias.QualifyString();
            }
            else
            {
                name += " AS " + table.Alias;
            }

            return name;
        }
    }
}