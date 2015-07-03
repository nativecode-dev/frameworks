namespace NativeCode.Sqlite.QueryBuilder
{
    using NativeCode.Sqlite.QueryBuilder.Attributes;

    internal class EntityColumnSort
    {
        internal EntityColumnSort(EntityColumn column, SortDirection direction)
        {
            this.Column = column;
            this.Direction = direction;
        }

        public EntityColumn Column { get; private set; }

        public SortDirection Direction { get; private set; }
    }
}