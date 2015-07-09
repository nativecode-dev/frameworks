using System;

namespace NativeCode.Core.Logging
{
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