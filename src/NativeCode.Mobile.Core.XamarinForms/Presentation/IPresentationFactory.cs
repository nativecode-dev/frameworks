namespace NativeCode.Mobile.Core.XamarinForms.Presentation
{
    using NativeCode.Mobile.Core.Presentation;

    using Xamarin.Forms;

    /// <summary>
    /// Provides a contract to create view models and views.
    /// </summary>
    public interface IPresentationFactory
    {
        /// <summary>
        /// Gets a <see cref="Page" /> bound by a view model.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <returns>Returns a <see cref="Page" />.</returns>
        Page GetViewFor<TViewModel>() where TViewModel : NavigableViewModel;
    }
}