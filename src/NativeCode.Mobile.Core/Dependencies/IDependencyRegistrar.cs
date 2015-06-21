namespace NativeCode.Mobile.Core.Dependencies
{
    using System;

    /// <summary>
    /// Provides a contract to register dependencies.
    /// </summary>
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// Registers a factory method to create dependency instances.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="factory">The factory.</param>
        void Factory(Type contract, Func<IDependencyResolver, object> factory);

        /// <summary>
        /// Registers a factory method to create dependency instances.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <param name="factory">The factory.</param>
        void Factory<TContract>(Func<IDependencyResolver, TContract> factory) where TContract : class;

        /// <summary>
        /// Registers a dependency.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        void Register(Type contract, DependencyKey key = DependencyKey.None, DependencyLifetime lifetime = DependencyLifetime.Default);

        /// <summary>
        /// Registers the specified contract.
        /// Registers a dependency.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        void Register(Type contract, string key, DependencyLifetime lifetime = DependencyLifetime.Default);

        /// <summary>
        /// Registers a dependency.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        void Register<TContract>(DependencyKey key = DependencyKey.None, DependencyLifetime lifetime = DependencyLifetime.Default) where TContract : class;

        /// <summary>
        /// Registers a dependency.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        void Register<TContract>(string key, DependencyLifetime lifetime = DependencyLifetime.Default) where TContract : class;

        /// <summary>
        /// Registers a dependency.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        void Register(Type contract, Type implementation, DependencyKey key = DependencyKey.None, DependencyLifetime lifetime = DependencyLifetime.Default);

        /// <summary>
        /// Registers a dependency.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        void Register(Type contract, Type implementation, string key, DependencyLifetime lifetime = DependencyLifetime.Default);

        /// <summary>
        /// Registers a dependency.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        void Register<TContract, TImplementation>(DependencyKey key = DependencyKey.None, DependencyLifetime lifetime = DependencyLifetime.Default)
            where TContract : class where TImplementation : class, TContract;

        /// <summary>
        /// Registers a dependency.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        void Register<TContract, TImplementation>(string key, DependencyLifetime lifetime = DependencyLifetime.Default) where TContract : class
            where TImplementation : class, TContract;
    }
}