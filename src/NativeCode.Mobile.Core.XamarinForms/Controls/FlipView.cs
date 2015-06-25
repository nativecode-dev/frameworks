namespace NativeCode.Mobile.Core.XamarinForms.Controls
{
    using Xamarin.Forms;

    [ContentProperty("Views")]
    public class FlipView : ContentView
    {
        public static readonly BindableProperty FlipViewStyleProperty = BindableProperty.Create<FlipView, FlipViewStyle>(
            x => x.FlipViewStyle,
            default(FlipViewStyle));

        public static readonly BindableProperty ContentProviderProperty = BindableProperty.Create<FlipView, IFlipViewContentProvider>(
            x => x.ContentProvider,
            default(IFlipViewContentProvider));

        public IFlipViewContentProvider ContentProvider
        {
            get { return (IFlipViewContentProvider)this.GetValue(ContentProviderProperty); }
            set { this.SetValue(ContentProviderProperty, value); }
        }

        public FlipViewStyle FlipViewStyle
        {
            get { return (FlipViewStyle)this.GetValue(FlipViewStyleProperty); }
            set { this.SetValue(FlipViewStyleProperty, value); }
        }
    }
}