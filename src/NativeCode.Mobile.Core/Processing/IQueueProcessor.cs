namespace NativeCode.Mobile.Core.Processing
{
    /// <summary>
    /// Provides a contract to process a queue of items.
    /// </summary>
    /// <typeparam name="T">The type of the item to be queued and processed.</typeparam>
    public interface IQueueProcessor<in T>
    {
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