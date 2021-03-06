﻿namespace NativeCode.Mobile.Core.XamarinForms.Presentation
{
    using NativeCode.Core.Dependencies;
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

            view.BindingContext = viewModel;

            return view;
        }
    }
}