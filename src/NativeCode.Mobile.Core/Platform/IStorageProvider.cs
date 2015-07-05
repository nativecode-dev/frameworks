namespace NativeCode.Mobile.Core.Platform
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides a contract to provide device-dependent storage information.
    /// </summary>
    public interface IStorageProvider
    {
        /// <summary>
        /// Gets the storage devices.
        /// </summary>
        /// <returns>Returns a collection of <see cref="StorageDevice"/> devices.</returns>
        IEnumerable<StorageDevice> GetStorageDevices();
    }
}