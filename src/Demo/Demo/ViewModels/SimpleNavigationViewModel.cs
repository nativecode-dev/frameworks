namespace Demo.ViewModels
{
    using System.Windows.Input;

    using NativeCode.Mobile.Core.Platform;
    using NativeCode.Mobile.Core.Presentation;

    using Xamarin.Forms;

    public class SimpleNavigationViewModel : NavigableViewModel
    {
        public SimpleNavigationViewModel(IDeviceInformant device)
        {
            this.Title = "Simple Navigation";

            this.AboutCommand = new Command(async () => await this.Navigator.PushAsync<AboutViewModel>());
            this.ArticleCommand = new Command(async () => await this.Navigator.PushAsync<ArticleViewModel>());
            this.ChooseStyleCommand = new Command(App.ShowAppStyleMenu);
            this.ControlsCommand = new Command(async () => await this.Navigator.PushAsync<ControlsViewModel>());
            this.FlipViewCommand = new Command(async () => await this.Navigator.PushAsync<FlipViewModel>());
            this.WebBrowserCommand = new Command(async () => await this.Navigator.PushAsync<WebBrowserViewModel>());
            this.WebBrowserNavigationEnabled = device.IsConnected;
        }

        public ICommand AboutCommand { get; private set; }

        public ICommand ArticleCommand { get; private set; }

        public ICommand ChooseStyleCommand { get; private set; }

        public ICommand ControlsCommand { get; private set; }

        public ICommand FlipViewCommand { get; private set; }

        public ICommand WebBrowserCommand { get; private set; }

        public bool WebBrowserNavigationEnabled { get; set; }
    }
}