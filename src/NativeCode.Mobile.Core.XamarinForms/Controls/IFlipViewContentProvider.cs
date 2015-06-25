namespace NativeCode.Mobile.Core.XamarinForms.Controls
{
    /// <summary>
    /// Provides a contract to furnish <see cref="FlipViewContent" /> instances.
    /// </summary>
    public interface IFlipViewContentProvider
    {
        /// <summary>
        /// Gets the count.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets a <see cref="FlipViewContent" />.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns>Returns a <see cref="FlipViewContent" />.</returns>
        FlipViewContent GetContent(int position);
    }
}