namespace NativeCode.Core.Processing
{
    /// <summary>
    /// Provides a contract to process a queue of items.
    /// </summary>
    /// <typeparam name="T">The type of the item to be queued and processed.</typeparam>
    public interface IQueueProcessor<in T>
    {
        /// <summary>
        /// Gets the number of queued items.
        /// </summary>
        int Queued { get; }

        /// <summary>
        /// Gets the number of running items.
        /// </summary>
        int Running { get; }

        /// <summary>
        /// Cancels processing further queue items. Currently executing items will be cancelled as well.
        /// </summary>
        void Cancel();

        /// <summary>
        /// Enqueues the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Enqueue(T item);
    }
}