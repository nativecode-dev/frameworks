namespace NativeCode.Sqlite.QueryBuilder
{
    using System;
    using System.Collections.Generic;

    internal static class QueryBuilderCache
    {
        private static readonly Dictionary<string, EntityTable> CachedTables = new Dictionary<string, EntityTable>();

        internal static EntityTable GetEntityTable(Type type)
        {
            var key = type.AssemblyQualifiedName;

            if (CachedTables.ContainsKey(key))
            {
                return CachedTables[key];
            }

            var table = new EntityTable(type);
            CachedTables.Add(key, table);

            return table;
        }

        internal static EntityTable GetEntityTable<T>()
        {
            return GetEntityTable(typeof(T));
        }
    }
}