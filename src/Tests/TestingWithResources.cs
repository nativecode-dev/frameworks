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
                var platform = (int)Environment.OSVersion.Platform;

                if ((platform == 4) || (platform == 6) || (platform == 128))
                {
                    Console.WriteLine("Reading expect file {0} on Linux.", key);
                    return reader.ReadToEnd().Replace("\n", "\r\n");
                }

                Console.WriteLine("Reading expect file {0} on Windows.", key);
                return reader.ReadToEnd();
            }
        }
    }
}