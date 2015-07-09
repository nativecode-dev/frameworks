namespace NativeCode.Mobile.Core.Droid.Logging
{
    using System.Threading;

    using Android.Util;

    using NativeCode.Core.Logging;

    public class LogcatLogWriter : LogWriter
    {
        public override void Write(LogMessage message)
        {
            var text = message.ToString();
            var tag = message.Severity.ToString();

            switch (message.Severity)
            {
                case LogSeverity.Debug:
                    Log.Debug(tag, text);
                    break;

                case LogSeverity.Error:
                    Log.Error(tag, text);
                    break;

                case LogSeverity.Exception:
                    Log.Error(tag, text);
                    break;

                case LogSeverity.Warning:
                    Log.Warn(tag, text);
                    break;

                default:
                    Log.Info(tag, text);
                    break;
            }
        }

        protected override void DoFlush(CancellationToken cancellationToken)
        {
        }
    }
}