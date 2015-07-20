namespace NativeCode.Core.Processing
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides a contract to create various <see cref="QueueProcessor{T}" /> implementations.
    /// </summary>
    public interface IQueueProcessorFactory
    {
        /// <summary>
        /// Creates a concurrent queue processor.
        /// </summary>
        /// <typeparam name="T">The type of item to process.</typeparam>
        /// <param name="processor">The processor.</param>
        /// <param name="concurrency">The concurrency.</param>
        /// <returns>Returns a new <see cref="IQueueProcessor{T}" />.</returns>
        IQueueProcessor<T> CreateConcurrentQueueProcessor<T>(Func<T, Task<T>> processor, int concurrency);

        /// <summary>
        /// Creates a serial queue processor.
        /// </summary>
        /// <typeparam name="T">The type of item to process.</typeparam>
        /// <param name="processor">The processor.</param>
        /// <returns>Returns a new <see cref="IQueueProcessor{T}" />.</returns>
        IQueueProcessor<T> CreateSerialQueueProcessor<T>(Func<T, Task<T>> processor);
    }
}