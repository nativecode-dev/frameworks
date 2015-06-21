namespace NativeCode.Mobile.Core
{
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class Bootstrapper : IBootstrapper
    {
        public void Initialize()
        {
            this.InitializeAsync(CancellationToken.None).GetAwaiter().GetResult();
        }

        public ConfiguredTaskAwaitable InitializeAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() => this.InternalInitialize(), cancellationToken).ConfigureAwait(false);
        }

        protected abstract void InternalInitialize();
    }
}