namespace NativeCode.Mobile.Core.Logging
{
    using System;

    public abstract class LogWriter : ILogWriter
    {
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract void Flush();

        public abstract void Write(LogMessage message);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Flush();
            }
        }
    }
}