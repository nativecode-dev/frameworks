namespace NativeCode.Mobile.Core.Droid.Platform
{
    using Android.Content;

    /// <summary>
    /// Provides a contract to get the current <see cref="Context" />.
    /// </summary>
    public interface IContextProvider
    {
        /// <summary>
        /// Gets the current context.
        /// </summary>
        /// <returns>Returns a <see cref="Context" />.</returns>
        Context GetCurrentContext();
    }
}