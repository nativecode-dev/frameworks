namespace NativeCode.Core.Dependencies
{
    /// <summary>
    /// Provides a contract to register dependencies in satellite assemblies.
    /// </summary>
    public interface IDependencyModule
    {
        /// <summary>
        /// Registers the dependencies.
        /// </summary>
        /// <param name="registrar">The registrar.</param>
        void RegisterDependencies(IDependencyRegistrar registrar);
    }
}