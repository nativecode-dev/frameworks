namespace NativeCode.Mobile.Core.XamarinForms.Extensions
{
    using Xamarin.Forms;

    public static class ApplicationExtensions
    {
        public static bool IsStandAloneMasterDetailPage(this Application application)
        {
            var master = application.MainPage as MasterDetailPage;

            if (master != null && master.Detail is NavigationPage)
            {
                return false;
            }

            return true;
        }
    }
}