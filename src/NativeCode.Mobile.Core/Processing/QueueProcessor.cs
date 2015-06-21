namespace NativeCode.Mobile.Core.Processing
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using NativeCode.Mobile.Core.Logging;

    internal abstract class QueueProcessor<T> : IDisposable, IQueueProcessor<T>
    {
        private QueueProcessorState state;

        protected QueueProcessor(Action<T> processor)
        {
            this.Processor = processor;
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

        public Task ProcessorTask { get; private set; }

        protected CancellationTokenSource CancellationTokenSource { get; private set; }

        protected Action<T> Processor { get; private set; }

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
                    this.ProcessorTask = null;
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
            var handler = this.ItemProcessed;

            if (handler != null)
            {
                handler(this, new EventArgs<T>(item));
            }
        }

        protected void HandleItemProcessing(T item)
        {
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
                this.State = QueueProcessorState.Running;

                this.ProcessorTask = Task.Run(
                    () =>
                        {
                            try
                            {
                                this.ProcessQueueItems();
                                this.State = QueueProcessorState.Idle;
                            }
                            catch (Exception ex)
                            {
                                this.State = QueueProcessorState.Idle;
                                Logger.Default.Exception(ex);
                            }
                        },
                    this.CancellationTokenSource.Token);
            }
        }

        protected abstract void ProcessQueueItems();
    }
}