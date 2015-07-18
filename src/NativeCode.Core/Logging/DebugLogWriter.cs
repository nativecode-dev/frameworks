namespace NativeCode.Core.Logging
{
    using System.Diagnostics;
    using System.Threading;

    public class DebugLogWriter : LogWriter
    {
        public override void Write(LogMessage message)
        {
            Debug.WriteLine(message.Stringify(true));
        }

        protected override void DoFlush(CancellationToken cancellationToken)
        {
        }
    }
}