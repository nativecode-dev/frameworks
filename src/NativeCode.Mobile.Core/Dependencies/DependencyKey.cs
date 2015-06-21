namespace NativeCode.Mobile.Core.Dependencies
{
    /// <summary>
    /// Enumeration of dependency keys.
    /// </summary>
    public enum DependencyKey
    {
        /// <summary>
        /// Indicates that no key should be used.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates that the key is represented by the assembly qualified name.
        /// </summary>
        AssemblyQualified = 1,

        /// <summary>
        /// Indicates that the key is represented by the qualified type name.
        /// </summary>
        TypeQualified = 2,

        /// <summary>
        /// Indicates that the key is represented by the type name.
        /// </summary>
        TypeName = 3
    }
}