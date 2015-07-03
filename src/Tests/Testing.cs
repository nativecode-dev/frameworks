namespace Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public abstract class Testing : IDisposable
    {
        private readonly List<IDisposable> disposables = new List<IDisposable>();

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public void ClassInitialize()
        {
            this.DoClassInitialize();
        }

        [ClassCleanup]
        public void ClassCleanup()
        {
            this.DoClassCleanup();
        }

        [TestInitialize]
        public void Initialize()
        {
            this.DoInitialize();
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.DoCleanup();
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

        protected virtual void DoClassInitialize()
        {
        }

        protected virtual void DoClassCleanup()
        {
        }

        protected virtual void DoInitialize()
        {
        }

        protected virtual void DoCleanup()
        {
        }
    }
}