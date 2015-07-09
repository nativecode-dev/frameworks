namespace NativeCode.Core.Logging
{
    /// <summary>
    /// Enumeration of log message types.
    /// </summary>
    public enum LogSeverity
    {
        /// <summary>
        /// Indicates the log message is default.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Indicates the log message is for tracing.
        /// </summary>
        Trace = 1,

        /// <summary>
        /// Indicates that the log message is for debugging.
        /// </summary>
        Debug = 2,

        /// <summary>
        /// Indicates that the log message is a warning.
        /// </summary>
        Warning = 3,

        /// <summary>
        /// Indicates that the log message is an error.
        /// </summary>
        Error = 4,

        /// <summary>
        /// Indicates that the log message is an exception.
        /// </summary>
        Exception = 5,

        /// <summary>
        /// Indicates that the log message is informational.
        /// </summary>
        Informational = Default
    }
}