namespace NativeCode.Mobile.Core.XamarinForms.Presentation.Commands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    public abstract class AsyncCommandBase : IAsyncCommand
    {
        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        [SuppressMessage("NativeCode", "NC1001:AsyncMustReturnTask", Justification = "Reviewed. Suppression is OK here.")]
        public async void Execute(object parameter)
        {
            await this.ExecuteAsync(parameter).ConfigureAwait(true);
        }

        public abstract Task ExecuteAsync(object parameter);

        protected void OnCanExecuteChanged()
        {
            var handler = this.CanExecuteChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}