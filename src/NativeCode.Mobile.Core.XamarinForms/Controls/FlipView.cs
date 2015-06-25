namespace NativeCode.Mobile.Core.XamarinForms.Controls
{
    using System.Collections.Generic;

    using Xamarin.Forms;

    [ContentProperty("Views")]
    public class FlipView : ContentView
    {
        public static readonly BindableProperty FlipViewStyleProperty = BindableProperty.Create<FlipView, FlipViewStyle>(
            x => x.FlipViewStyle,
            default(FlipViewStyle));

        public static readonly BindableProperty ViewsProperty = BindableProperty.Create<FlipView, IList<FlipViewContent>>(
            x => x.Views,
            new List<FlipViewContent>());

        public FlipViewStyle FlipViewStyle
        {
            get { return (FlipViewStyle)this.GetValue(FlipViewStyleProperty); }
            set { this.SetValue(FlipViewStyleProperty, value); }
        }

        public IList<FlipViewContent> Views
        {
            get { return (IList<FlipViewContent>)this.GetValue(ViewsProperty); }
            set { this.SetValue(ViewsProperty, value); }
        }
    }
}