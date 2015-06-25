namespace NativeCode.Mobile.Core.XamarinForms.Controls
{
    using NativeCode.Mobile.Core.XamarinForms.Controls.ContentProviders;

    using Xamarin.Forms;

    [ContentProperty("Views")]
    public class FlipView : ContentView
    {
        public static readonly BindableProperty FlipViewStyleProperty = BindableProperty.Create<FlipView, FlipViewStyle>(
            x => x.FlipViewStyle,
            default(FlipViewStyle));

        public static readonly BindableProperty ContentProviderProperty =
            BindableProperty.Create<FlipView, IContentViewProvider<FlipViewContent>>(x => x.ContentProvider, default(IContentViewProvider<FlipViewContent>));

        public IContentViewProvider<FlipViewContent> ContentProvider
        {
            get { return (IContentViewProvider<FlipViewContent>)this.GetValue(ContentProviderProperty); }
            set { this.SetValue(ContentProviderProperty, value); }
        }

        public FlipViewStyle FlipViewStyle
        {
            get { return (FlipViewStyle)this.GetValue(FlipViewStyleProperty); }
            set { this.SetValue(FlipViewStyleProperty, value); }
        }
    }
}