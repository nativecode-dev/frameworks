namespace NativeCode.Mobile.Core.XamarinForms.Presentation.Commands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class AsyncCommand : AsyncCommandBase
    {
        private readonly Func<object, bool> canExecute;

        private readonly Func<Task> command;

        public AsyncCommand(Func<Task> command) : this(command, x => true)
        {
        }

        public AsyncCommand(Func<Task> command, Func<object, bool> canExecute)
        {
            this.canExecute = canExecute;
            this.command = command;
        }

        public override bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public override Task ExecuteAsync(object parameter)
        {
            return Task.Run(() => this.DoExecute());
        }

        protected virtual void DoExecute()
        {
            this.command();
        }
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    public class AsyncCommand<TResult> : AsyncCommandBase
    {
        private readonly Func<object, bool> canExecute;

        private readonly CancelAsyncCommand cancel;

        private readonly Func<CancellationToken, Task<TResult>> command;

        private NotifyTaskCompletion<TResult> execution;

        public AsyncCommand(Func<CancellationToken, Task<TResult>> command) : this(command, x => true)
        {
        }

        public AsyncCommand(Func<CancellationToken, Task<TResult>> command, Func<object, bool> canExecute)
        {
            this.canExecute = canExecute;
            this.cancel = new CancelAsyncCommand();
            this.command = command;
        }

        public ICommand CancelCommand
        {
            get { return this.cancel; }
        }

        public override bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            this.cancel.NotifyCommandStarting();
            this.execution = new NotifyTaskCompletion<TResult>(this.command(this.cancel.Token));
            this.OnCanExecuteChanged();

            await this.execution.TaskCompletion.ConfigureAwait(false);

            this.cancel.NotifyCommandFinished();
            this.OnCanExecuteChanged();
        }

        [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable",
            Justification = "No need to dispose of the CancellationTokenSource here.")]
        private sealed class CancelAsyncCommand : ICommand
        {
            private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            private bool executing;

            public event EventHandler CanExecuteChanged;

            public CancellationToken Token
            {
                get { return this.cancellationTokenSource.Token; }
            }

            public void NotifyCommandStarting()
            {
                this.executing = true;

                if (!this.cancellationTokenSource.IsCancellationRequested)
                {
                    return;
                }

                this.cancellationTokenSource = new CancellationTokenSource();
                this.OnCanExecuteChanged();
            }

            public void NotifyCommandFinished()
            {
                this.executing = false;
                this.OnCanExecuteChanged();
            }

            bool ICommand.CanExecute(object parameter)
            {
                return this.executing && !this.cancellationTokenSource.IsCancellationRequested;
            }

            void ICommand.Execute(object parameter)
            {
                this.cancellationTokenSource.Cancel();
                this.OnCanExecuteChanged();
            }

            private void OnCanExecuteChanged()
            {
                var handler = this.CanExecuteChanged;

                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
    }
}