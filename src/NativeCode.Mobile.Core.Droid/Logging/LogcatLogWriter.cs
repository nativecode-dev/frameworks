namespace NativeCode.Mobile.Core.Droid.Logging
{
    using Android.Util;

    using NativeCode.Core.Logging;

    public class LogcatLogWriter : LogWriter
    {
        public override void Flush()
        {
        }

        public override void Write(LogMessage message)
        {
            var text = message.ToString();
            var tag = message.MessageType.ToString();

            switch (message.MessageType)
            {
                case LogMessageType.Debug:
                    Log.Debug(tag, text);
                    break;

                case LogMessageType.Error:
                    Log.Error(tag, text);
                    break;

                case LogMessageType.Exception:
                    Log.Error(tag, text);
                    break;

                case LogMessageType.Warning:
                    Log.Warn(tag, text);
                    break;

                default:
                    Log.Info(tag, text);
                    break;
            }
        }
    }
}