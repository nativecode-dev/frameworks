namespace NativeCode.Mobile.Core.Processing
{
    using System;

    /// <summary>
    /// Provides a contract to create various <see cref="QueueProcessor{T}"/> implementations.
    /// </summary>
    public interface IQueueProcessorFactory
    {
        /// <summary>
        /// Creates a concurrent queue processor.
        /// </summary>
        /// <typeparam name="T">The type of item to process.</typeparam>
        /// <param name="processor">The processor.</param>
        /// <returns>Returns a new <see cref="IQueueProcessor{T}" />.</returns>
        IQueueProcessor<T> CreateConcurrentQueueProcessor<T>(Action<T> processor);

        /// <summary>
        /// Creates a serial queue processor.
        /// </summary>
        /// <typeparam name="T">The type of item to process.</typeparam>
        /// <param name="processor">The processor.</param>
        /// <returns>Returns a new <see cref="IQueueProcessor{T}" />.</returns>
        IQueueProcessor<T> CreateSerialQueueProcessor<T>(Action<T> processor);
    }
}