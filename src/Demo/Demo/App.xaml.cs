namespace Demo
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using NativeCode.Mobile.Core.Dependencies;

    using Xamarin.Forms;

    public partial class App : Application
    {
        private readonly AppBoostrapper bootstrapper;

        public App(IEnumerable<IDependencyModule> modules)
        {
            this.bootstrapper = new AppBoostrapper(modules);

            this.InitializeComponent();
            this.MainPage = new ContentPage();
        }

        public static App Instance
        {
            get { return (App)Current; }
        }

        public static async Task InitializeAsync()
        {
            await Instance.bootstrapper.InitializeAsync(CancellationToken.None);
        }
    }
}