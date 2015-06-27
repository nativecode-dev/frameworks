namespace Demo
{
    using Demo.ViewModels;
    using Demo.Views;

    using NativeCode.Mobile.Core;
    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.XamarinForms.Dependencies;
    using NativeCode.Mobile.Core.XamarinForms.Presentation;

    internal class AppBoostrapper : Bootstrapper
    {
        protected override DependencyAdapter CreateDependencyAdapter()
        {
            return new FormsDependencyAdapter();
        }

        protected override void InternalInitialize()
        {
            this.RegisterViews();
        }

        private void RegisterViews()
        {
            PresentationFactoryRegistry.Register<AboutView, AboutViewModel>(this.DependencyAdapter);
            PresentationFactoryRegistry.Register<AppStylesView, AppStylesViewModel>(this.DependencyAdapter);
            PresentationFactoryRegistry.Register<ArticleView, ArticleViewModel>(this.DependencyAdapter);
            PresentationFactoryRegistry.Register<ControlsView, ControlsViewModel>(this.DependencyAdapter);
            PresentationFactoryRegistry.Register<FlipView, FlipViewModel>(this.DependencyAdapter);
            PresentationFactoryRegistry.Register<MasterDetailInnerNavigationView, MasterDetailInnerNavigationViewModel>(this.DependencyAdapter);
            PresentationFactoryRegistry.Register<MasterDetailOuterNavigationView, MasterDetailOuterNavigationViewModel>(this.DependencyAdapter);
            PresentationFactoryRegistry.Register<SimpleMasterDetailView, SimpleMasterDetailViewModel>(this.DependencyAdapter);
            PresentationFactoryRegistry.Register<SimpleNavigationView, SimpleNavigationViewModel>(this.DependencyAdapter);
            PresentationFactoryRegistry.Register<WebBrowserView, WebBrowserViewModel>(this.DependencyAdapter);
        }
    }
}