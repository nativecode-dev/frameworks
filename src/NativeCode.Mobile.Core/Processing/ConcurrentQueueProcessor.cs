namespace NativeCode.Mobile.Core.Processing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using NativeCode.Core;
    using NativeCode.Mobile.Core.Collections;

    internal class ConcurrentQueueProcessor<T> : QueueProcessor<T>
    {
        private readonly IConcurrentQueue<T> queue;

        internal ConcurrentQueueProcessor(Action<T> processor, ICollectionFactory collectionFactory)
            : base(processor)
        {
            this.queue = collectionFactory.CreateQueue<T>();
        }

        public event EventHandler<EventArgs<T>> ItemDequeued;

        public event EventHandler<EventArgs<T>> ItemEnqueued;

        public override void Enqueue(T item)
        {
            this.queue.Enqueue(item);
            this.HandleItemEnqueue(item);
            this.StartProcessing();
        }

        protected void HandleItemDequeued(T item)
        {
            var handler = this.ItemDequeued;

            if (handler != null)
            {
                handler(this, new EventArgs<T>(item));
            }
        }

        protected void HandleItemEnqueue(T item)
        {
            var handler = this.ItemEnqueued;

            if (handler != null)
            {
                handler(this, new EventArgs<T>(item));
            }
        }

        protected override void ProcessQueueItems()
        {
            var workers = new List<Task>();

            while (!this.queue.IsEmpty || workers.Any())
            {
                T item;

                if (this.queue.TryDequeue(out item))
                {
                    this.HandleItemDequeued(item);
                    workers.Add(this.ProcessQueueItemAsync(item));
                }
                else
                {
                    Task.Delay(TimeSpan.FromMilliseconds(100)).GetAwaiter().GetResult();
                }
            }
        }

        private Task ProcessQueueItemAsync(T item)
        {
            this.HandleItemProcessing(item);

            return Task.Run(() => this.Processor(item)).ContinueWith(x => this.CompleteProcessQueueItem(item, x));
        }

        private void CompleteProcessQueueItem(T item, Task x)
        {
            switch (x.Status)
            {
                case TaskStatus.Canceled:
                case TaskStatus.Faulted:
                    this.HandleItemProcessed(item);
                    break;

                default:
                    this.HandleItemProcessingFailed(item);
                    break;
            }
        }
    }
}