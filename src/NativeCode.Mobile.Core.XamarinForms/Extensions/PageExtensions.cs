namespace NativeCode.Mobile.Core.XamarinForms.Extensions
{
    using Xamarin.Forms;

    public static class PageExtensions
    {
        public static NavigationPage WithNavigation(this Page page)
        {
            return new NavigationPage(page);
        }
    }
}