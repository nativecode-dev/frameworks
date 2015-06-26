namespace Demo
{
    using System.Collections.Generic;

    using Demo.ViewModels;

    using NativeCode.Mobile.Core;
    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.Logging;
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
            Logger.Default.Debug("ShowAppStyleMenu");
        }

        public static void ShowInnerMasterDetailStyle()
        {
            Current.MainPage = Instance.PresentationFactory.GetViewFor<MasterDetailInnerNavigationViewModel>();
            Logger.Default.Debug("ShowInnerMasterDetailStyle");
        }

        public static void ShowOuterMasterDetailStyle()
        {
            Current.MainPage = Instance.PresentationFactory.GetViewFor<MasterDetailOuterNavigationViewModel>().WithNavigation();
            Logger.Default.Debug("ShowOuterMasterDetailStyle");
        }

        public static void ShowSimpleMasterDetailStyle()
        {
            Current.MainPage = Instance.PresentationFactory.GetViewFor<SimpleMasterDetailViewModel>();
            Logger.Default.Debug("ShowSimpleMasterDetailStyle");
        }

        public static void ShowSimpleNavigationStyle()
        {
            Current.MainPage = Instance.PresentationFactory.GetViewFor<SimpleNavigationViewModel>().WithNavigation();
            Logger.Default.Debug("ShowSimpleNavigationStyle");
        }
    }
}