namespace Demo.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Demo.Views;

    using NativeCode.Mobile.Core.Presentation;
    using NativeCode.Mobile.Core.XamarinForms.Controls;

    public class FlipViewModel : NavigableViewModel
    {
        public FlipViewModel()
        {
            this.Title = "Flip Viewer";

            this.FlipViews = new ObservableCollection<FlipViewContent>(CreateFlipViews());
        }

        public ObservableCollection<FlipViewContent> FlipViews { get; private set; }

        private static IEnumerable<FlipViewContent> CreateFlipViews()
        {
            return new List<FlipViewContent>
            {
                new WebContentView(new WebContentViewModel(new Uri("http://www.xamarin.com"))),
                new WebContentView(new WebContentViewModel(new Uri("http://www.microsoft.com"))),
                new WebContentView(new WebContentViewModel(new Uri("http://www.google.com"))),
                new WebContentView(new WebContentViewModel(new Uri("http://www.flipboard.com"))),
                new WebContentView(new WebContentViewModel(new Uri("http://www.github.com"))),
                new WebContentView(new WebContentViewModel(new Uri("http://www.facebook.com"))),
                new WebContentView(new WebContentViewModel(new Uri("http://www.twitter.com"))),
                new WebContentView(new WebContentViewModel(new Uri("http://www.arstechnica.com")))
            };
        }
    }
}