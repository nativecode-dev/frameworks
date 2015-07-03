namespace Tests
{
    public abstract class TestingWithDatabase : Testing
    {
        protected DatabaseInstance Database { get; private set; }

        protected override void DoClassInitialize()
        {
            this.Database = new DatabaseInstance(this.TestContext);
        }

        protected override void DoCleanup()
        {
            this.Database.Dispose();
        }
    }
}