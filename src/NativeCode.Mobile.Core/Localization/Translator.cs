namespace NativeCode.Mobile.Core.Localization
{
    using System;
    using System.Globalization;

    using NativeCode.Mobile.Core.Dependencies;

    public sealed class Translator : ITranslator
    {
        private static readonly Lazy<ITranslator> DefaultInstance = new Lazy<ITranslator>(CreateDefaultInstance);

        private readonly ITranslationProvider translationProvider;

        public Translator(ITranslationProvider translationProvider)
        {
            this.translationProvider = translationProvider;
        }

        public static ITranslator Default
        {
            get { return DefaultInstance.Value; }
        }

        public static string Translate(string key)
        {
            return Default.Translate(key);
        }

        public static string Translate(string key, CultureInfo cultureInfo)
        {
            return Default.Translate(key, cultureInfo);
        }

        public static string TranslateFormat(string key, params object[] parameters)
        {
            return Default.TranslateFormat(key, parameters);
        }

        public static string TranslateFormat(string key, CultureInfo cultureInfo, params object[] parameters)
        {
            return Default.TranslateFormat(key, cultureInfo, parameters);
        }

        string ITranslator.Translate(string key)
        {
            return ((ITranslator)this).Translate(key, CultureInfo.CurrentUICulture);
        }

        string ITranslator.Translate(string key, CultureInfo cultureInfo)
        {
            return this.translationProvider.GetString(key, cultureInfo);
        }

        string ITranslator.TranslateEnum<T>(T value)
        {
            var type = typeof(T);

            return Default.Translate(type.Name + "_" + Enum.GetName(type, value));
        }

        string ITranslator.TranslateEnum<T>(T value, CultureInfo cultureInfo)
        {
            var type = typeof(T);

            return Default.Translate(type.Name + "_" + Enum.GetName(type, value), cultureInfo);
        }

        string ITranslator.TranslateFormat(string key, params object[] parameters)
        {
            return TranslateFormat(key, parameters);
        }

        string ITranslator.TranslateFormat(string key, CultureInfo cultureInfo, params object[] parameters)
        {
            return string.Format(((ITranslator)this).Translate(key, cultureInfo), parameters);
        }

        private static ITranslator CreateDefaultInstance()
        {
            return DependencyResolver.Current.Resolve<ITranslator>();
        }
    }
}