namespace NativeCode.Mobile.Core.Collections
{
    /// <summary>
    /// Provides a contract to create concurrent collections.
    /// </summary>
    public interface ICollectionFactory
    {
        /// <summary>
        /// Gets the default concurrency.
        /// </summary>
        int DefaultConcurrency { get; }

        /// <summary>
        /// Creates a dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <returns>Returns a dictionary.</returns>
        IConcurrentDictionary<TKey, TValue> CreateDictionary<TKey, TValue>();

        /// <summary>
        /// Creates a queue.
        /// </summary>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <returns>Returns a queue.</returns>
        IConcurrentQueue<T> CreateQueue<T>();
    }
}