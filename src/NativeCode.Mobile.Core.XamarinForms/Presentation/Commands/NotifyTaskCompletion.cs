namespace NativeCode.Mobile.Core.XamarinForms.Presentation.Commands
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;

    /// <summary>
    /// <see href="https://msdn.microsoft.com/en-us/magazine/dn630647.aspx"/>
    /// </summary>
    /// <typeparam name="TResult">Type of the result.</typeparam>
    public sealed class NotifyTaskCompletion<TResult> : INotifyPropertyChanged
    {
        public NotifyTaskCompletion(Task<TResult> task)
        {
            this.Task = task;

            if (!task.IsCompleted)
            {
                this.TaskCompletion = this.WatchTaskAsync(task);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Task<TResult> Task { get; private set; }

        public Task TaskCompletion { get; private set; }

        public TResult Result
        {
            get { return (this.Task.Status == TaskStatus.RanToCompletion) ? this.Task.Result : default(TResult); }
        }

        public TaskStatus Status
        {
            get { return this.Task.Status; }
        }

        public bool IsCompleted
        {
            get { return this.Task.IsCompleted; }
        }

        public bool IsNotCompleted
        {
            get { return !this.Task.IsCompleted; }
        }

        public bool IsSuccessfullyCompleted
        {
            get { return this.Task.Status == TaskStatus.RanToCompletion; }
        }

        public bool IsCanceled
        {
            get { return this.Task.IsCanceled; }
        }

        public bool IsFaulted
        {
            get { return this.Task.IsFaulted; }
        }

        public AggregateException Exception
        {
            get { return this.Task.Exception; }
        }

        public Exception InnerException
        {
            get { return (this.Exception == null) ? null : this.Exception.InnerException; }
        }

        public string ErrorMessage
        {
            get { return (this.InnerException == null) ? null : this.InnerException.Message; }
        }

        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                await task.ConfigureAwait(false);
            }
            catch
            {
                // TODO: Add logging.
            }

            var handler = this.PropertyChanged;

            if (handler == null)
            {
                return;
            }

            handler(this, new PropertyChangedEventArgs("Status"));
            handler(this, new PropertyChangedEventArgs("IsCompleted"));
            handler(this, new PropertyChangedEventArgs("IsNotCompleted"));

            if (task.IsCanceled)
            {
                handler(this, new PropertyChangedEventArgs("IsCanceled"));
            }
            else if (task.IsFaulted)
            {
                handler(this, new PropertyChangedEventArgs("IsFaulted"));
                handler(this, new PropertyChangedEventArgs("Exception"));
                handler(this, new PropertyChangedEventArgs("InnerException"));
                handler(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
            else
            {
                handler(this, new PropertyChangedEventArgs("IsSuccessfullyCompleted"));
                handler(this, new PropertyChangedEventArgs("Result"));
            }
        }
    }
}