namespace Tests
{
    using System;
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
                if (Environment.NewLine == "\n")
                {
                    Console.WriteLine("Reading expect file {0} on Linux.", key);
                    return reader.ReadToEnd().Replace("\r", string.Empty);
                }

                Console.WriteLine("Reading expect file {0} on Windows.", key);
                return reader.ReadToEnd();
            }
        }
    }
}