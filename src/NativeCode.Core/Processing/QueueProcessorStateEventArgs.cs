namespace NativeCode.Core.Processing
{
    using System;

    /// <summary>
    /// Event notification of queue processor state changes.
    /// </summary>
    public class QueueProcessorStateEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueProcessorStateEventArgs"/> class.
        /// </summary>
        /// <param name="queueProcessorState">State of the queue processor.</param>
        public QueueProcessorStateEventArgs(QueueProcessorState queueProcessorState)
        {
            this.QueueProcessorState = queueProcessorState;
        }

        /// <summary>
        /// Gets the state of the queue processor.
        /// </summary>
        public QueueProcessorState QueueProcessorState { get; private set; }
    }
}