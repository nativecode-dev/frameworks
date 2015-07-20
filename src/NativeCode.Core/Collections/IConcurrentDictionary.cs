namespace NativeCode.Core.Collections
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides a contract to provide a concurrent dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public interface IConcurrentDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        /// Adds or updates a key/value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="adder">The adder.</param>
        /// <param name="updater">The updater.</param>
        /// <returns>Returns a value.</returns>
        TValue AddOrUpdate(TKey key, Func<TKey, TValue> adder, Func<TKey, TValue, TValue> updater);

        /// <summary>
        /// Adds or updates a key/value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>Returns a value.</returns>
        TValue AddOrUpdate(TKey key, TValue value, Func<TKey, TValue, TValue> factory);

        /// <summary>
        /// Tries to add the key/value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if value added, <c>false</c> otherwise.</returns>
        bool TryAdd(TKey key, TValue value);

        /// <summary>
        /// Tries the remove.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if value removed, <c>false</c> otherwise.</returns>
        bool TryRemove(TKey key, out TValue value);

        /// <summary>
        /// Tries the update.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="comparison">The comparison.</param>
        /// <returns><c>true</c> if value updated, <c>false</c> otherwise.</returns>
        bool TryUpdate(TKey key, TValue value, TValue comparison);
    }
}