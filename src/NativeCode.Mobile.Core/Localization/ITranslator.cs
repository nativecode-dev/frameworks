namespace NativeCode.Mobile.Core.Localization
{
    using System.Globalization;

    /// <summary>
    /// Provides a contract to translate strings.
    /// </summary>
    public interface ITranslator
    {
        /// <summary>
        /// Translates the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Returns a translated string.</returns>
        string Translate(string key);

        /// <summary>
        /// Translates the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>Returns a translated string.</returns>
        string Translate(string key, CultureInfo cultureInfo);

        /// <summary>
        /// Translates the enumeration value.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>Returns a translated string.</returns>
        string TranslateEnum<T>(T value) where T : struct;

        /// <summary>
        /// Translates the enumeration value.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>Returns a translated string.</returns>
        string TranslateEnum<T>(T value, CultureInfo cultureInfo) where T : struct;

        /// <summary>
        /// Translates the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Returns a translated string.</returns>
        string TranslateFormat(string key, params object[] parameters);

        /// <summary>
        /// Translates the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Returns a translated string.</returns>
        string TranslateFormat(string key, CultureInfo cultureInfo, params object[] parameters);
    }
}