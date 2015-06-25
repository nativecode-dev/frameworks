namespace NativeCode.Mobile.Core.XamarinForms.Controls.ContentProviders
{
    using Xamarin.Forms;

    /// <summary>
    /// Provides a contract to furnish <see cref="FlipViewContent" /> instances.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="ContentView" />.</typeparam>
    public interface IContentViewProvider<out T>
        where T : ContentView
    {
        /// <summary>
        /// Gets the count.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets a <see cref="ContentView" />-derived type.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>Returns a <see cref="ContentView" />.</returns>
        T GetContent(int position);
    }
}