using System.Globalization;

namespace NativeCode.Core.Localization
{
    public class DefaultTranslationProvider : ITranslationProvider
    {
        public string GetString(string key, CultureInfo culture)
        {
            return key;
        }
    }
}