namespace NativeCode.Mobile.Core.Localization
{
    using System.Globalization;

    public class DefaultTranslationProvider : ITranslationProvider
    {
        public string GetString(string key, CultureInfo culture)
        {
            return key;
        }
    }
}