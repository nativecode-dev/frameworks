namespace NativeCode.Mobile.Core.Collections
{
    /// <summary>
    /// Provides a contract to provide a concurrent queue.
    /// </summary>
    /// <typeparam name="T">The type of the item.</typeparam>
    public interface IConcurrentQueue<T>
    {
        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Enqueues the item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Enqueue(T item);

        /// <summary>
        /// Tries to de-queue an item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if queued item was de-queued, <c>false</c> otherwise.</returns>
        bool TryDequeue(out T item);

        /// <summary>
        /// Tries to peek at the next queued item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if queued item was peeked, <c>false</c> otherwise.</returns>
        bool TryPeek(out T item);
    }
}