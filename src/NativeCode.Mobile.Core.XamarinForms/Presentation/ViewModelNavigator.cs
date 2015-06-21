namespace NativeCode.Mobile.Core.XamarinForms.Presentation
{
    using System;
    using System.Threading.Tasks;

    using NativeCode.Mobile.Core.Presentation;

    using Xamarin.Forms;

    public class ViewModelNavigator : IViewModelNavigator
    {
        private readonly Func<INavigation> navigation;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelNavigator"/> class.
        /// </summary>
        /// <param name="navigation">The navigation factory.</param>
        public ViewModelNavigator(Func<INavigation> navigation)
        {
            this.navigation = navigation;
        }

        /// <summary>
        /// Gets the navigation.
        /// </summary>
        protected INavigation Navigation
        {
            get { return this.navigation(); }
        }

        public Task<TViewModel> PopAsync<TViewModel>(bool animated = true) where TViewModel : ViewModel
        {
            throw new NotImplementedException();
        }

        public Task<TViewModel> PopModalAsync<TViewModel>(bool animated = true) where TViewModel : ViewModel
        {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync(bool animated = true)
        {
            throw new NotImplementedException();
        }

        public Task PushAsync<TViewModel>(bool animated = true) where TViewModel : ViewModel
        {
            throw new NotImplementedException();
        }

        public Task PushModalAsync<TViewModel>(bool animated = true) where TViewModel : ViewModel
        {
            throw new NotImplementedException();
        }
    }
}