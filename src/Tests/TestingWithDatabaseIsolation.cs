namespace Tests
{
    using System.Runtime.CompilerServices;

    public abstract class TestingWithDatabaseIsolation : Testing
    {
        protected virtual DatabaseInstance CreateDatabase([CallerMemberName] string testname = null)
        {
            var database = new DatabaseInstance(this.TestContext, testname);
            this.Dispose(database);

            return database;
        }
    }
}