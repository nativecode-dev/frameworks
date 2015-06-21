namespace NativeCode.Mobile.Core.XamarinForms.Presentation
{
    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.Presentation;

    using Xamarin.Forms;

    public class PresentationFactory : IPresentationFactory
    {
        public PresentationFactory(IViewModelNavigatorProvider provider)
        {
            this.Provider = provider;
        }

        protected IViewModelNavigatorProvider Provider { get; private set; }

        public Page GetViewFor<TViewModel>() where TViewModel : NavigableViewModel
        {
            var registration = PresentationFactoryRegistry.GetRegistration<TViewModel>();
            var view = (Page)DependencyResolver.Current.Resolve(registration.View);
            var viewModel = DependencyResolver.Current.Resolve<TViewModel>();

            this.BindViewModelToView(view, viewModel);

            return view;
        }

        public TView GetView<TView, TViewModel>() where TView : Page where TViewModel : NavigableViewModel
        {
            var registration = PresentationFactoryRegistry.GetRegistration<TViewModel>();
            var view = (TView)DependencyResolver.Current.Resolve(registration.View);
            var viewModel = DependencyResolver.Current.Resolve<TViewModel>();

            this.BindViewModelToView(view, viewModel);

            return view;
        }

        private void BindViewModelToView(BindableObject view, IViewModelNavigatorSetter viewModel)
        {
            viewModel.SetNavigator(this.Provider.GetViewModelNavigator());
            view.BindingContext = viewModel;
        }
    }
}