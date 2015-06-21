namespace NativeCode.Mobile.Core.Presentation
{
    /// <summary>
    /// Provides a contract to furnish a <see cref="IViewModelNavigator"/> instance.
    /// </summary>
    public interface IViewModelNavigatorProvider
    {
        /// <summary>
        /// Gets the view model navigator.
        /// </summary>
        /// <returns>Returns a <see cref="IViewModelNavigator" />.</returns>
        IViewModelNavigator GetCurrentNavigator();
    }
}