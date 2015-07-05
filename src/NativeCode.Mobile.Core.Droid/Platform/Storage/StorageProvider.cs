namespace NativeCode.Mobile.Core.Droid.Platform.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    using NativeCode.Mobile.Core.Platform;

    /// <summary>
    /// Provides an Android-specific platform for storages.
    /// </summary>
    /// <remarks>Do not inject an ILogger here, because it will cause a circular reference problem with DI.</remarks>
    public class StorageProvider : IStorageProvider
    {
        private const string ProcMounts = "/proc/mounts";

        public IEnumerable<StorageDevice> GetStorageDevices()
        {
            try
            {
                var configuration = File.ReadAllText(ProcMounts);

                return ParseMounts(configuration);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return Enumerable.Empty<StorageDevice>();
        }

        private static IReadOnlyCollection<StorageDevice> ParseMounts(string configuration)
        {
            var devices = new List<StorageDevice>();

            if (!string.IsNullOrWhiteSpace(configuration))
            {
                var lines = configuration.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    var parts = line.Split(' ');
                    var mount = parts[1];
                    var filesystem = parts[2];
                    var options = parts[3];

                    // Ignore any mounts that aren't mounted in the /mnt directory.
                    if (string.IsNullOrWhiteSpace(mount) || mount.Contains("emulated") || filesystem.ToLower() != "sdcardfs")
                    {
                        continue;
                    }

                    try
                    {
                        devices.Add(new AndroidStorageDevice(mount, options));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            }

            return devices;
        }
    }
}