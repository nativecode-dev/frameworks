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
                if (Type.GetType("Mono.Runtime") != null)
                {
                    Console.WriteLine("Reading expect file {0} on Mono CLR.", key);
                    return reader.ReadToEnd().Replace("\n", "\r\n");
                }

                Console.WriteLine("Reading expect file {0} on .NET CLR.", key);
                return reader.ReadToEnd();
            }
        }
    }
}