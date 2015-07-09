namespace NativeCode.Core.Logging
{
    using System;
    using System.Collections.Generic;

    using NativeCode.Core.Extensions;
    using NativeCode.Core.Serialization;

    public class Logger : ILogger
    {
        private readonly IStringSerializer serializer;

        private readonly IEnumerable<ILogWriter> writers;

        public Logger(IStringSerializer serializer, IEnumerable<ILogWriter> writers)
        {
            this.serializer = serializer;
            this.writers = writers;
        }

        public void Debug(string message, string callerFilePath = null, int callerLineNumber = 0, string callerMemberName = null)
        {
            this.WriteLogMessage(message, LogMessageType.Debug, callerFilePath, callerLineNumber, callerMemberName);
        }

        public void DebugObject<T>(T instance, string callerFilePath = null, int callerLineNumber = 0, string callerMemberName = null)
        {
            var content = this.serializer.Serialize(instance);
            this.WriteLogMessage(content, LogMessageType.Debug, callerFilePath, callerLineNumber, callerMemberName);
        }

        public void Error(string message, string callerFilePath = null, int callerLineNumber = 0, string callerMemberName = null)
        {
            this.WriteLogMessage(message, LogMessageType.Error, callerFilePath, callerLineNumber, callerMemberName);
        }

        public void Exception<TException>(TException exception, string callerFilePath = null, int callerLineNumber = 0, string callerMemberName = null)
            where TException : Exception
        {
            var message = exception.ToExceptionString();

            this.WriteLogMessage(message, LogMessageType.Exception, callerFilePath, callerLineNumber, callerMemberName);
        }

        public void Flush()
        {
            foreach (var writer in this.writers)
            {
                writer.Flush();
            }
        }

        public void Informational(string message, string callerFilePath = null, int callerLineNumber = 0, string callerMemberName = null)
        {
            this.WriteLogMessage(message, LogMessageType.Informational, callerFilePath, callerLineNumber, callerMemberName);
        }

        public void Warning(string message, string callerFilePath = null, int callerLineNumber = 0, string callerMemberName = null)
        {
            this.WriteLogMessage(message, LogMessageType.Warning, callerFilePath, callerLineNumber, callerMemberName);
        }

        private void WriteLogMessage(string message, LogMessageType messageType, string callerFilePath, int callerLineNumber, string callerMemberName)
        {
            var logMessage = new LogMessage
                                 {
                                     CallerFilePath = callerFilePath,
                                     CallerLineNumber = callerLineNumber,
                                     CallerMemberName = callerMemberName,
                                     GarbageCollectorMemory = GC.GetTotalMemory(false),
                                     Message = message,
                                     MessageDateTime = DateTime.UtcNow,
                                     MessageType = messageType
                                 };

            foreach (var writer in this.writers)
            {
                writer.Write(logMessage);
            }
        }
    }
}