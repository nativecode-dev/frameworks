namespace NativeCode.Mobile.Core.XamarinForms.Droid.Platform
{
    using Android.Content;

    using NativeCode.Mobile.Core.Droid.Platform;

    using Xamarin.Forms;

    public class FormsContextProvider : IContextProvider
    {
        public Context GetCurrentContext()
        {
            return Forms.Context;
        }
    }
}