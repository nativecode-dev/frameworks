namespace NativeCode.Core
{
    using System.Collections.Generic;

    using NativeCode.Core.Dependencies;

    /// <summary>
    /// Provides a contract for initializing an app.
    /// </summary>
    public interface IBootstrapper
    {
        /// <summary>
        /// Gets the dependency adapter.
        /// </summary>
        DependencyAdapter DependencyAdapter { get; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <param name="modules">The modules.</param>
        void Initialize(IEnumerable<IDependencyModule> modules);

        void Initialize(params IDependencyModule[] modules);
    }
}