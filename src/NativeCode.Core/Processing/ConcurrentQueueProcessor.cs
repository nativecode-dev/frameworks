namespace NativeCode.Core.Processing
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    using NativeCode.Core.Collections;

    internal class ConcurrentQueueProcessor<T> : QueueProcessor<T>
    {
        private readonly IConcurrentQueue<T> queue;

        private readonly SemaphoreSlim semaphore;

        internal ConcurrentQueueProcessor(Func<T, Task<T>> processor, ICollectionFactory collectionFactory, int concurrency) : base(processor)
        {
            this.queue = collectionFactory.CreateQueue<T>();
            this.semaphore = new SemaphoreSlim(concurrency);
        }

        public event EventHandler<EventArgs<T>> ItemDequeued;

        public event EventHandler<EventArgs<T>> ItemEnqueued;

        public override int Queued
        {
            get { return this.queue.Count; }
        }

        public override void Enqueue(T item)
        {
            this.queue.Enqueue(item);
            this.HandleItemEnqueue(item);
            this.StartProcessing();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.semaphore.Dispose();
            }

            base.Dispose(disposing);
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

        protected override async Task ProcessQueueItemsAsync(CancellationToken cancellationToken)
        {
            var workers = new List<Task>();

            while (!this.queue.IsEmpty)
            {
                await this.semaphore.WaitAsync(cancellationToken);

                T item;

                if (this.queue.TryDequeue(out item))
                {
                    this.HandleItemDequeued(item);
                    workers.Add(this.CreateProcessingTaskAsync(item));
                }
            }

            await Task.WhenAll(workers).ConfigureAwait(false);
        }

        private Task CreateProcessingTaskAsync(T item)
        {
            return Task.Run(async () => await this.ProcessItemAsync(item));
        }

        private async Task ProcessItemAsync(T item)
        {
            try
            {
                this.HandleItemProcessing(item);
                var result = await this.AsyncProcessor(item).ConfigureAwait(false);
                this.HandleItemProcessed(result);
            }
            catch
            {
                this.HandleItemProcessingFailed(item);
            }
            finally
            {
                this.semaphore.Release();
            }
        }
    }
}