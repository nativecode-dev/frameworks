using System;
using System.Collections.Generic;

namespace NativeCode.Core.Dependencies
{
    /// <summary>
    /// Provides basic functionality for a dependency adapter.
    /// </summary>
    public abstract class DependencyAdapter : IDependencyRegistrar, IDependencyResolver, IDisposable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DependencyAdapter"/> is disposed.
        /// </summary>
        protected bool Disposed { get; set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Registers a factory method to create dependency instances.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="factory">The factory.</param>
        public abstract void Factory(Type contract, Func<IDependencyResolver, object> factory);

        /// <summary>
        /// Registers a factory method to create dependency instances.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <param name="factory">The factory.</param>
        public abstract void Factory<TContract>(Func<IDependencyResolver, TContract> factory) where TContract : class;

        /// <summary>
        /// Registers an instance.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <param name="instance">The instance.</param>
        public abstract void Instance<TContract>(TContract instance) where TContract : class;

        /// <summary>
        /// Registers a dependency.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        public virtual void Register(Type contract, DependencyKey key = DependencyKey.None, DependencyLifetime lifetime = DependencyLifetime.Default)
        {
            this.Register(contract, this.GetTypeKey(contract, key), lifetime);
        }

        /// <summary>
        /// Registers the specified contract.
        /// Registers a dependency.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        public abstract void Register(Type contract, string key, DependencyLifetime lifetime = DependencyLifetime.Default);

        /// <summary>
        /// Registers a dependency.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        public virtual void Register<TContract>(DependencyKey key = DependencyKey.None, DependencyLifetime lifetime = DependencyLifetime.Default)
            where TContract : class
        {
            var type = typeof(TContract);

            this.Register(type, this.GetTypeKey(type, key), lifetime);
        }

        /// <summary>
        /// Registers the specified key.
        /// </summary>
        /// <typeparam name="TContract">The type of the t contract.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        public virtual void Register<TContract>(string key, DependencyLifetime lifetime = DependencyLifetime.Default) where TContract : class
        {
            this.Register(typeof(TContract), key, lifetime);
        }

        /// <summary>
        /// Registers a dependency.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        public virtual void Register(
            Type contract,
            Type implementation,
            DependencyKey key = DependencyKey.None,
            DependencyLifetime lifetime = DependencyLifetime.Default)
        {
            this.Register(contract, implementation, this.GetTypeKey(implementation, key), lifetime);
        }

        /// <summary>
        /// Registers a dependency.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        public abstract void Register(Type contract, Type implementation, string key, DependencyLifetime lifetime = DependencyLifetime.Default);

        /// <summary>
        /// Registers a dependency.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        public virtual void Register<TContract, TImplementation>(
            DependencyKey key = DependencyKey.None,
            DependencyLifetime lifetime = DependencyLifetime.Default) where TContract : class where TImplementation : class, TContract
        {
            var type = typeof(TImplementation);

            this.Register(typeof(TContract), type, this.GetTypeKey(type, key), lifetime);
        }

        /// <summary>
        /// Registers a dependency.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="lifetime">The lifetime.</param>
        public virtual void Register<TContract, TImplementation>(string key, DependencyLifetime lifetime = DependencyLifetime.Default) where TContract : class
            where TImplementation : class, TContract
        {
            var type = typeof(TImplementation);

            this.Register(typeof(TContract), type, key, lifetime);
        }

        public abstract void RegisterAll<TContract>(IEnumerable<Type> implementations) where TContract : class;

        public void RegisterAll<TContract>(params Type[] implementations) where TContract : class
        {
            this.RegisterAll<TContract>((IEnumerable<Type>)implementations);
        }

        /// <summary>
        /// Resolves the registered type of the dependency.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="key">The key.</param>
        /// <returns>Returns a resolved dependency.</returns>
        public abstract object Resolve(Type type, string key = null);

        /// <summary>
        /// Resolves the registered type of the dependency.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="key">The key.</param>
        /// <returns>Returns a resolved dependency.</returns>
        public abstract object Resolve(Type type, DependencyKey key);

        /// <summary>
        /// Resolves the registered type of the dependency.
        /// </summary>
        /// <typeparam name="T">The type of the dependency.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Returns a resolved dependency.</returns>
        public abstract T Resolve<T>(string key = null) where T : class;

        /// <summary>
        /// Resolves the registered type of the dependency.
        /// </summary>
        /// <typeparam name="T">The type of the dependency.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Returns a resolved dependency.</returns>
        public abstract T Resolve<T>(DependencyKey key) where T : class;

        /// <summary>
        /// Resolves all registered types of the dependency.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Returns a collection of resolved dependencies.</returns>
        public abstract IEnumerable<object> ResolveAll(Type type);

        /// <summary>
        /// Resolves all registered types of the dependency.
        /// </summary>
        /// <typeparam name="T">The type of the dependency.</typeparam>
        /// <returns>Returns a collection of resolved dependencies.</returns>
        public abstract IEnumerable<T> ResolveAll<T>() where T : class;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected abstract void Dispose(bool disposing);

        /// <summary>
        /// Gets a string representing a type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="key">The key.</param>
        /// <returns>Returns a string representing the type.</returns>
        protected virtual string GetTypeKey(Type type, DependencyKey key)
        {
            switch (key)
            {
                case DependencyKey.AssemblyQualified:
                    return type.AssemblyQualifiedName;

                case DependencyKey.TypeName:
                    return type.Name;

                case DependencyKey.TypeQualified:
                    return type.FullName;

                default:
                    return null;
            }
        }
    }
}