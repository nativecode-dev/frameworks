namespace NativeCode.Core.Processing
{
    using System;
    using System.Threading.Tasks;

    using NativeCode.Core.Collections;
    using NativeCode.Core.Dependencies;

    public class QueueProcessorFactory : IQueueProcessorFactory
    {
        private readonly ICollectionFactory collectionFactory;

        public QueueProcessorFactory()
        {
            this.collectionFactory = DependencyResolver.Current.Resolve<ICollectionFactory>();
        }

        public QueueProcessorFactory(ICollectionFactory collectionFactory)
        {
            this.collectionFactory = collectionFactory;
        }

        public IQueueProcessor<T> CreateConcurrentQueueProcessor<T>(Func<T, Task<T>> processor, int concurrency)
        {
            return new ConcurrentQueueProcessor<T>(processor, this.collectionFactory, concurrency);
        }

        public IQueueProcessor<T> CreateSerialQueueProcessor<T>(Func<T, Task<T>> processor)
        {
            return new SerialQueueProcessor<T>(processor);
        }
    }
}