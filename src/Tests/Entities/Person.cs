namespace NativeCode.Sqlite.QueryBuilder.Tests.Entities
{
    using SQLite.Net.Attributes;

    [Table("people")]
    public class Person
    {
        [AutoIncrement]
        [PrimaryKey]
        [Column("id")]
        public int? Id { get; protected set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }
    }
}