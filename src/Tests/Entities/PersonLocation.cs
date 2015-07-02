namespace Tests.Entities
{
    using NativeCode.Sqlite.QueryBuilder.Attributes;

    using SQLite.Net.Attributes;

    [Table("person_location")]
    public class PersonLocation
    {
        [Column("location_id")]
        [ForeignType(typeof(Location))]
        [Indexed]
        public string LocationId { get; set; }

        [Column("person_id")]
        [ForeignType(typeof(Person))]
        [Indexed]
        public int PersonId { get; set; }
    }
}