namespace NativeCode.Core
{
    using NativeCode.Core.Logging;

    public static class CoreConfiguration
    {
        static CoreConfiguration()
        {
            DefaultAutoFlush = true;
            DefaultAutoFlushCount = 100;
            DefaultLogLevel = LogSeverity.Error;
        }

        public static bool DefaultAutoFlush { get; set; }

        public static int DefaultAutoFlushCount { get; set; }

        public static LogSeverity DefaultLogLevel { get; set; }
    }
}