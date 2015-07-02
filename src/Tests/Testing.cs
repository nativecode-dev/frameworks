namespace Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    public abstract class Testing : IDisposable
    {
        private readonly List<IDisposable> disposables = new List<IDisposable>();

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            this.DoFixtureSetUp();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            this.DoFixtureTearDown();
        }

        [SetUp]
        public void TestSetUp()
        {
            this.DoTestSetUp();
        }

        [TearDown]
        public void TestTearDown()
        {
            this.DoTestTearDown();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(IDisposable disposable)
        {
            this.disposables.Add(disposable);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var disposable in this.disposables)
                {
                    disposable.Dispose();
                }

                this.disposables.Clear();
            }
        }

        protected virtual void DoFixtureSetUp()
        {
        }

        protected virtual void DoFixtureTearDown()
        {
        }

        protected virtual void DoTestSetUp()
        {
        }

        protected virtual void DoTestTearDown()
        {
        }
    }
}