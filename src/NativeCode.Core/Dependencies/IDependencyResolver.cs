using System;
using System.Collections.Generic;

namespace NativeCode.Core.Dependencies
{
    /// <summary>
    /// Provides a contract to resolve dependencies.
    /// </summary>
    public interface IDependencyResolver
    {
        /// <summary>
        /// Resolves the registered type of the dependency.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="key">The key.</param>
        /// <returns>Returns a resolved dependency.</returns>
        object Resolve(Type type, string key = null);

        /// <summary>
        /// Resolves the registered type of the dependency.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="key">The key.</param>
        /// <returns>Returns a resolved dependency.</returns>
        object Resolve(Type type, DependencyKey key);

        /// <summary>
        /// Resolves the registered type of the dependency.
        /// </summary>
        /// <typeparam name="T">The type of the dependency.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Returns a resolved dependency.</returns>
        T Resolve<T>(string key = null) where T : class;

        /// <summary>
        /// Resolves the registered type of the dependency.
        /// </summary>
        /// <typeparam name="T">The type of the dependency.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Returns a resolved dependency.</returns>
        T Resolve<T>(DependencyKey key) where T : class;

        /// <summary>
        /// Resolves all registered types of the dependency.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Returns a collection of resolved dependencies.</returns>
        IEnumerable<object> ResolveAll(Type type);

        /// <summary>
        /// Resolves all registered types of the dependency.
        /// </summary>
        /// <typeparam name="T">The type of the dependency.</typeparam>
        /// <returns>Returns a collection of resolved dependencies.</returns>
        IEnumerable<T> ResolveAll<T>() where T : class;
    }
}