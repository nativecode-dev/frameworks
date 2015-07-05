namespace NativeCode.Mobile.Core.Droid.Platform
{
    using System.Collections.Generic;

    using Android.Content;
    using Android.Net;
    using Android.OS;
    using Android.Provider;

    using NativeCode.Mobile.Core.Platform;

    using Environment = System.Environment;

    public class DeviceInformant : IDeviceInformant
    {
        private readonly IContextProvider contextProvider;

        private readonly IStorageProvider storageProvider;

        public DeviceInformant(IContextProvider contextProvider, IStorageProvider storageProvider)
        {
            this.contextProvider = contextProvider;
            this.storageProvider = storageProvider;
        }

        public string AppPath
        {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.Personal, Environment.SpecialFolderOption.Create); }
        }

        public string DeviceIdentifier
        {
            get { return Settings.Secure.GetString(this.Context.ContentResolver, Settings.Secure.AndroidId); }
        }

        public bool IsConnected
        {
            get { return this.GetIsConnected(); }
        }

        public bool IsExternalStorageSupported
        {
            get { return true; }
        }

        protected Context Context
        {
            get { return this.contextProvider.GetCurrentContext(); }
        }

        public string GetAppDataPath(string filename)
        {
            using (var file = this.Context.GetDatabasePath(filename))
            {
                return file.AbsolutePath;
            }
        }

        public string GetDisplayString()
        {
            return Build.Display;
        }

        public IEnumerable<StorageDevice> GetStorageDevices()
        {
            return storageProvider.GetStorageDevices();
        }

        public string GetDeviceString()
        {
            return Build.Device;
        }

        public string GetHardwareString()
        {
            return Build.Hardware;
        }

        public string GetPlatformString()
        {
            return Build.VERSION.Sdk;
        }

        public string GetProductString()
        {
            return Build.Product;
        }

        private bool GetIsConnected()
        {
            var manager = (ConnectivityManager)this.Context.GetSystemService(Context.ConnectivityService);
            var network = manager.ActiveNetworkInfo;

            return network != null && network.IsConnected;
        }
    }
}