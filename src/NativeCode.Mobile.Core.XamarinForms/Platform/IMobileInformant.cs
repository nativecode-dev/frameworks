namespace NativeCode.Mobile.Core.XamarinForms.Platform
{
    /// <summary>
    /// Provides a contract to provide mobile platform information.
    /// </summary>
    public interface IMobileInformant
    {
        /// <summary>
        /// Gets the platform system.
        /// </summary>
        PlatformSystem PlatformSystem { get; }

        /// <summary>
        /// Gets the platform version.
        /// </summary>
        int PlatformVersion { get; }
    }
}