namespace NativeCode.Mobile.Core.XamarinForms.Droid.Platform
{
    using Android.OS;

    using NativeCode.Mobile.Core.XamarinForms.Platform;

    public class MobileInformant : IMobileInformant
    {
        public PlatformSystem PlatformSystem
        {
            get
            {
                return PlatformSystem.Android;
            }
        }

        public int PlatformVersion
        {
            get
            {
                return (int)Build.VERSION.SdkInt;
            }
        }
    }
}