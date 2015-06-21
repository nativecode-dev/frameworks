namespace NativeCode.Mobile.Core.Presentation
{
    /// <summary>
    /// Provides a contract to provide a <see cref="IViewModelNavigator" />.
    /// </summary>
    public interface IViewModelNavigatorSetter
    {
        void SetNavigator(IViewModelNavigator navigator);
    }
}