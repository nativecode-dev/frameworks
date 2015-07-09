namespace NativeCode.Core.Serialization
{
    /// <summary>
    /// Provides a contract to serializer to and from strings.
    /// </summary>
    public interface IStringSerializer
    {
        /// <summary>
        /// Deserializes the string into an object.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>Returns a deserialized object.</returns>
        T Deserialize<T>(string value);

        /// <summary>
        /// Serializes an object into a string.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns>Returns serialized <see cref="string" />.</returns>
        string Serialize<T>(T instance);
    }
}