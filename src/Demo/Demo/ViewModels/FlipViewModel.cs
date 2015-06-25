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
                        new Uri("http://www.xamarin.com"),
                        new Uri("http://www.google.com"),
                        new Uri("http://www.flipboard.com"),
                        new Uri("http://www.github.com"),
                        new Uri("http://www.microsoft.com"),
                        new Uri("http://www.bing.com")
                    });
        }

        public IContentViewProvider<FlipViewContent> ContentProvider { get; private set; }
    }
}