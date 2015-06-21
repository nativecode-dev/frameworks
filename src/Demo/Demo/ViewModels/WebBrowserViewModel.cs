namespace Demo.ViewModels
{
    using NativeCode.Mobile.Core.Presentation;

    public class WebBrowserViewModel : NavigableViewModel
    {
        public WebBrowserViewModel()
        {
            this.SourceUrl = @"http://xamarin.com/";
        }

        public bool CanNavigateBack { get; set; }

        public bool CanNavigateForward { get; set; }

        public string SourceUrl { get; set; }
    }
}