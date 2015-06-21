namespace NativeCode.Mobile.Core.XamarinForms.Presentation
{
    using NativeCode.Mobile.Core.Presentation;

    using Xamarin.Forms;

    public class ViewModelNavigatorProvider : IViewModelNavigatorProvider
    {
        public IViewModelNavigator GetViewModelNavigator()
        {
            var page = GetFromNavigationPage() ?? GetFromMasterDetailPage() ?? GetFromMainPage();

            return new ViewModelNavigator(() => page.Navigation);
        }

        private static Page GetFromNavigationPage()
        {
            return Application.Current.MainPage as NavigationPage;
        }

        private static Page GetFromMasterDetailPage()
        {
            var master = Application.Current.MainPage as MasterDetailPage;

            if (master != null && master.Detail is NavigationPage)
            {
                return master.Detail;
            }

            return null;
        }

        private static Page GetFromMainPage()
        {
            return Application.Current.MainPage;
        }
    }
}