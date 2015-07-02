namespace Tests
{
    public abstract class TestingWithDatabase : Testing
    {
        protected DatabaseInstance Database { get; private set; }

        protected override void DoFixtureSetUp()
        {
            this.Database = new DatabaseInstance();
        }

        protected override void DoTestTearDown()
        {
            this.Database.Dispose();
        }
    }
}