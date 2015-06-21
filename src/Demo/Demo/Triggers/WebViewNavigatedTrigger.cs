namespace Demo.Triggers
{
    using Xamarin.Forms;

    public class WebViewNavigatedTrigger : TriggerAction<WebView>
    {
        protected override void Invoke(WebView sender)
        {
            if (sender.CanGoBack)
            {
            }
        }
    }
}