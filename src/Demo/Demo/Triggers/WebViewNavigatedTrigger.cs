namespace Demo.Triggers
{
    using NativeCode.Mobile.Core.Presentation;

    using Xamarin.Forms;

    public class WebViewNavigatedTrigger : TriggerAction<WebView>
    {
        public Page Page { get; set; }

        protected override void Invoke(WebView sender)
        {
            var viewModel = this.Page.BindingContext as ViewModel;

            if (viewModel == null)
            {
                return;
            }

            viewModel.IsBusy = false;

            var url = sender.Source as UrlWebViewSource;

            if (url != null)
            {
                viewModel.Title = url.Url;
            }
        }
    }
}