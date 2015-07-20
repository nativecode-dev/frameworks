namespace NativeCode.Core.Processing
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class QueueProcessor<T> : IDisposable, IQueueProcessor<T>
    {
        private QueueProcessorState state;

        private int running;

        protected QueueProcessor(Func<T, Task<T>> processor)
        {
            this.AsyncProcessor = processor;
        }

        public event EventHandler<EventArgs<T>> ItemProcessed;

        public event EventHandler<EventArgs<T>> ItemProcessing;

        public event EventHandler<EventArgs<T>> ItemProcessingFailed;

        public event EventHandler<QueueProcessorStateEventArgs> StateChanged;

        public QueueProcessorState State
        {
            get { return this.state; }

            private set
            {
                if (this.state != value)
                {
                    this.state = value;
                    this.HandleStateChanged(this.state);
                }
            }
        }

        public abstract int Queued { get; }

        public int Running
        {
            get { return this.running; }
        }

        public Task QueueProcessorTask { get; private set; }

        protected Func<T, Task<T>> AsyncProcessor { get; private set; }

        protected CancellationTokenSource CancellationTokenSource { get; private set; }

        public void Cancel()
        {
            if (this.CancellationTokenSource != null)
            {
                try
                {
                    this.CancellationTokenSource.Cancel();
                    this.CancellationTokenSource.Dispose();
                }
                finally
                {
                    this.CancellationTokenSource = null;
                    this.QueueProcessorTask = null;
                }
            }
        }

        public abstract void Enqueue(T item);

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Cancel();
            }
        }

        protected void HandleItemProcessed(T item)
        {
            Interlocked.Decrement(ref this.running);

            var handler = this.ItemProcessed;

            if (handler != null)
            {
                handler(this, new EventArgs<T>(item));
            }
        }

        protected void HandleItemProcessing(T item)
        {
            Interlocked.Increment(ref this.running);

            var handler = this.ItemProcessing;

            if (handler != null)
            {
                handler(this, new EventArgs<T>(item));
            }
        }

        protected void HandleItemProcessingFailed(T item)
        {
            var handler = this.ItemProcessingFailed;

            if (handler != null)
            {
                handler(this, new EventArgs<T>(item));
            }

            this.HandleItemProcessed(item);
        }

        protected void HandleStateChanged(QueueProcessorState queueProcessorState)
        {
            var handler = this.StateChanged;

            if (handler != null)
            {
                handler(this, new QueueProcessorStateEventArgs(queueProcessorState));
            }
        }

        protected void StartProcessing()
        {
            if (this.CancellationTokenSource == null)
            {
                this.CancellationTokenSource = new CancellationTokenSource();
                this.QueueProcessorTask = Task.Run(
                    async () => await this.ExecuteProcessQueueAsync(this.CancellationTokenSource.Token).ConfigureAwait(false),
                    this.CancellationTokenSource.Token);
            }
        }

        protected abstract Task ProcessQueueItemsAsync(CancellationToken cancellationToken);

        private async Task ExecuteProcessQueueAsync(CancellationToken cancellationToken)
        {
            try
            {
                this.State = QueueProcessorState.Running;
                await this.ProcessQueueItemsAsync(cancellationToken).ConfigureAwait(false);
                this.State = QueueProcessorState.Idle;
            }
            catch
            {
                this.State = QueueProcessorState.Idle;
            }
        }
    }
}