namespace NativeCode.Mobile.Core.XamarinForms.Presentation.Commands
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    /// Provides a contract to extend <see cref="ICommand"/> to support asynchronous operations.
    /// </summary>
    public interface IAsyncCommand : ICommand
    {
        /// <summary>
        /// Notifies the command to refresh the execution state.
        /// </summary>
        void ChangeCanExecute();

        /// <summary>
        /// Executes the command asynchronously.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>Returns a <see cref="Task" />.</returns>
        Task ExecuteAsync(object parameter);
    }
}