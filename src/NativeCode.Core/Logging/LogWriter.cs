namespace NativeCode.Core.Logging
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Nito.AsyncEx;

    public abstract class LogWriter : ILogWriter
    {
        protected LogWriter()
        {
            this.AutoFlush = CoreConfiguration.DefaultAutoFlush;
            this.AutoFlushCount = CoreConfiguration.DefaultAutoFlushCount;
        }

        protected bool AutoFlush { get; private set; }

        protected int AutoFlushCount { get; private set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Flush()
        {
            AsyncContext.Run(() => this.DoFlush(CancellationToken.None));
        }

        public Task FlushAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() => this.DoFlush(cancellationToken), cancellationToken);
        }

        public abstract void Write(LogMessage message);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Flush();
            }
        }

        protected abstract void DoFlush(CancellationToken cancellationToken);
    }
}