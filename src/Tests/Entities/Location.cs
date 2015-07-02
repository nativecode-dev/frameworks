namespace NativeCode.Sqlite.QueryBuilder.Tests.Entities
{
    using SQLite.Net.Attributes;

    public class Location
    {
        [PrimaryKey]
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}