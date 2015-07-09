namespace NativeCode.Core.Dependencies
{
    /// <summary>
    /// Enumeration of dependency lifetimes.
    /// </summary>
    public enum DependencyLifetime
    {
        /// <summary>
        /// Indicates to use the default lifetime.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Indicates that dependencies are resolved once per application instance.
        /// </summary>
        PerApplication = 1,

        /// <summary>
        /// Indicates that new instances are created on each resolve.
        /// </summary>
        PerCall = Default,

        /// <summary>
        /// Indicates that new instances are created for each container.
        /// </summary>
        PerContainer = 2,

        /// <summary>
        /// Indicates that a single instance should be used for a resolve chain.
        /// </summary>
        PerResolve = 3
    }
}