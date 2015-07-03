namespace NativeCode.Sqlite.QueryBuilder
{
    using System.Collections.Generic;

    using NativeCode.Sqlite.QueryBuilder.Attributes;

    internal interface IQueryBuilder
    {
        IReadOnlyList<EntityColumnFilter> Filterables { get; }

        EntityTable RootTable { get; }

        IReadOnlyList<EntityColumn> Selectables { get; }

        IReadOnlyList<EntityColumnSort> Sortables { get; }

        void Filter(EntityColumn column, FilterCondition condition = FilterCondition.Default, FilterComparison comparison = FilterComparison.Default);

        void Filter(IEnumerable<EntityColumn> columns, FilterCondition condition = FilterCondition.Default, FilterComparison comparison = FilterComparison.Default);

        void Select(EntityColumn column);

        void Select(IEnumerable<EntityColumn> columns);

        void Sort(EntityColumn column, SortDirection direction = SortDirection.Default);

        void Sort(IEnumerable<EntityColumn> columns, SortDirection direction = SortDirection.Default);
    }
}