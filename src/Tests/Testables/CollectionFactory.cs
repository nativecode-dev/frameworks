namespace Tests.Testables
{
    using System;
    using System.Collections.Concurrent;

    using NativeCode.Core.Collections;

    public class CollectionFactory : ICollectionFactory
    {
        public int DefaultConcurrency
        {
            get { return Environment.ProcessorCount; }
        }

        public IConcurrentDictionary<TKey, TValue> CreateDictionary<TKey, TValue>()
        {
            return new ConcurrentDictionaryAdapter<TKey, TValue>();
        }

        public IConcurrentQueue<T> CreateQueue<T>()
        {
            return new ConcurrentQueueAdapter<T>();
        }

        private class ConcurrentDictionaryAdapter<TKey, TValue> : ConcurrentDictionary<TKey, TValue>, IConcurrentDictionary<TKey, TValue>
        {
        }

        private class ConcurrentQueueAdapter<T> : ConcurrentQueue<T>, IConcurrentQueue<T>
        {
        }
    }
}