namespace NativeCode.Mobile.Core.Platform
{
    /// <summary>
    /// Provides device information.
    /// </summary>
    public interface IDeviceInformant
    {
        /// <summary>
        /// Gets the device identifier.
        /// </summary>
        string DeviceIdentifier { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets the device string.
        /// </summary>
        /// <returns>Returns a <see cref="string" />.</returns>
        string GetDeviceString();

        /// <summary>
        /// Gets the display string.
        /// </summary>
        /// <returns>Returns a <see cref="string" />.</returns>
        string GetDisplayString();

        /// <summary>
        /// Gets the hardware version.
        /// </summary>
        /// <returns>Returns a <see cref="string" />.</returns>
        string GetHardwareString();

        /// <summary>
        /// Gets the platform version.
        /// </summary>
        /// <returns>Returns a <see cref="string" />.</returns>
        string GetPlatformString();

        /// <summary>
        /// Gets the product string.
        /// </summary>
        /// <returns>Returns a <see cref="string" />.</returns>
        string GetProductString();
    }
}