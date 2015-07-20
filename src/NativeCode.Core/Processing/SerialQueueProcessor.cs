namespace NativeCode.Core.Processing
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using NativeCode.Core;

    using Nito.AsyncEx;

    internal class SerialQueueProcessor<T> : QueueProcessor<T>
    {
        private readonly Queue<T> queue = new Queue<T>();

        internal SerialQueueProcessor(Func<T, Task<T>> processor) : base(processor)
        {
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

        protected override Task ProcessQueueItemsAsync(CancellationToken cancellationToken)
        {
            if (this.queue.Count == 0)
            {
                return TaskConstants.Completed;
            }

            do
            {
                var item = this.queue.Dequeue();

                this.HandleItemDequeued(item);

                try
                {
                    this.HandleItemProcessing(item);
                    this.AsyncProcessor(item);
                    this.HandleItemProcessed(item);
                }
                catch
                {
                    this.HandleItemProcessingFailed(item);
                }
            }
            while (this.queue.Count > 0);

            return TaskConstants.Completed;
        }
    }
}