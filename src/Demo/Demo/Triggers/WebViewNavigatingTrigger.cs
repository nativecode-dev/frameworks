namespace Demo.Triggers
{
    using Xamarin.Forms;

    public class WebViewNavigatingTrigger : TriggerAction<WebView>
    {
        protected override void Invoke(WebView sender)
        {
            if (sender.CanGoBack)
            {
            }
        }
    }
}