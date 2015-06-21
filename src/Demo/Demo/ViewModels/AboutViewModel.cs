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

        public string DeviceIdentifier { get; set; }

        public string DeviceString { get; set; }

        public string DisplayString { get; set; }

        public string HardwareString { get; set; }

        public string PlatformString { get; set; }

        public string ProductString { get; set; }
    }
}