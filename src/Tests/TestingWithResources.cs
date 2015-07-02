namespace Tests
{
    using System.IO;

    using Tests.Sqlite.QueryBuilder;

    public abstract class TestingWithResources : Testing
    {
        protected static string Expect(string key)
        {
            var assembly = typeof(WhenBuildingQuery).Assembly;

            // ReSharper disable once AssignNullToNotNullAttribute
            using (var reader = new StreamReader(assembly.GetManifestResourceStream(key)))
            {
                return reader.ReadToEnd();
            }
        }
    }
}