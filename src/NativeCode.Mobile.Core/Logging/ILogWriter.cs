namespace NativeCode.Mobile.Core.Logging
{
    using System;

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
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Write(LogMessage message);
    }
}