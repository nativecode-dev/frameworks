namespace NativeCode.Core.Logging
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides a contract to write a <see cref="LogMessage"/>.
    /// </summary>
    public interface ILogWriter : IDisposable
    {
        /// <summary>
        /// Flushes this instance.
        /// </summary>
        void Flush();

        /// <summary>
        /// Flushes this instance.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a <see cref="Task" />.</returns>
        Task FlushAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Write(LogMessage message);
    }
}