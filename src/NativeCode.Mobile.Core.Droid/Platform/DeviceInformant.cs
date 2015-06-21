namespace NativeCode.Mobile.Core.Droid.Platform
{
    using System;

    using Android.Content;
    using Android.Net;

    using NativeCode.Mobile.Core.Platform;

    public class DeviceInformant : IDeviceInformant
    {
        private readonly IContextProvider provider;

        public DeviceInformant(IContextProvider provider)
        {
            this.provider = provider;
        }

        protected Context Context
        {
            get { return this.provider.GetCurrentContext(); }
        }

        public bool IsConnected
        {
            get
            {
                var manager = (ConnectivityManager)this.Context.GetSystemService(Context.ConnectivityService);
                var network = manager.ActiveNetworkInfo;

                return network != null && network.IsConnected;
            }
        }

        public string GetHardwareVersion()
        {
            throw new NotImplementedException();
        }

        public string GetPlatformVersion()
        {
            throw new NotImplementedException();
        }
    }
}