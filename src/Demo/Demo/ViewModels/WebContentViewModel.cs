namespace Demo.ViewModels
{
    using System;

    using NativeCode.Mobile.Core.Presentation;

    using Xamarin.Forms;

    public class WebContentViewModel : ViewModel
    {
        public WebContentViewModel(Uri url)
        {
            this.Source = new UrlWebViewSource { Url = url.AbsoluteUri };
        }

        public UrlWebViewSource Source { get; set; }
    }
}