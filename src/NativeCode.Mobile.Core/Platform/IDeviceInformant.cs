﻿namespace NativeCode.Mobile.Core.Platform
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides device information.
    /// </summary>
    public interface IDeviceInformant
    {
        /// <summary>
        /// Gets the application path.
        /// </summary>
        string AppPath { get; }

        /// <summary>
        /// Gets the device identifier.
        /// </summary>
        string DeviceIdentifier { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is external storage supported.
        /// </summary>
        bool IsExternalStorageSupported { get; }

        /// <summary>
        /// Gets the application data path.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>Returns a path to the data file.</returns>
        string GetAppDataPath(string filename);

        /// <summary>
        /// Gets the storage devices.
        /// </summary>
        /// <returns>Returns a collection of storage devices.</returns>
        IEnumerable<StorageDevice> GetStorageDevices();

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