namespace Demo
{
    using System.Collections.Generic;

    using Demo.ViewModels;

    using NativeCode.Mobile.Core;
    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.XamarinForms.Extensions;
    using NativeCode.Mobile.Core.XamarinForms.Presentation;

    using Xamarin.Forms;

    public partial class App : Application
    {
        private readonly AppBoostrapper bootstrapper;

        public App(IEnumerable<IDependencyModule> modules)
        {
            this.InitializeComponent();

            this.bootstrapper = new AppBoostrapper();
            this.bootstrapper.Initialize(modules);

            this.PresentationFactory = this.bootstrapper.DependencyAdapter.Resolve<IPresentationFactory>();

            ShowAppStyleMenu();
        }

        public static App Instance
        {
            get { return (App)Current; }
        }

        public IBootstrapper Bootstrapper
        {
            get { return this.bootstrapper; }
        }

        public IPresentationFactory PresentationFactory { get; private set; }

        public static void ShowAppStyleMenu()
        {
            Current.MainPage = Instance.PresentationFactory.GetViewFor<AppStylesViewModel>();
        }

        public static void ShowInnerMasterDetailStyle()
        {
        }

        public static void ShowOuterMasterDetailStyle()
        {
        }

        public static void ShowSimpleMasterDetailStyle()
        {
        }

        public static void ShowSimpleNavigationStyle()
        {
            Current.MainPage = Instance.PresentationFactory.GetViewFor<SimpleNavigationViewModel>().WithNavigation();
        }
    }
}