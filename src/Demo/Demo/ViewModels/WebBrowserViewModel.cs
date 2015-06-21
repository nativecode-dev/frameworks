namespace Demo.ViewModels
{
    using System;

    using NativeCode.Mobile.Core.Presentation;

    using Xamarin.Forms;

    public class WebBrowserViewModel : NavigableViewModel
    {
        public WebBrowserViewModel()
        {
            this.SourceUrl = new Uri("http://xamarin.com/");
            this.Title = "Loading...";
        }

        public bool CanNavigateBack { get; set; }

        public bool CanNavigateForward { get; set; }

        public WebViewSource SourceUrl { get; set; }
    }
}