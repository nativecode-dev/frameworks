namespace Demo.ViewModels
{
    using System.Windows.Input;

    using NativeCode.Mobile.Core.Presentation;

    using Xamarin.Forms;

    public class AppStylesViewModel : NavigableViewModel
    {
        public AppStylesViewModel()
        {
            this.MasterDetailInnerNavigationCommand = new Command(App.ShowInnerMasterDetailStyle);
            this.MasterDetailOuterNavigationCommand = new Command(App.ShowOuterMasterDetailStyle);
            this.SimpleMasterDetailCommand = new Command(App.ShowSimpleMasterDetailStyle);
            this.SimpleNavigationCommand = new Command(App.ShowSimpleNavigationStyle);

            this.Title = "Choose app navigation style...";
        }

        public ICommand MasterDetailInnerNavigationCommand { get; private set; }

        public ICommand MasterDetailOuterNavigationCommand { get; private set; }

        public ICommand SimpleMasterDetailCommand { get; private set; }

        public ICommand SimpleNavigationCommand { get; private set; }
    }
}