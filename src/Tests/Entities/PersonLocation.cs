namespace Tests.Entities
{
    using NativeCode.Sqlite.QueryBuilder.Attributes;

    using SQLite.Net.Attributes;

    [Table("person_location")]
    public class PersonLocation
    {
        [Column("location_id")]
        [PrimaryKey]
        [ForeignType(typeof(Location))]
        public int LocationId { get; set; }

        [Column("person_id")]
        [PrimaryKey]
        [ForeignType(typeof(Person))]
        public int PersonId { get; set; }
    }
}