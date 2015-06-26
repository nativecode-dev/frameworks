namespace NativeCode.Mobile.Core.XamarinForms.MarkupExtensions
{
    using System;

    using NativeCode.Mobile.Core.Localization;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [ContentProperty("Key")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Key { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return string.IsNullOrWhiteSpace(this.Key) ? null : Translator.Translate(this.Key);
        }
    }
}