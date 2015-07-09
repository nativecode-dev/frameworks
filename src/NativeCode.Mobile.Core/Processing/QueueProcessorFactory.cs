namespace NativeCode.Mobile.Core.Processing
{
    using System;

    using NativeCode.Core.Dependencies;
    using NativeCode.Mobile.Core.Collections;

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

        public IQueueProcessor<T> CreateConcurrentQueueProcessor<T>(Action<T> processor)
        {
            return new ConcurrentQueueProcessor<T>(processor, this.collectionFactory);
        }

        public IQueueProcessor<T> CreateSerialQueueProcessor<T>(Action<T> processor)
        {
            return new SerialQueueProcessor<T>(processor);
        }
    }
}