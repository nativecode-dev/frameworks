namespace Demo.ViewModels
{
    using System.Windows.Input;

    using NativeCode.Mobile.Core.Presentation;

    using Xamarin.Forms;

    public class SimpleNavigationViewModel : NavigableViewModel
    {
        public SimpleNavigationViewModel()
        {
            this.Title = "Simple Navigation";

            this.ChooseStyleCommand = new Command(App.ShowAppStyleMenu);
            this.WebBrowserCommand = new Command(async () => await this.Navigator.PushAsync<WebBrowserViewModel>());
        }

        public ICommand ChooseStyleCommand { get; private set; }

        public ICommand WebBrowserCommand { get; private set; }
    }
}