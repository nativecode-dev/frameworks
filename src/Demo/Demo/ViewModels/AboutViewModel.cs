namespace Demo.ViewModels
{
    using NativeCode.Mobile.Core.Platform;
    using NativeCode.Mobile.Core.Presentation;

    public class AboutViewModel : NavigableViewModel
    {
        public AboutViewModel(IDeviceInformant device)
        {
            this.Title = "About Device";

            this.DeviceIdentifier = device.DeviceIdentifier;
            this.DeviceString = device.GetDeviceString();
            this.DisplayString = device.GetDisplayString();
            this.HardwareString = device.GetHardwareString();
            this.PlatformString = device.GetPlatformString();
            this.ProductString = device.GetProductString();
        }

        public string DeviceIdentifier { get; private set; }

        public string DeviceString { get; private set; }

        public string DisplayString { get; private set; }

        public string HardwareString { get; private set; }

        public string PlatformString { get; private set; }

        public string ProductString { get; private set; }
    }
}