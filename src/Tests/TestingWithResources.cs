namespace NativeCode.Sqlite.QueryBuilder.Tests
{
    using System.IO;

    using NativeCode.Sqlite.QueryBuilder.Tests.Sqlite.QueryBuilder;

    public abstract class TestingWithResources
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