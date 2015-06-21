namespace NativeCode.Mobile.Core.XamarinForms.Helpers
{
    using System.Linq;

    using Xamarin.Forms;

    public static class AppHelper
    {
        public static MasterDetailPage GetMasterDetailPage()
        {
            var master = Application.Current.MainPage as MasterDetailPage;

            if (master != null)
            {
                return master;
            }

            var navigation = Application.Current.MainPage as NavigationPage;

            if (navigation != null)
            {
                var root = navigation.CurrentPage as MasterDetailPage;

                if (root != null)
                {
                    return root;
                }

                return navigation.Navigation.NavigationStack.FirstOrDefault() as MasterDetailPage;
            }

            return null;
        }
    }
}