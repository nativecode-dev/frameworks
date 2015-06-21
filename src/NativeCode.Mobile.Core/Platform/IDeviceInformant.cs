namespace NativeCode.Mobile.Core.Platform
{
    /// <summary>
    /// Provides device information.
    /// </summary>
    public interface IDeviceInformant
    {
        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets the hardware version.
        /// </summary>
        /// <returns>Returns a <see cref="string" />.</returns>
        string GetHardwareVersion();

        /// <summary>
        /// Gets the platform version.
        /// </summary>
        /// <returns>Returns a <see cref="string" />.</returns>
        string GetPlatformVersion();
    }
}