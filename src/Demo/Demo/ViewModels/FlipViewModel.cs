namespace Demo.ViewModels
{
    using System;
    using System.Collections.Generic;

    using Demo.ContentProviders;

    using NativeCode.Mobile.Core.Presentation;
    using NativeCode.Mobile.Core.XamarinForms.Controls;
    using NativeCode.Mobile.Core.XamarinForms.Controls.ContentProviders;

    public class FlipViewModel : NavigableViewModel
    {
        public FlipViewModel()
        {
            this.Title = "Flip Viewer";
            this.ContentProvider =
                new WebContentProvider(
                    new List<Uri>
                    {
                        new Uri("https://www.nativecode.com"),
                        new Uri("https://www.xamarin.com"),
                        new Uri("https://www.google.com"),
                        new Uri("https://www.flipboard.com"),
                        new Uri("https://www.github.com"),
                        new Uri("https://www.microsoft.com"),
                        new Uri("https://www.bing.com")
                    });
        }

        public IContentViewProvider<FlipViewContent> ContentProvider { get; private set; }
    }
}