namespace NativeCode.Core
{
    using System.Collections.Generic;

    using NativeCode.Core.Dependencies;

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
            DependencyResolver.SetResolver(() => this.DependencyAdapter);

            foreach (var module in modules)
            {
                module.RegisterDependencies(this.DependencyAdapter);
            }

            // We need to fire this last, so that any dependencies can overwrite existing ones from modules.
            this.InternalInitialize();
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