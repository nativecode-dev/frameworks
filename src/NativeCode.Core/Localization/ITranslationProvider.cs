namespace NativeCode.Core.Localization
{
    using System.Globalization;

    /// <summary>
    /// Provides a contract to create a resource manager that contains translations.
    /// </summary>
    public interface ITranslationProvider
    {
        /// <summary>
        /// Gets the translated string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>Returns translated string.</returns>
        string GetString(string key, CultureInfo culture);
    }
}