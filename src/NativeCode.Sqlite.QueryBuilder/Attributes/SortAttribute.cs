namespace NativeCode.Sqlite.QueryBuilder.Attributes
{
    using System;

    public sealed class SortAttribute : Attribute
    {
        public SortAttribute(SortDirection direction = SortDirection.Default, int? priority = default(int?))
        {
            this.Direction = direction;
            this.Priority = priority;
        }

        public SortDirection Direction { get; private set; }

        public int? Priority { get; private set; }
    }
}