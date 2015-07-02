namespace Tests.Entities
{
    using NativeCode.Sqlite.QueryBuilder.Attributes;

    using SQLite.Net.Attributes;

    public class PersonLocation
    {
        [PrimaryKey]
        [ForeignType(typeof(Location))]
        public int LocationId { get; set; }

        [PrimaryKey]
        [ForeignType(typeof(Person))]
        public int PersonId { get; set; }
    }
}