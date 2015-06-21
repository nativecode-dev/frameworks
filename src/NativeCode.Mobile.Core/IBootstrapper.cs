namespace NativeCode.Mobile.Core
{
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides a contract for initializing an app.
    /// </summary>
    public interface IBootstrapper
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a <see cref="Task" />.</returns>
        ConfiguredTaskAwaitable InitializeAsync(CancellationToken cancellationToken);
    }
}