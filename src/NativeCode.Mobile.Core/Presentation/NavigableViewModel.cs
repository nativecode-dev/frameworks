namespace NativeCode.Mobile.Core.Presentation
{
    public abstract class NavigableViewModel : ViewModel, IViewModelNavigatorSetter
    {
        protected IViewModelNavigator Navigator { get; private set; }

        void IViewModelNavigatorSetter.SetNavigator(IViewModelNavigator navigator)
        {
            this.Navigator = navigator;
        }
    }
}