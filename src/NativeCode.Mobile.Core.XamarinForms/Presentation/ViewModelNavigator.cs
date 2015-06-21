﻿namespace NativeCode.Mobile.Core.XamarinForms.Presentation
{
    using System;
    using System.Threading.Tasks;

    using NativeCode.Mobile.Core.Dependencies;
    using NativeCode.Mobile.Core.Extensions;
    using NativeCode.Mobile.Core.Presentation;

    using Xamarin.Forms;

    internal class ViewModelNavigator : IViewModelNavigator
    {
        private readonly Func<INavigation> navigation;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelNavigator" /> class.
        /// </summary>
        /// <param name="navigation">The navigation factory.</param>
        public ViewModelNavigator(Func<INavigation> navigation)
        {
            this.navigation = navigation;
            this.PresentationFactory = DependencyResolver.Current.Resolve<IPresentationFactory>();
        }

        /// <summary>
        /// Gets the navigation.
        /// </summary>
        protected INavigation Navigation
        {
            get { return this.navigation(); }
        }

        protected IPresentationFactory PresentationFactory { get; private set; }

        public async Task PopAsync(bool animated = true)
        {
            var page = await this.Navigation.PopAsync(animated);
            page.DisposeIfNeeded();
            page.BindingContext.DisposeIfNeeded();
        }

        public async Task PopModalAsync(bool animated = true)
        {
            var page = await this.Navigation.PopModalAsync(animated);
            page.DisposeIfNeeded();
            page.BindingContext.DisposeIfNeeded();
        }

        public Task PopToRootAsync(bool animated = true)
        {
            return this.Navigation.PopToRootAsync(animated);
        }

        public Task PushAsync<TViewModel>(bool animated = true) where TViewModel : NavigableViewModel
        {
            return this.PushAsync<TViewModel>(null, animated);
        }

        public Task PushAsync<TViewModel>(Action<TViewModel> initializer, bool animated = true) where TViewModel : NavigableViewModel
        {
            var view = this.PresentationFactory.GetViewFor<TViewModel>();

            if (initializer != null)
            {
                initializer((TViewModel)view.BindingContext);
            }

            return this.Navigation.PushAsync(view, animated);
        }

        public Task PushModalAsync<TViewModel>(bool animated = true) where TViewModel : NavigableViewModel
        {
            return this.PushModalAsync<TViewModel>(null, animated);
        }

        public Task PushModalAsync<TViewModel>(Action<TViewModel> initializer, bool animated = true) where TViewModel : NavigableViewModel
        {
            var view = this.PresentationFactory.GetViewFor<TViewModel>();

            if (initializer != null)
            {
                initializer((TViewModel)view.BindingContext);
            }

            return this.Navigation.PushModalAsync(view, animated);
        }
    }
}