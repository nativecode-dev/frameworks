namespace NativeCode.Sqlite.QueryBuilder
{
    public class EntityColumnFilter
    {
        internal EntityColumnFilter(EntityColumn column, string groupName, FilterCondition condition, FilterComparison comparison)
        {
            this.Column = column;
            this.Comparison = comparison;
            this.Condition = condition;
            this.GroupName = groupName;
        }

        public EntityColumn Column { get; private set; }

        public FilterComparison Comparison { get; private set; }

        public FilterCondition Condition { get; private set; }

        public string GroupName { get; private set; }
    }
}