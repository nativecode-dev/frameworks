namespace NativeCode.Mobile.Core.XamarinForms.Presentation
{
    using NativeCode.Mobile.Core.Presentation;

    using Xamarin.Forms;

    internal class ViewModelNavigatorProvider : IViewModelNavigatorProvider
    {
        public IViewModelNavigator GetCurrentNavigator()
        {
            var navigation = GetFromMasterDetail();

            if (navigation != null)
            {
                return new ViewModelNavigator(() => navigation.Navigation);
            }

            return new ViewModelNavigator(() => GetFromMainPage().Navigation);
        }

        private static Page GetFromMainPage()
        {
            return Application.Current.MainPage;
        }

        private static Page GetFromMasterDetail()
        {
            var master = Application.Current.MainPage as MasterDetailPage;

            if (master != null && master.Detail != null)
            {
                var navigation = master.Detail as NavigationPage;

                if (navigation != null)
                {
                    return navigation.CurrentPage;
                }
            }

            return null;
        }
    }
}