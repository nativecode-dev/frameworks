namespace Tests
{
    using System.Runtime.CompilerServices;

    public abstract class TestingWithDatabaseIsolation : Testing
    {
        protected virtual DatabaseInstance CreateDatabase([CallerMemberName] string testname = null)
        {
            var database = new DatabaseInstance(testname);
            this.Dispose(database);

            return database;
        }
    }
}