namespace NativeCode.Mobile.Core.Presentation
{
    using NativeCode.Core.Dependencies;

    public abstract class NavigableViewModel : ViewModel
    {
        private readonly IViewModelNavigatorProvider provider;

        protected NavigableViewModel()
        {
            this.provider = DependencyResolver.Current.Resolve<IViewModelNavigatorProvider>();
        }

        protected IViewModelNavigator Navigator
        {
            get { return this.provider.GetCurrentNavigator(); }
        }
    }
}