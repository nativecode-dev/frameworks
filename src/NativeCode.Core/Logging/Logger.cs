namespace NativeCode.Core.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using NativeCode.Core.Extensions;
    using NativeCode.Core.Serialization;

    using Nito.AsyncEx;

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
            this.WriteLogMessage(message, LogSeverity.Debug, callerFilePath, callerLineNumber, callerMemberName);
        }

        public void DebugObject<T>(T instance, string callerFilePath = null, int callerLineNumber = 0, string callerMemberName = null)
        {
            var content = this.serializer.Serialize(instance);
            this.WriteLogMessage(content, LogSeverity.Debug, callerFilePath, callerLineNumber, callerMemberName);
        }

        public void Error(string message, string callerFilePath = null, int callerLineNumber = 0, string callerMemberName = null)
        {
            this.WriteLogMessage(message, LogSeverity.Error, callerFilePath, callerLineNumber, callerMemberName);
        }

        public void Exception<TException>(TException exception, string callerFilePath = null, int callerLineNumber = 0, string callerMemberName = null)
            where TException : Exception
        {
            var message = exception.Stringify();

            this.WriteLogMessage(message, LogSeverity.Exception, callerFilePath, callerLineNumber, callerMemberName);
        }

        public void Flush()
        {
            AsyncContext.Run(async () => await this.FlushAsync(CancellationToken.None).ConfigureAwait(false));
        }

        public Task FlushAsync(CancellationToken cancellationToken)
        {
            return Task.WhenAll(this.writers.Select(w => w.FlushAsync(cancellationToken)));
        }

        public void Informational(string message, string callerFilePath = null, int callerLineNumber = 0, string callerMemberName = null)
        {
            this.WriteLogMessage(message, LogSeverity.Informational, callerFilePath, callerLineNumber, callerMemberName);
        }

        public void Trace(string callerFilePath = null, int callerLineNumber = 0, string callerMemberName = null)
        {
            this.WriteLogMessage(string.Empty, LogSeverity.Trace, callerFilePath, callerLineNumber, callerMemberName);
        }

        public void Warning(string message, string callerFilePath = null, int callerLineNumber = 0, string callerMemberName = null)
        {
            this.WriteLogMessage(message, LogSeverity.Warning, callerFilePath, callerLineNumber, callerMemberName);
        }

        private void WriteLogMessage(string message, LogSeverity severity, string callerFilePath, int callerLineNumber, string callerMemberName)
        {
            if (severity < CoreConfiguration.DefaultLogLevel)
            {
                return;
            }

            var logMessage = new LogMessage
            {
                CallerFilePath = callerFilePath,
                CallerLineNumber = callerLineNumber,
                CallerMemberName = callerMemberName,
                Message = message,
                MessageDateTime = DateTime.UtcNow,
                Severity = severity
            };

            foreach (var writer in this.writers)
            {
                writer.Write(logMessage);
            }
        }
    }
}