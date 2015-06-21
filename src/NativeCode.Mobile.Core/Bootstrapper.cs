namespace NativeCode.Mobile.Core
{
    using System.Collections.Generic;

    using NativeCode.Mobile.Core.Dependencies;

    public abstract class Bootstrapper : IBootstrapper
    {
        public DependencyAdapter DependencyAdapter { get; private set; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <param name="modules">The modules.</param>
        public void Initialize(IEnumerable<IDependencyModule> modules)
        {
            this.DependencyAdapter = this.CreateDependencyAdapter();

            this.InternalInitialize();

            foreach (var module in modules)
            {
                module.RegisterDependencies(this.DependencyAdapter);
            }
        }

        /// <summary>
        /// Creates a dependency adapter.
        /// </summary>
        /// <returns>Returns a new <see cref="DependencyAdapter" />.</returns>
        protected abstract DependencyAdapter CreateDependencyAdapter();

        /// <summary>
        /// Initialize the app.
        /// </summary>
        protected abstract void InternalInitialize();
    }
}