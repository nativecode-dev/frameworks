namespace Tests
{
    using NativeCode.Sqlite.QueryBuilder;

    using Tests.Entities;

    public static class TestQueries
    {
        public static readonly QueryTemplate InsertPerson;

        public static readonly QueryTemplate SelectPerson;

        static TestQueries()
        {
            InsertPerson = QueryBuilder.From<Person>().Insert(p => p.GetMutableColumns()).BuildTemplate();
            SelectPerson = QueryBuilder.From<Person>().Select(p => p.GetAllColumns()).Where(p => p.GetPrimaryKey()).BuildTemplate();
        }
    }
}